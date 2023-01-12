using Gma.System.MouseKeyHook;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Task_Automator
{
    public partial class Form1 : Form
    {

        public const string SAVELOCATION = "Data/Program.txt";
        public const string RESULTSLOCATIONS = "Data/Results.txt";


        private List<PreGeneratedData> pregenData = new List<PreGeneratedData>();
        private int selectedIndex = -1;

        private IKeyboardMouseEvents m_GlobalHook;

        private bool taskKillSwitch = false;
        private bool taskPause = false;
        private bool taskSkipItteration = false;


        private Point mousePosition;
        private Task runningTask = null;

        private int itterationsResetTo = 1;


        public Form1()
        {
            m_GlobalHook = Hook.GlobalEvents();

            m_GlobalHook.KeyPress += OnBTNClick;
            m_GlobalHook.MouseMove += UpdateMouse;

            InitializeComponent();
        }


        private void Form1_Load(object sender, EventArgs e)
        {
            LoadPreData();
            ResetItterations(null, null);

            ElementsContainer.HorizontalScroll.Maximum = 0;
            TaskTypeList.Items.Clear();

            foreach(string str in Enum.GetNames(typeof(PreGeneratedData.Types)))
            {
                TaskTypeList.Items.Add(str);
            }

            EditPannel.Hide();
        }



        private void LoadPreData()
        {
            if (File.Exists(SAVELOCATION))
            {
                string text = File.ReadAllText(SAVELOCATION);
                pregenData = JsonConvert.DeserializeObject<List<PreGeneratedData>>(text);

                if (pregenData == null)
                    pregenData = new List<PreGeneratedData>();

                RedrawList();
            }
        }


        private void SavePreData()
        {
            File.WriteAllText(SAVELOCATION, JsonConvert.SerializeObject(pregenData));
        }




        private void UpdateMouse(object sender, MouseEventArgs args)
        {
            if(runningTask == null || runningTask.IsCompleted)
            {
                mousePosition = args.Location;
                MousePositionIndicator.Text = $"MOUSE POSITION: X={mousePosition.X}, Y={mousePosition.Y}";
            }
            else
            {
                MousePositionIndicator.Text = taskPause ? "Paused" : "Running";
            }


        }


        private void OnBTNClick(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '`')
            {
                taskPause = true;
                DialogResult res = MessageBox.Show($"This will stop the program as it is", "Kill program", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (res == DialogResult.OK)
                    taskKillSwitch = true;

                taskPause = false;
            }

            if (e.KeyChar == '\\')
            {
                if (runningTask == null || runningTask.IsCompleted)
                {
                    PreGeneratedData data = new PreGeneratedData();
                    data.name = $"Mouse to - ({mousePosition.X},{mousePosition.Y})";
                    data.args = new object[] { mousePosition.X, mousePosition.Y, 0 };

                    pregenData.Add(data);
                    RedrawList();
                }
                else
                {
                    bool temp = taskPause;
                    taskPause = true;

                    if (!temp)
                    {
                        DialogResult res = MessageBox.Show($"skip this itteration?", "Skip", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

                        if (res == DialogResult.OK)
                        {
                            taskPause = true;
                            taskSkipItteration = true;
                        }
                        
                    }
                    else
                    {
                        taskPause = false;
                    }
                }
            }



        }



        private void button1_Click(object sender, EventArgs e)
        {
            if(int.TryParse(ItterationCounter.Text, out int itterationsToDo))
            {
                if (itterationsToDo <= 0 || (runningTask != null && !runningTask.IsCompleted))
                    return;

                EditPannel.Hide();

                taskPause = false;
                taskKillSwitch = false;

                itterationsResetTo = itterationsToDo;
                runningTask = InternalWork(itterationsToDo);
            }
        }


        private async Task InternalWork(int repeats)
        {
            if(repeats <= 0)
            {
                MessageBox.Show("Program Complete", "Done", MessageBoxButtons.OK);
                return;
            }

            for (int i = 0; i < pregenData.Count; i++)
            {
                TaskBase taskToComplete = null;

                switch ((PreGeneratedData.Types)pregenData[i].type)
                {
                    case PreGeneratedData.Types.Move:
                        taskToComplete = new Task_MoveMouse();
                        break;

                    case PreGeneratedData.Types.KeyboardType:
                        taskToComplete = new Task_KeyboardType();
                        break;

                    case PreGeneratedData.Types.Scroll:
                        taskToComplete = new Task_Scroll();
                        break;

                    case PreGeneratedData.Types.Delay:
                        await Task.Delay((int)Math.Round(float.Parse(pregenData[i].args[0].ToString()) * 1000));
                        continue;


                    case PreGeneratedData.Types.CopyToClipboard:
                        taskToComplete = new Task_CopyToClipboard();
                        break;

                    case PreGeneratedData.Types.WriteClipboardToFile:
                        File.AppendAllLines(RESULTSLOCATIONS, new string[] { Clipboard.GetText() });
                        continue;

                    case PreGeneratedData.Types.Pause:
                        taskPause = true;
                        break;
                }

                if (float.TryParse(TimeBetweenEvents.Text, out float v))
                    await Task.Delay((int)Math.Round(v * 1000));


                while (taskPause)
                {
                    await Task.Delay(100);

                    if (taskSkipItteration)
                    {
                        taskSkipItteration = false;
                        break;
                    }
                }

                if (taskKillSwitch)
                {
                    repeats = 0;
                    taskKillSwitch = false;
                    MessageBox.Show("Task has been killed", "Killed", MessageBoxButtons.OK);

                    break;
                }


                if (taskToComplete != null)
                {
                    taskToComplete.Setup(pregenData[i].args);
                    taskToComplete.Work();
                    continue;
                }

                if (i == pregenData.Count - 1)
                    break; // ? it repeats for some reason
            }

            
            if(float.TryParse(TimeBetweenItterations.Text, out float val))
                await Task.Delay((int)Math.Round(val * 1000));

            ItterationCounter.Text = (repeats - 1).ToString();
            runningTask = InternalWork(repeats - 1);
        }



        private void AddNewElement(object sender, EventArgs e)
        {
            if (runningTask != null && !runningTask.IsCompleted)
                return;

            pregenData.Add(new PreGeneratedData());
            RedrawList();
        }


        private void RemoveSelected(object sender, EventArgs e)
        {
            if (runningTask != null && !runningTask.IsCompleted)
                return;

            if(selectedIndex >= 0 && selectedIndex < pregenData.Count)
            {
                DialogResult res = MessageBox.Show($"remove the entry {pregenData[selectedIndex]}", "Remove", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

                if (res == DialogResult.OK)
                {
                    pregenData.RemoveAt(selectedIndex);
                    selectedIndex = -1;

                    RedrawList();
                }
            }
        }

        private void RedrawList()
        {
            for (int i = 0; i < Math.Max(ElementsContainer.Controls.Count, pregenData.Count); i++)
            {
                if(i >= pregenData.Count) // remove
                {
                    ElementsContainer.Controls.RemoveAt(ElementsContainer.Controls.Count - 1);
                }
                else if(i >= ElementsContainer.Controls.Count) // create new
                {
                    int index = i;

                    Button btn = new Button();
                    btn.Text = pregenData[i].name;
                    btn.Location = new Point(0, ElementsContainer.Controls.Count * 30);
                    btn.Width = ElementsContainer.Width;
                    btn.Click += (s, e) => SetSelection(index);

                    btn.ForeColor = Color.Black;

                    ElementsContainer.Controls.Add(btn);
                    ElementsContainer.Controls[i].BackColor = selectedIndex == i ? Color.Blue : Color.White;
                }
                else // update
                {
                    ElementsContainer.Controls[i].Text = pregenData[i].name;
                    ElementsContainer.Controls[i].BackColor = selectedIndex == i ? Color.Blue : Color.White;
                }
            }

            SavePreData();
        }



        private void SetSelection(int to) => selectedIndex = to;

        private void StartEdit(object sender, EventArgs e)
        {
            if (runningTask != null && !runningTask.IsCompleted)
                return;

            if (selectedIndex >= 0 && selectedIndex < pregenData.Count)
            {
                textBox1.Text = pregenData[selectedIndex].name;
                TaskTypeList.SelectedIndex = pregenData[selectedIndex].type;

                RedrawUniqueBox();

                EditPannel.Show();
            }
        }


        private void SaveEdit(object sender, EventArgs e)
        {
            pregenData[selectedIndex].name = textBox1.Text;
            pregenData[selectedIndex].type = TaskTypeList.SelectedIndex;

            selectedIndex = -1;
            EditPannel.Hide();
            RedrawList();
        }

        private void TaskTypeList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (pregenData[selectedIndex].type != TaskTypeList.SelectedIndex)
                pregenData[selectedIndex].args = null;

            RedrawUniqueBox();
        }


        private void RedrawUniqueBox()
        {
            UniqueSettingsPanel.Controls.Clear();
            int heightOfEls = 18;

            FlowLayoutPanel[] panels = new FlowLayoutPanel[0];

            switch ((PreGeneratedData.Types)TaskTypeList.SelectedIndex)
            {
                case PreGeneratedData.Types.Move:
                    panels = Task_MoveMouse.GenerateUI(pregenData[selectedIndex], heightOfEls, UniqueSettingsPanel.Width);
                    break;



                case PreGeneratedData.Types.Delay: // b
                    if (pregenData[selectedIndex].args == null)
                        pregenData[selectedIndex].args = new object[] { 0 };


                    FlowLayoutPanel b_f1 = new FlowLayoutPanel();
                    b_f1.Height = heightOfEls;
                    b_f1.Width = UniqueSettingsPanel.Width;
                    b_f1.FlowDirection = FlowDirection.LeftToRight;

                    Label b_l = new Label();
                    b_l.Text = "Delay (seconds): ";
                    TextBox b_t = new TextBox();
                    b_t.Text = pregenData[selectedIndex].args[0].ToString();
                    b_t.Validating += (a, b) => { if (int.TryParse(b_t.Text, out int res)) pregenData[selectedIndex].args[0] = res; };
                    b_f1.Controls.Add(b_l);
                    b_f1.Controls.Add(b_t);

                    panels = new FlowLayoutPanel[] { b_f1 };
                    break;



                case PreGeneratedData.Types.Scroll: //c

                    break;



                case PreGeneratedData.Types.KeyboardType: // d
                    panels = Task_KeyboardType.GenerateUI(pregenData[selectedIndex], heightOfEls, UniqueSettingsPanel.Width);
                    break;
            }

            foreach (var v in panels)
                UniqueSettingsPanel.Controls.Add(v);
        }



        private void ResetItterations(object sender, EventArgs e)
        {
            taskKillSwitch = true;
            ItterationCounter.Text = itterationsResetTo.ToString();
        }

        private void ResultsClear_Click(object sender, EventArgs e)
        {
            DialogResult res = MessageBox.Show($"This will remove all text from the file", "Clear", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);

            if(res == DialogResult.OK)
            {
                File.WriteAllLines(RESULTSLOCATIONS, new string[0]);
            }
            
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            taskPause = true;
            taskSkipItteration = true;
        }
    }


    //--------------------------------------------------------------------------------------------------------------------------------\\



    [System.Serializable]
    public class PreGeneratedData
    {
        public object[] args;
        public int type;
        public string name;


        public void Setup(string name, Types type, object[] args)
        {
            this.name = name;
            this.type = (int)type;
            this.args = args;
        }



        public enum Types
        {
            Move,
            KeyboardType,
            Scroll,
            Delay,
            CopyToClipboard,
            WriteClipboardToFile,
            Pause,
        }
    }



    public class TaskSet
    {
        public TaskBase[] tasks;
    }


    public abstract class TaskBase
    {
        public abstract void Setup(object[] args);
        public abstract void Work();
    }



    public class Task_MoveMouse : TaskBase
    {
        int x;
        int y;

        int clickType;

        /// <summary>
        /// int x, int y, int clickType ? (-1 = none, 0 - right, 2 - left)
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Setup(object[] args)
        {
            x = int.Parse(args[0].ToString());
            y = int.Parse(args[1].ToString());

            clickType = int.Parse(args[2].ToString());
        }


        public override void Work()
        {
            Cursor.Position = new Point(x, y);

            switch ((ClickTypes)clickType)
            {
                case  ClickTypes.None: // none
                    return;

                case ClickTypes.Right:
                    rightClick(new Point(x,y));
                    return;

                case ClickTypes.Left:
                    leftClick(new Point(x, y));
                    return;

                case ClickTypes.DoubleLeft:
                    doubleLeftClick(new Point(x, y));
                    return;

                case ClickTypes.DoubleRight:
                    doubleRightClick(new Point(x, y));
                    return;
            }
        }


        public static FlowLayoutPanel[] GenerateUI(PreGeneratedData data, int heightOfEls, int maxWidth)
        {
            if (data.args == null)
                data.args = new object[] { 0, 0, -1 };

            FlowLayoutPanel a_f1 = new FlowLayoutPanel();
            a_f1.Height = heightOfEls;
            a_f1.Width = maxWidth;
            a_f1.FlowDirection = FlowDirection.LeftToRight;

            Label a_l = new Label();
            a_l.Text = "Position X: ";
            TextBox a_t1 = new TextBox();
            a_t1.Text = data.args[0].ToString();
            a_t1.Validating += (a, b) => { if (int.TryParse(a_t1.Text, out int res)) data.args[0] = res; };
            a_f1.Controls.Add(a_l);
            a_f1.Controls.Add(a_t1);





            FlowLayoutPanel a_f2 = new FlowLayoutPanel();
            a_f2.Height = heightOfEls;
            a_f2.Width = maxWidth;
            a_f2.FlowDirection = FlowDirection.LeftToRight;

            Label a_l2 = new Label();
            a_l2.Text = "Position Y: ";
            TextBox a_t2 = new TextBox();
            a_t2.Text = data.args[1].ToString();
            a_t2.Validating += (a, b) => { if (int.TryParse(a_t2.Text, out int res)) data.args[1] = res; };
            a_f2.Controls.Add(a_l2);
            a_f2.Controls.Add(a_t2);



            FlowLayoutPanel a_f3 = new FlowLayoutPanel();
            a_f3.Height = heightOfEls + 2;
            a_f3.Width = maxWidth;
            a_f3.FlowDirection = FlowDirection.LeftToRight;

            Label a_t3 = new Label();
            a_t3.Text = "Click After Move";
            ComboBox a_c = new ComboBox();

            foreach (string click in Enum.GetNames(typeof(Task_MoveMouse.ClickTypes)))
                a_c.Items.Add(click);

            a_c.SelectedIndex = int.Parse(data.args[2].ToString());
            a_c.SelectedIndexChanged += (a, b) => data.args[2] = a_c.SelectedIndex;
            a_f3.Controls.Add(a_t3);
            a_f3.Controls.Add(a_c);


            return new FlowLayoutPanel[] { a_f1, a_f2, a_f3 };
        }


        #region internal



        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        [Flags]
        public enum MouseEventFlags
        {
            LEFTDOWN = 0x00000002,
            LEFTUP = 0x00000004,
            MIDDLEDOWN = 0x00000020,
            MIDDLEUP = 0x00000040,
            MOVE = 0x00000001,
            ABSOLUTE = 0x00008000,
            RIGHTDOWN = 0x00000008,
            RIGHTUP = 0x00000010
        }

        public void leftClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        public void doubleLeftClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        public void rightClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }

        public void doubleRightClick(Point p)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }

        public void holDownLeft(Point p, int tempo)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.LEFTDOWN), 0, 0, 0, 0);
            Thread.Sleep(tempo);
            mouse_event((int)(MouseEventFlags.LEFTUP), 0, 0, 0, 0);
        }

        public void holDownRight(Point p, int tempo)
        {
            Cursor.Position = p;
            mouse_event((int)(MouseEventFlags.RIGHTDOWN), 0, 0, 0, 0);
            Thread.Sleep(tempo);
            mouse_event((int)(MouseEventFlags.RIGHTUP), 0, 0, 0, 0);
        }
        #endregion



        public enum ClickTypes
        {
            None,
            Left,
            Right,
            DoubleLeft,
            DoubleRight,
        }
    }




    public class Task_KeyboardType : TaskBase
    {
        string toType;
        bool pressEnter;

        /// <summary>
        /// text to type, bool press enter?
        /// </summary>
        /// <param name="args"></param>
        public override void Setup(object[] args)
        {
            toType = (string)args[0];
            pressEnter = (bool)args[1];
        }

        public override void Work()
        {
            if(toType != "")
                SendKeys.Send(toType);

            if (pressEnter)
            {
                SendKeys.Send("{ENTER}");
            }
        }


        public static FlowLayoutPanel[] GenerateUI(PreGeneratedData data, int elHeight, int maxWidth)
        {
            if (data.args == null)
                data.args = new object[] { "To type", true };

            FlowLayoutPanel d_f1 = new FlowLayoutPanel();
            d_f1.Height = elHeight;
            d_f1.Width = maxWidth;
            d_f1.FlowDirection = FlowDirection.LeftToRight;

            Label d_l = new Label();
            d_l.Text = "Text: ";
            TextBox d_t = new TextBox();
            d_t.Text = data.args[0].ToString();
            d_t.Validating += (a, b) => data.args[0] = d_t.Text;
            d_f1.Controls.Add(d_l);
            d_f1.Controls.Add(d_t);



            FlowLayoutPanel d_f2 = new FlowLayoutPanel();
            d_f2.Height = elHeight;
            d_f2.Width = maxWidth;
            d_f2.FlowDirection = FlowDirection.LeftToRight;

            CheckBox checkBox = new CheckBox();
            checkBox.Text = "Press Enter After";
            checkBox.Checked = (bool)data.args[1];
            checkBox.Validating += (a, b) => data.args[1] = checkBox.Checked;
            d_f2.Controls.Add(checkBox);


            return new FlowLayoutPanel[] { d_f1, d_f2 };
        }
    }

    public class Task_Scroll : TaskBase
    {
        private bool up;

        /// <summary>
        /// bool up?
        /// </summary>
        /// <param name="args"></param>
        /// <exception cref="NotImplementedException"></exception>
        public override void Setup(object[] args)
        {
            up = (bool)args[0];
        }

        public override void Work()
        {
            SendKeys.Send("{PGDN}");
        }
    }


    public class Task_CopyToClipboard : TaskBase
    {
        public override void Setup(object[] args)
        {
        }


        public override void Work()
        {
            SendKeys.Send("^(c)");
        }
    }
}
