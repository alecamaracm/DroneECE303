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
            this.button2 = new System.Windows.Forms.Button();
            this.buttonStartXBOX = new System.Windows.Forms.Button();
            this.buttonReloadSerial = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.timerIRDraw = new System.Windows.Forms.Timer(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.label19 = new System.Windows.Forms.Label();
            this.numericUpDownKI = new System.Windows.Forms.NumericUpDown();
            this.button5 = new System.Windows.Forms.Button();
            this.labelCalMagnet = new System.Windows.Forms.Label();
            this.labelCalAccel = new System.Windows.Forms.Label();
            this.labelCalGyro = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.label25 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.numericUpDownkD = new System.Windows.Forms.NumericUpDown();
            this.label12 = new System.Windows.Forms.Label();
            this.numericUpDownkP = new System.Windows.Forms.NumericUpDown();
            this.label5VAmps = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.labelErrorsDrone = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.labelErrorsPC = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.labelDownloadSpeed = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.labelUploadSpeed = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.currentYawV = new System.Windows.Forms.Label();
            this.currentRollV = new System.Windows.Forms.Label();
            this.currentPitchV = new System.Windows.Forms.Label();
            this.goalYaw = new System.Windows.Forms.Label();
            this.goalRoll = new System.Windows.Forms.Label();
            this.goalPitch = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownFPSGoal = new System.Windows.Forms.NumericUpDown();
            this.button3 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.labelMainVolts = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.trackBarThrottle = new System.Windows.Forms.TrackBar();
            this.labelFPS = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.timerUpdateUI = new System.Windows.Forms.Timer(this.components);
            this.inputSendTimer = new System.Windows.Forms.Timer(this.components);
            this.inputAdquireTimer = new System.Windows.Forms.Timer(this.components);
            this.motorControl4 = new DroneUI.MotorControl();
            this.motorControl2 = new DroneUI.MotorControl();
            this.motorControl3 = new DroneUI.MotorControl();
            this.motorControl1 = new DroneUI.MotorControl();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownkD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownkP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPSGoal)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThrottle)).BeginInit();
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
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.buttonStartXBOX);
            this.panel2.Controls.Add(this.buttonReloadSerial);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 248);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(183, 124);
            this.panel2.TabIndex = 9;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.DarkSalmon;
            this.button2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(100, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(76, 23);
            this.button2.TabIndex = 13;
            this.button2.Text = "Disconnect";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // buttonStartXBOX
            // 
            this.buttonStartXBOX.BackColor = System.Drawing.Color.LightGreen;
            this.buttonStartXBOX.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStartXBOX.Location = new System.Drawing.Point(57, 59);
            this.buttonStartXBOX.Name = "buttonStartXBOX";
            this.buttonStartXBOX.Size = new System.Drawing.Size(76, 23);
            this.buttonStartXBOX.TabIndex = 12;
            this.buttonStartXBOX.Text = "Start XBOX";
            this.buttonStartXBOX.UseVisualStyleBackColor = false;
            this.buttonStartXBOX.Click += new System.EventHandler(this.buttonStartXBOX_Click);
            // 
            // buttonReloadSerial
            // 
            this.buttonReloadSerial.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonReloadSerial.Location = new System.Drawing.Point(9, 30);
            this.buttonReloadSerial.Name = "buttonReloadSerial";
            this.buttonReloadSerial.Size = new System.Drawing.Size(85, 23);
            this.buttonReloadSerial.TabIndex = 11;
            this.buttonReloadSerial.Text = "Reload ports";
            this.buttonReloadSerial.UseVisualStyleBackColor = true;
            this.buttonReloadSerial.Click += new System.EventHandler(this.buttonReloadSerial_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(23, 93);
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
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.numericUpDownKI);
            this.panel3.Controls.Add(this.button5);
            this.panel3.Controls.Add(this.labelCalMagnet);
            this.panel3.Controls.Add(this.labelCalAccel);
            this.panel3.Controls.Add(this.labelCalGyro);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.label23);
            this.panel3.Controls.Add(this.label24);
            this.panel3.Controls.Add(this.label25);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.numericUpDownkD);
            this.panel3.Controls.Add(this.label12);
            this.panel3.Controls.Add(this.numericUpDownkP);
            this.panel3.Controls.Add(this.label5VAmps);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.labelErrorsDrone);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.labelErrorsPC);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.labelDownloadSpeed);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.labelUploadSpeed);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.currentYawV);
            this.panel3.Controls.Add(this.currentRollV);
            this.panel3.Controls.Add(this.currentPitchV);
            this.panel3.Controls.Add(this.goalYaw);
            this.panel3.Controls.Add(this.goalRoll);
            this.panel3.Controls.Add(this.goalPitch);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.numericUpDownFPSGoal);
            this.panel3.Controls.Add(this.button3);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.button4);
            this.panel3.Controls.Add(this.labelMainVolts);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.trackBarThrottle);
            this.panel3.Controls.Add(this.labelFPS);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel3.Location = new System.Drawing.Point(206, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(812, 225);
            this.panel3.TabIndex = 10;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.MediumPurple;
            this.button6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.Location = new System.Drawing.Point(117, 111);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(98, 23);
            this.button6.TabIndex = 53;
            this.button6.Text = "Reset I";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(548, 185);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(25, 21);
            this.label19.TabIndex = 52;
            this.label19.Text = "kI:";
            // 
            // numericUpDownKI
            // 
            this.numericUpDownKI.DecimalPlaces = 3;
            this.numericUpDownKI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownKI.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownKI.Location = new System.Drawing.Point(574, 186);
            this.numericUpDownKI.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownKI.Name = "numericUpDownKI";
            this.numericUpDownKI.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownKI.TabIndex = 51;
            this.numericUpDownKI.Value = new decimal(new int[] {
            5,
            0,
            0,
            196608});
            this.numericUpDownKI.ValueChanged += new System.EventHandler(this.numericUpDownKI_ValueChanged);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Orchid;
            this.button5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(12, 111);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 23);
            this.button5.TabIndex = 50;
            this.button5.Text = "Set offsets";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // labelCalMagnet
            // 
            this.labelCalMagnet.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCalMagnet.Location = new System.Drawing.Point(421, 197);
            this.labelCalMagnet.Name = "labelCalMagnet";
            this.labelCalMagnet.Size = new System.Drawing.Size(44, 23);
            this.labelCalMagnet.TabIndex = 49;
            this.labelCalMagnet.Text = "- - -";
            this.labelCalMagnet.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCalAccel
            // 
            this.labelCalAccel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCalAccel.Location = new System.Drawing.Point(370, 197);
            this.labelCalAccel.Name = "labelCalAccel";
            this.labelCalAccel.Size = new System.Drawing.Size(44, 23);
            this.labelCalAccel.TabIndex = 48;
            this.labelCalAccel.Text = "- - -";
            this.labelCalAccel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelCalGyro
            // 
            this.labelCalGyro.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelCalGyro.Location = new System.Drawing.Point(321, 197);
            this.labelCalGyro.Name = "labelCalGyro";
            this.labelCalGyro.Size = new System.Drawing.Size(44, 23);
            this.labelCalGyro.TabIndex = 47;
            this.labelCalGyro.Text = "- - -";
            this.labelCalGyro.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(417, 173);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(55, 17);
            this.label22.TabIndex = 46;
            this.label22.Text = "Magnet";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.Location = new System.Drawing.Point(371, 173);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(40, 17);
            this.label23.TabIndex = 45;
            this.label23.Text = "Accel";
            // 
            // label24
            // 
            this.label24.AutoSize = true;
            this.label24.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(323, 173);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(37, 17);
            this.label24.TabIndex = 44;
            this.label24.Text = "Gyro";
            // 
            // label25
            // 
            this.label25.AutoSize = true;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(248, 196);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(75, 16);
            this.label25.TabIndex = 43;
            this.label25.Text = "Calibration:";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(544, 159);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(32, 21);
            this.label18.TabIndex = 42;
            this.label18.Text = "kD:";
            // 
            // numericUpDownkD
            // 
            this.numericUpDownkD.DecimalPlaces = 3;
            this.numericUpDownkD.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownkD.Increment = new decimal(new int[] {
            1,
            0,
            0,
            196608});
            this.numericUpDownkD.Location = new System.Drawing.Point(574, 160);
            this.numericUpDownkD.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownkD.Name = "numericUpDownkD";
            this.numericUpDownkD.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownkD.TabIndex = 41;
            this.numericUpDownkD.Value = new decimal(new int[] {
            5,
            0,
            0,
            131072});
            this.numericUpDownkD.ValueChanged += new System.EventHandler(this.numericUpDownkD_ValueChanged);
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.Location = new System.Drawing.Point(545, 133);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 21);
            this.label12.TabIndex = 40;
            this.label12.Text = "kP:";
            // 
            // numericUpDownkP
            // 
            this.numericUpDownkP.DecimalPlaces = 2;
            this.numericUpDownkP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownkP.Increment = new decimal(new int[] {
            1,
            0,
            0,
            131072});
            this.numericUpDownkP.Location = new System.Drawing.Point(575, 134);
            this.numericUpDownkP.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            -2147483648});
            this.numericUpDownkP.Name = "numericUpDownkP";
            this.numericUpDownkP.Size = new System.Drawing.Size(58, 20);
            this.numericUpDownkP.TabIndex = 39;
            this.numericUpDownkP.Value = new decimal(new int[] {
            2,
            0,
            0,
            65536});
            this.numericUpDownkP.ValueChanged += new System.EventHandler(this.numericUpDownkP_ValueChanged);
            // 
            // label5VAmps
            // 
            this.label5VAmps.AutoSize = true;
            this.label5VAmps.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5VAmps.Location = new System.Drawing.Point(82, 73);
            this.label5VAmps.Name = "label5VAmps";
            this.label5VAmps.Size = new System.Drawing.Size(36, 21);
            this.label5VAmps.TabIndex = 38;
            this.label5VAmps.Text = "- - -";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(8, 73);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(74, 21);
            this.label16.TabIndex = 37;
            this.label16.Text = "5V amps:";
            // 
            // labelErrorsDrone
            // 
            this.labelErrorsDrone.AutoSize = true;
            this.labelErrorsDrone.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorsDrone.ForeColor = System.Drawing.Color.Tomato;
            this.labelErrorsDrone.Location = new System.Drawing.Point(363, 81);
            this.labelErrorsDrone.Name = "labelErrorsDrone";
            this.labelErrorsDrone.Size = new System.Drawing.Size(31, 17);
            this.labelErrorsDrone.TabIndex = 36;
            this.labelErrorsDrone.Text = "- - -";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.Brown;
            this.label14.Location = new System.Drawing.Point(234, 81);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(126, 17);
            this.label14.TabIndex = 35;
            this.label14.Text = "Serial drone errors:";
            // 
            // labelErrorsPC
            // 
            this.labelErrorsPC.AutoSize = true;
            this.labelErrorsPC.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelErrorsPC.ForeColor = System.Drawing.Color.Tomato;
            this.labelErrorsPC.Location = new System.Drawing.Point(363, 60);
            this.labelErrorsPC.Name = "labelErrorsPC";
            this.labelErrorsPC.Size = new System.Drawing.Size(31, 17);
            this.labelErrorsPC.TabIndex = 34;
            this.labelErrorsPC.Text = "- - -";
            this.labelErrorsPC.Click += new System.EventHandler(this.labelErrorsPC_Click);
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Font = new System.Drawing.Font("Segoe UI", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Brown;
            this.label17.Location = new System.Drawing.Point(254, 61);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(106, 17);
            this.label17.TabIndex = 33;
            this.label17.Text = "Serial PC errors:";
            // 
            // labelDownloadSpeed
            // 
            this.labelDownloadSpeed.AutoSize = true;
            this.labelDownloadSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelDownloadSpeed.Location = new System.Drawing.Point(368, 31);
            this.labelDownloadSpeed.Name = "labelDownloadSpeed";
            this.labelDownloadSpeed.Size = new System.Drawing.Size(36, 21);
            this.labelDownloadSpeed.TabIndex = 32;
            this.labelDownloadSpeed.Text = "- - -";
            this.labelDownloadSpeed.Click += new System.EventHandler(this.label14_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.Location = new System.Drawing.Point(233, 31);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(129, 21);
            this.label15.TabIndex = 31;
            this.label15.Text = "Download speed:";
            // 
            // labelUploadSpeed
            // 
            this.labelUploadSpeed.AutoSize = true;
            this.labelUploadSpeed.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelUploadSpeed.Location = new System.Drawing.Point(368, 7);
            this.labelUploadSpeed.Name = "labelUploadSpeed";
            this.labelUploadSpeed.Size = new System.Drawing.Size(36, 21);
            this.labelUploadSpeed.TabIndex = 30;
            this.labelUploadSpeed.Text = "- - -";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(254, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 21);
            this.label13.TabIndex = 29;
            this.label13.Text = "Upload speed:";
            // 
            // currentYawV
            // 
            this.currentYawV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentYawV.Location = new System.Drawing.Point(171, 196);
            this.currentYawV.Name = "currentYawV";
            this.currentYawV.Size = new System.Drawing.Size(44, 23);
            this.currentYawV.TabIndex = 28;
            this.currentYawV.Text = "- - -";
            this.currentYawV.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currentRollV
            // 
            this.currentRollV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentRollV.Location = new System.Drawing.Point(120, 196);
            this.currentRollV.Name = "currentRollV";
            this.currentRollV.Size = new System.Drawing.Size(44, 23);
            this.currentRollV.TabIndex = 27;
            this.currentRollV.Text = "- - -";
            this.currentRollV.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // currentPitchV
            // 
            this.currentPitchV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPitchV.Location = new System.Drawing.Point(71, 196);
            this.currentPitchV.Name = "currentPitchV";
            this.currentPitchV.Size = new System.Drawing.Size(44, 23);
            this.currentPitchV.TabIndex = 26;
            this.currentPitchV.Text = "- - -";
            this.currentPitchV.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // goalYaw
            // 
            this.goalYaw.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalYaw.Location = new System.Drawing.Point(171, 171);
            this.goalYaw.Name = "goalYaw";
            this.goalYaw.Size = new System.Drawing.Size(44, 23);
            this.goalYaw.TabIndex = 25;
            this.goalYaw.Text = "- - -";
            this.goalYaw.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // goalRoll
            // 
            this.goalRoll.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalRoll.Location = new System.Drawing.Point(120, 171);
            this.goalRoll.Name = "goalRoll";
            this.goalRoll.Size = new System.Drawing.Size(44, 23);
            this.goalRoll.TabIndex = 24;
            this.goalRoll.Text = "- - -";
            this.goalRoll.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // goalPitch
            // 
            this.goalPitch.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.goalPitch.Location = new System.Drawing.Point(71, 171);
            this.goalPitch.Name = "goalPitch";
            this.goalPitch.Size = new System.Drawing.Size(44, 23);
            this.goalPitch.TabIndex = 23;
            this.goalPitch.Text = "- - -";
            this.goalPitch.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(176, 147);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 17);
            this.label11.TabIndex = 22;
            this.label11.Text = "Yaw";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(127, 147);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(32, 17);
            this.label10.TabIndex = 21;
            this.label10.Text = "Roll";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(73, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(39, 17);
            this.label9.TabIndex = 20;
            this.label9.Text = "Pitch";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(11, 195);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(53, 16);
            this.label8.TabIndex = 19;
            this.label8.Text = "Current:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(11, 170);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(40, 16);
            this.label7.TabIndex = 18;
            this.label7.Text = "Goal:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(605, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 21);
            this.label6.TabIndex = 17;
            this.label6.Text = "FPS goal:";
            // 
            // numericUpDownFPSGoal
            // 
            this.numericUpDownFPSGoal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numericUpDownFPSGoal.Location = new System.Drawing.Point(684, 10);
            this.numericUpDownFPSGoal.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.numericUpDownFPSGoal.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numericUpDownFPSGoal.Name = "numericUpDownFPSGoal";
            this.numericUpDownFPSGoal.Size = new System.Drawing.Size(64, 23);
            this.numericUpDownFPSGoal.TabIndex = 16;
            this.numericUpDownFPSGoal.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.numericUpDownFPSGoal.ValueChanged += new System.EventHandler(this.numericUpDownFPSGoal_ValueChanged);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.DarkSalmon;
            this.button3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(650, 194);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(98, 23);
            this.button3.TabIndex = 15;
            this.button3.Text = "Disable motors";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(755, 200);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 5;
            this.label4.Text = "Throttle";
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.DeepSkyBlue;
            this.button4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(650, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(98, 23);
            this.button4.TabIndex = 14;
            this.button4.Text = "Enable motors";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // labelMainVolts
            // 
            this.labelMainVolts.AutoSize = true;
            this.labelMainVolts.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMainVolts.Location = new System.Drawing.Point(111, 47);
            this.labelMainVolts.Name = "labelMainVolts";
            this.labelMainVolts.Size = new System.Drawing.Size(36, 21);
            this.labelMainVolts.TabIndex = 4;
            this.labelMainVolts.Text = "- - -";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(7, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(103, 21);
            this.label5.TabIndex = 3;
            this.label5.Text = "Main voltage:";
            // 
            // trackBarThrottle
            // 
            this.trackBarThrottle.Location = new System.Drawing.Point(768, 5);
            this.trackBarThrottle.Maximum = 100;
            this.trackBarThrottle.Name = "trackBarThrottle";
            this.trackBarThrottle.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBarThrottle.Size = new System.Drawing.Size(45, 191);
            this.trackBarThrottle.TabIndex = 2;
            this.trackBarThrottle.TickFrequency = 10;
            this.trackBarThrottle.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // labelFPS
            // 
            this.labelFPS.AutoSize = true;
            this.labelFPS.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelFPS.Location = new System.Drawing.Point(45, 8);
            this.labelFPS.Name = "labelFPS";
            this.labelFPS.Size = new System.Drawing.Size(36, 21);
            this.labelFPS.TabIndex = 1;
            this.labelFPS.Text = "- - -";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(7, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(39, 21);
            this.label3.TabIndex = 0;
            this.label3.Text = "FPS:";
            // 
            // timerUpdateUI
            // 
            this.timerUpdateUI.Enabled = true;
            this.timerUpdateUI.Tick += new System.EventHandler(this.timerUpdateUI_Tick);
            // 
            // inputSendTimer
            // 
            this.inputSendTimer.Enabled = true;
            this.inputSendTimer.Interval = 20;
            this.inputSendTimer.Tick += new System.EventHandler(this.inputSendTimer_Tick);
            // 
            // inputAdquireTimer
            // 
            this.inputAdquireTimer.Enabled = true;
            this.inputAdquireTimer.Interval = 50;
            this.inputAdquireTimer.Tick += new System.EventHandler(this.inputAdquireTimer_Tick);
            // 
            // motorControl4
            // 
            this.motorControl4.Location = new System.Drawing.Point(1024, 378);
            this.motorControl4.motorID = 3;
            this.motorControl4.Name = "motorControl4";
            this.motorControl4.Size = new System.Drawing.Size(188, 235);
            this.motorControl4.TabIndex = 6;
            // 
            // motorControl2
            // 
            this.motorControl2.Location = new System.Drawing.Point(12, 378);
            this.motorControl2.motorID = 1;
            this.motorControl2.Name = "motorControl2";
            this.motorControl2.Size = new System.Drawing.Size(188, 235);
            this.motorControl2.TabIndex = 5;
            // 
            // motorControl3
            // 
            this.motorControl3.Location = new System.Drawing.Point(1024, 12);
            this.motorControl3.motorID = 2;
            this.motorControl3.Name = "motorControl3";
            this.motorControl3.Size = new System.Drawing.Size(188, 235);
            this.motorControl3.TabIndex = 4;
            // 
            // motorControl1
            // 
            this.motorControl1.Location = new System.Drawing.Point(12, 12);
            this.motorControl1.motorID = 0;
            this.motorControl1.Name = "motorControl1";
            this.motorControl1.Size = new System.Drawing.Size(188, 235);
            this.motorControl1.TabIndex = 3;
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
            this.Controls.Add(this.motorControl2);
            this.Controls.Add(this.motorControl3);
            this.Controls.Add(this.motorControl1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "ECE303 - Drone project";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownKI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownkD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownkP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownFPSGoal)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarThrottle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private MotorControl motorControl1;
        private MotorControl motorControl3;
        private MotorControl motorControl2;
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
        private System.Windows.Forms.TrackBar trackBarThrottle;
        private System.Windows.Forms.Timer inputSendTimer;
        private System.Windows.Forms.Timer inputAdquireTimer;
        private System.Windows.Forms.Button buttonStartXBOX;
        private System.Windows.Forms.Button buttonReloadSerial;
        private System.Windows.Forms.Label labelMainVolts;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownFPSGoal;
        private System.Windows.Forms.Label currentYawV;
        private System.Windows.Forms.Label currentRollV;
        private System.Windows.Forms.Label currentPitchV;
        private System.Windows.Forms.Label goalYaw;
        private System.Windows.Forms.Label goalRoll;
        private System.Windows.Forms.Label goalPitch;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelDownloadSpeed;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label labelUploadSpeed;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label labelErrorsDrone;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label labelErrorsPC;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label5VAmps;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.NumericUpDown numericUpDownkD;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.NumericUpDown numericUpDownkP;
        private System.Windows.Forms.Label labelCalMagnet;
        private System.Windows.Forms.Label labelCalAccel;
        private System.Windows.Forms.Label labelCalGyro;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.NumericUpDown numericUpDownKI;
        private System.Windows.Forms.Button button6;
    }
}

