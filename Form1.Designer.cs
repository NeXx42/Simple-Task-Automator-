namespace Task_Automator
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button4 = new System.Windows.Forms.Button();
            this.ElementsContainer = new System.Windows.Forms.Panel();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.EditPannel = new System.Windows.Forms.Panel();
            this.SaveBTN = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.UniqueSettingsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.TaskTypeList = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.MousePositionIndicator = new System.Windows.Forms.Label();
            this.ItterationCounter = new System.Windows.Forms.TextBox();
            this.Itterations = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.ResultsClear = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.TimeBetweenEvents = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.TimeBetweenItterations = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.EditPannel.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 415);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Work";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Black;
            this.panel1.Controls.Add(this.button4);
            this.panel1.Controls.Add(this.ElementsContainer);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.panel1.Location = new System.Drawing.Point(717, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(290, 450);
            this.panel1.TabIndex = 1;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(103, 400);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(81, 23);
            this.button4.TabIndex = 3;
            this.button4.Text = "Edit";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.StartEdit);
            // 
            // ElementsContainer
            // 
            this.ElementsContainer.AutoScroll = true;
            this.ElementsContainer.BackColor = System.Drawing.Color.Gray;
            this.ElementsContainer.Location = new System.Drawing.Point(12, 16);
            this.ElementsContainer.Name = "ElementsContainer";
            this.ElementsContainer.Size = new System.Drawing.Size(268, 366);
            this.ElementsContainer.TabIndex = 2;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(212, 400);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(68, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Add New";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.AddNewElement);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 400);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(96, 23);
            this.button2.TabIndex = 0;
            this.button2.Text = "Remove";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.RemoveSelected);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(14, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 29);
            this.label1.TabIndex = 0;
            this.label1.Text = "Editing";
            // 
            // textBox1
            // 
            this.textBox1.CausesValidation = false;
            this.textBox1.Location = new System.Drawing.Point(91, 59);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(350, 20);
            this.textBox1.TabIndex = 1;
            this.textBox1.Text = "asd";
            // 
            // EditPannel
            // 
            this.EditPannel.BackColor = System.Drawing.Color.Black;
            this.EditPannel.Controls.Add(this.SaveBTN);
            this.EditPannel.Controls.Add(this.label4);
            this.EditPannel.Controls.Add(this.UniqueSettingsPanel);
            this.EditPannel.Controls.Add(this.TaskTypeList);
            this.EditPannel.Controls.Add(this.label3);
            this.EditPannel.Controls.Add(this.label2);
            this.EditPannel.Controls.Add(this.textBox1);
            this.EditPannel.Controls.Add(this.label1);
            this.EditPannel.Location = new System.Drawing.Point(235, 12);
            this.EditPannel.Name = "EditPannel";
            this.EditPannel.Size = new System.Drawing.Size(462, 353);
            this.EditPannel.TabIndex = 5;
            // 
            // SaveBTN
            // 
            this.SaveBTN.Location = new System.Drawing.Point(384, 327);
            this.SaveBTN.Name = "SaveBTN";
            this.SaveBTN.Size = new System.Drawing.Size(75, 23);
            this.SaveBTN.TabIndex = 6;
            this.SaveBTN.Text = "Save";
            this.SaveBTN.UseVisualStyleBackColor = true;
            this.SaveBTN.Click += new System.EventHandler(this.SaveEdit);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(27, 126);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "Unique";
            // 
            // UniqueSettingsPanel
            // 
            this.UniqueSettingsPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.UniqueSettingsPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.UniqueSettingsPanel.Location = new System.Drawing.Point(91, 126);
            this.UniqueSettingsPanel.Name = "UniqueSettingsPanel";
            this.UniqueSettingsPanel.Size = new System.Drawing.Size(350, 175);
            this.UniqueSettingsPanel.TabIndex = 6;
            // 
            // TaskTypeList
            // 
            this.TaskTypeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.TaskTypeList.FormattingEnabled = true;
            this.TaskTypeList.Items.AddRange(new object[] {
            "Scroll",
            "Mouse Move",
            "Type"});
            this.TaskTypeList.Location = new System.Drawing.Point(91, 83);
            this.TaskTypeList.Name = "TaskTypeList";
            this.TaskTypeList.Size = new System.Drawing.Size(121, 21);
            this.TaskTypeList.TabIndex = 5;
            this.TaskTypeList.SelectedIndexChanged += new System.EventHandler(this.TaskTypeList_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(27, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Type";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(27, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Name";
            // 
            // MousePositionIndicator
            // 
            this.MousePositionIndicator.AutoSize = true;
            this.MousePositionIndicator.Font = new System.Drawing.Font("Microsoft Sans Serif", 13F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MousePositionIndicator.Location = new System.Drawing.Point(231, 416);
            this.MousePositionIndicator.Name = "MousePositionIndicator";
            this.MousePositionIndicator.Size = new System.Drawing.Size(252, 22);
            this.MousePositionIndicator.TabIndex = 6;
            this.MousePositionIndicator.Text = "Mouse Position: x - 25, y - 100";
            // 
            // ItterationCounter
            // 
            this.ItterationCounter.Location = new System.Drawing.Point(99, 374);
            this.ItterationCounter.Name = "ItterationCounter";
            this.ItterationCounter.Size = new System.Drawing.Size(50, 20);
            this.ItterationCounter.TabIndex = 7;
            // 
            // Itterations
            // 
            this.Itterations.AutoSize = true;
            this.Itterations.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Itterations.Location = new System.Drawing.Point(12, 374);
            this.Itterations.Name = "Itterations";
            this.Itterations.Size = new System.Drawing.Size(81, 20);
            this.Itterations.TabIndex = 8;
            this.Itterations.Text = "Itterations";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(155, 374);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(50, 23);
            this.button5.TabIndex = 9;
            this.button5.Text = "Reset";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.ResetItterations);
            // 
            // ResultsClear
            // 
            this.ResultsClear.Location = new System.Drawing.Point(67, 415);
            this.ResultsClear.Name = "ResultsClear";
            this.ResultsClear.Size = new System.Drawing.Size(78, 23);
            this.ResultsClear.TabIndex = 10;
            this.ResultsClear.Text = "Clear Results";
            this.ResultsClear.UseVisualStyleBackColor = true;
            this.ResultsClear.Click += new System.EventHandler(this.ResultsClear_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Black;
            this.panel2.Controls.Add(this.TimeBetweenEvents);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.TimeBetweenItterations);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(12, 12);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(193, 350);
            this.panel2.TabIndex = 11;
            // 
            // TimeBetweenEvents
            // 
            this.TimeBetweenEvents.Location = new System.Drawing.Point(17, 137);
            this.TimeBetweenEvents.Name = "TimeBetweenEvents";
            this.TimeBetweenEvents.Size = new System.Drawing.Size(159, 20);
            this.TimeBetweenEvents.TabIndex = 7;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(17, 114);
            this.label10.Name = "label10";
            this.label10.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label10.Size = new System.Drawing.Size(162, 20);
            this.label10.TabIndex = 6;
            this.label10.Text = "Time between events";
            this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // TimeBetweenItterations
            // 
            this.TimeBetweenItterations.Location = new System.Drawing.Point(17, 82);
            this.TimeBetweenItterations.Name = "TimeBetweenItterations";
            this.TimeBetweenItterations.Size = new System.Drawing.Size(159, 20);
            this.TimeBetweenItterations.TabIndex = 5;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(17, 59);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(162, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "Time between itterations (s)";
            this.label9.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(56, 318);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(35, 13);
            this.label8.TabIndex = 3;
            this.label8.Text = "label8";
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(17, 251);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(162, 77);
            this.label7.TabIndex = 2;
            this.label7.Text = "\"\\\" pause active program, or create new event at mouse position   \r\n\r\n\"`\" kill th" +
    "e current program\r\n";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(17, 210);
            this.label6.Name = "label6";
            this.label6.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label6.Size = new System.Drawing.Size(85, 25);
            this.label6.TabIndex = 1;
            this.label6.Text = "Controls";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(17, 16);
            this.label5.Name = "label5";
            this.label5.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label5.Size = new System.Drawing.Size(157, 25);
            this.label5.TabIndex = 0;
            this.label5.Text = "General Settings";
            this.label5.Click += new System.EventHandler(this.label5_Click);
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(151, 415);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(54, 23);
            this.button6.TabIndex = 12;
            this.button6.Text = "Skip";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.DimGray;
            this.ClientSize = new System.Drawing.Size(1007, 450);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.ResultsClear);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Itterations);
            this.Controls.Add(this.ItterationCounter);
            this.Controls.Add(this.MousePositionIndicator);
            this.Controls.Add(this.EditPannel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            this.EditPannel.ResumeLayout(false);
            this.EditPannel.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel ElementsContainer;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel EditPannel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox TaskTypeList;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.FlowLayoutPanel UniqueSettingsPanel;
        private System.Windows.Forms.Button SaveBTN;
        private System.Windows.Forms.Label MousePositionIndicator;
        private System.Windows.Forms.TextBox ItterationCounter;
        private System.Windows.Forms.Label Itterations;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button ResultsClear;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TimeBetweenEvents;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox TimeBetweenItterations;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button6;
    }
}

