namespace DroneUI
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonModeGPS = new System.Windows.Forms.Button();
            this.buttonModeIR = new System.Windows.Forms.Button();
            this.buttonModeFlappy = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timerIRDraw = new System.Windows.Forms.Timer(this.components);
            this.motorControl4 = new DroneUI.MotorControl();
            this.motorControl3 = new DroneUI.MotorControl();
            this.motorControl2 = new DroneUI.MotorControl();
            this.motorControl1 = new DroneUI.MotorControl();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelFPS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(206, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(370, 370);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(116, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Connect";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBoxLog
            // 
            this.textBoxLog.Location = new System.Drawing.Point(582, 243);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLog.Size = new System.Drawing.Size(436, 370);
            this.textBoxLog.TabIndex = 7;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.buttonModeGPS);
            this.panel1.Controls.Add(this.buttonModeIR);
            this.panel1.Controls.Add(this.buttonModeFlappy);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(1028, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(183, 124);
            this.panel1.TabIndex = 8;
            // 
            // buttonModeGPS
            // 
            this.buttonModeGPS.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModeGPS.Location = new System.Drawing.Point(3, 93);
            this.buttonModeGPS.Name = "buttonModeGPS";
            this.buttonModeGPS.Size = new System.Drawing.Size(175, 26);
            this.buttonModeGPS.TabIndex = 3;
            this.buttonModeGPS.Text = "GPS mode";
            this.buttonModeGPS.UseVisualStyleBackColor = true;
            this.buttonModeGPS.Click += new System.EventHandler(this.buttonModeGPS_Click);
            // 
            // buttonModeIR
            // 
            this.buttonModeIR.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModeIR.ForeColor = System.Drawing.Color.Black;
            this.buttonModeIR.Location = new System.Drawing.Point(3, 65);
            this.buttonModeIR.Name = "buttonModeIR";
            this.buttonModeIR.Size = new System.Drawing.Size(175, 26);
            this.buttonModeIR.TabIndex = 2;
            this.buttonModeIR.Text = "IR follower";
            this.buttonModeIR.UseVisualStyleBackColor = true;
            this.buttonModeIR.Click += new System.EventHandler(this.buttonModeIR_Click);
            // 
            // buttonModeFlappy
            // 
            this.buttonModeFlappy.BackColor = System.Drawing.Color.Lime;
            this.buttonModeFlappy.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonModeFlappy.Location = new System.Drawing.Point(3, 37);
            this.buttonModeFlappy.Name = "buttonModeFlappy";
            this.buttonModeFlappy.Size = new System.Drawing.Size(175, 26);
            this.buttonModeFlappy.TabIndex = 1;
            this.buttonModeFlappy.Text = "Flappy bird";
            this.buttonModeFlappy.UseVisualStyleBackColor = false;
            this.buttonModeFlappy.Click += new System.EventHandler(this.buttonModeFlappy_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(49, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(81, 32);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mode";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 124);
            this.panel2.TabIndex = 9;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(23, 29);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(133, 25);
            this.checkBox1.TabIndex = 10;
            this.checkBox1.Text = "Log everything";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(3, 5);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(35, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Port:";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(38, 4);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(72, 21);
            this.comboBox1.TabIndex = 10;
            // 
            // timerIRDraw
            // 
            this.timerIRDraw.Enabled = true;
            this.timerIRDraw.Interval = 50;
            this.timerIRDraw.Tick += new System.EventHandler(this.timerIRDraw_Tick);
            // 
            // motorControl4
            // 
            this.motorControl4.Location = new System.Drawing.Point(1024, 378);
            this.motorControl4.Name = "motorControl4";
            this.motorControl4.Size = new System.Drawing.Size(188, 235);
            this.motorControl4.TabIndex = 6;
            // 
            // motorControl3
            // 
            this.motorControl3.Location = new System.Drawing.Point(12, 378);
            this.motorControl3.Name = "motorControl3";
            this.motorControl3.Size = new System.Drawing.Size(188, 235);
            this.motorControl3.TabIndex = 5;
            // 
            // motorControl2
            // 
            this.motorControl2.Location = new System.Drawing.Point(1024, 12);
            this.motorControl2.Name = "motorControl2";
            this.motorControl2.Size = new System.Drawing.Size(188, 235);
            this.motorControl2.TabIndex = 4;
            // 
            // motorControl1
            // 
            this.motorControl1.Location = new System.Drawing.Point(12, 12);
            this.motorControl1.Name = "motorControl1";
            this.motorControl1.Size = new System.Drawing.Size(188, 235);
            this.motorControl1.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.trackBar1);
            this.panel3.Controls.Add(this.labelFPS);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Location = new System.Drawing.Point(206, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(812, 225);
            this.panel3.TabIndex = 10;
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFPS.Location = new System.Drawing.Point(45, 5);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(36, 21);
            this.labelFPS.TabIndex = 1;
            this.labelFPS.Text = "- - -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 5);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "FPS:";
            // 
            // timerUpdateUI
            // 
            this.timerUpdateUI.Enabled = true;
            this.timerUpdateUI.Interval = 1000;
            this.timerUpdateUI.Tick += new System.EventHandler(this.timerUpdateUI_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(143, 93);
            this.trackBar1.Maximum = 1000;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(517, 45);
            this.trackBar1.TabIndex = 2;
            this.trackBar1.TickFrequency = 100;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1224, 625);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.textBoxLog);
            this.Controls.Add(this.motorControl4);
            this.Controls.Add(this.motorControl3);
            this.Controls.Add(this.motorControl2);
            this.Controls.Add(this.motorControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private MotorControl motorControl1;
        private MotorControl motorControl2;
        private MotorControl motorControl3;
        private MotorControl motorControl4;
        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonModeGPS;
        private System.Windows.Forms.Button buttonModeIR;
        private System.Windows.Forms.Button buttonModeFlappy;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Timer timerIRDraw;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label labelFPS;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Timer timerUpdateUI;
        private System.Windows.Forms.TrackBar trackBar1;
    }
}

