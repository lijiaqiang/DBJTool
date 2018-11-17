namespace _3G_DownloadTool
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.StartBtn = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.logTb = new System.Windows.Forms.TextBox();
            this.downloadPBar = new System.Windows.Forms.ProgressBar();
            this.label4 = new System.Windows.Forms.Label();
            this.TestBtn = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.lab15 = new System.Windows.Forms.Label();
            this.Lab7 = new System.Windows.Forms.Label();
            this.Lab14 = new System.Windows.Forms.Label();
            this.Lab6 = new System.Windows.Forms.Label();
            this.Lab13 = new System.Windows.Forms.Label();
            this.Lab5 = new System.Windows.Forms.Label();
            this.Lab12 = new System.Windows.Forms.Label();
            this.Lab4 = new System.Windows.Forms.Label();
            this.Lab11 = new System.Windows.Forms.Label();
            this.Lab3 = new System.Windows.Forms.Label();
            this.Lab10 = new System.Windows.Forms.Label();
            this.Lab2 = new System.Windows.Forms.Label();
            this.Lab9 = new System.Windows.Forms.Label();
            this.Lab8 = new System.Windows.Forms.Label();
            this.Lab1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timerLab = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // StartBtn
            // 
            this.StartBtn.BackColor = System.Drawing.Color.DarkGreen;
            this.StartBtn.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.StartBtn.Location = new System.Drawing.Point(25, 12);
            this.StartBtn.Name = "StartBtn";
            this.StartBtn.Size = new System.Drawing.Size(545, 68);
            this.StartBtn.TabIndex = 2;
            this.StartBtn.Text = "开始";
            this.StartBtn.UseVisualStyleBackColor = false;
            this.StartBtn.Click += new System.EventHandler(this.StartBtn_Click_1);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Brown;
            this.button3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button3.Location = new System.Drawing.Point(702, 12);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(97, 68);
            this.button3.TabIndex = 3;
            this.button3.Text = "结束";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(22, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 24);
            this.label2.TabIndex = 5;
            this.label2.Text = "Download:";
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("宋体", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(21, 205);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 51);
            this.label3.TabIndex = 6;
            this.label3.Text = "Log:";
            // 
            // logTb
            // 
            this.logTb.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.logTb.Location = new System.Drawing.Point(119, 205);
            this.logTb.Multiline = true;
            this.logTb.Name = "logTb";
            this.logTb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.logTb.Size = new System.Drawing.Size(680, 140);
            this.logTb.TabIndex = 8;
            // 
            // downloadPBar
            // 
            this.downloadPBar.Location = new System.Drawing.Point(118, 86);
            this.downloadPBar.Name = "downloadPBar";
            this.downloadPBar.Size = new System.Drawing.Size(680, 17);
            this.downloadPBar.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Yellow;
            this.label4.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label4.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(25, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(83, 78);
            this.label4.TabIndex = 11;
            this.label4.Text = "测试\r\n项目";
            // 
            // TestBtn
            // 
            this.TestBtn.BackColor = System.Drawing.Color.Peru;
            this.TestBtn.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.TestBtn.Location = new System.Drawing.Point(580, 12);
            this.TestBtn.Name = "TestBtn";
            this.TestBtn.Size = new System.Drawing.Size(109, 68);
            this.TestBtn.TabIndex = 28;
            this.TestBtn.Text = "重新测试";
            this.TestBtn.UseVisualStyleBackColor = false;
            this.TestBtn.Click += new System.EventHandler(this.TestBtn_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DtrEnable = true;
            // 
            // lab15
            // 
            this.lab15.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lab15.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lab15.Location = new System.Drawing.Point(696, 114);
            this.lab15.Name = "lab15";
            this.lab15.Size = new System.Drawing.Size(103, 78);
            this.lab15.TabIndex = 31;
            this.lab15.Text = "开始测试";
            this.lab15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab7
            // 
            this.Lab7.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab7.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab7.Location = new System.Drawing.Point(576, 114);
            this.Lab7.Name = "Lab7";
            this.Lab7.Size = new System.Drawing.Size(113, 33);
            this.Lab7.TabIndex = 32;
            this.Lab7.Text = "按下按键";
            this.Lab7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab14
            // 
            this.Lab14.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab14.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab14.Location = new System.Drawing.Point(576, 154);
            this.Lab14.Name = "Lab14";
            this.Lab14.Size = new System.Drawing.Size(113, 38);
            this.Lab14.TabIndex = 33;
            this.Lab14.Text = "蓝牙芯片";
            this.Lab14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab6
            // 
            this.Lab6.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab6.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab6.Location = new System.Drawing.Point(497, 114);
            this.Lab6.Name = "Lab6";
            this.Lab6.Size = new System.Drawing.Size(73, 33);
            this.Lab6.TabIndex = 34;
            this.Lab6.Text = "ACCEL";
            this.Lab6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab13
            // 
            this.Lab13.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab13.Font = new System.Drawing.Font("宋体", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab13.Location = new System.Drawing.Point(497, 154);
            this.Lab13.Name = "Lab13";
            this.Lab13.Size = new System.Drawing.Size(73, 38);
            this.Lab13.TabIndex = 35;
            this.Lab13.Text = "3G信号";
            this.Lab13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab5
            // 
            this.Lab5.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab5.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab5.Location = new System.Drawing.Point(432, 114);
            this.Lab5.Name = "Lab5";
            this.Lab5.Size = new System.Drawing.Size(59, 33);
            this.Lab5.TabIndex = 36;
            this.Lab5.Text = "KEY";
            this.Lab5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab12
            // 
            this.Lab12.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab12.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab12.Location = new System.Drawing.Point(432, 154);
            this.Lab12.Name = "Lab12";
            this.Lab12.Size = new System.Drawing.Size(59, 38);
            this.Lab12.TabIndex = 37;
            this.Lab12.Text = "SIM";
            this.Lab12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab4
            // 
            this.Lab4.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab4.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab4.Location = new System.Drawing.Point(362, 114);
            this.Lab4.Name = "Lab4";
            this.Lab4.Size = new System.Drawing.Size(64, 33);
            this.Lab4.TabIndex = 38;
            this.Lab4.Text = "充电";
            this.Lab4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab11
            // 
            this.Lab11.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab11.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab11.Location = new System.Drawing.Point(362, 154);
            this.Lab11.Name = "Lab11";
            this.Lab11.Size = new System.Drawing.Size(64, 38);
            this.Lab11.TabIndex = 39;
            this.Lab11.Text = "IGN";
            this.Lab11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab3
            // 
            this.Lab3.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab3.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab3.Location = new System.Drawing.Point(289, 114);
            this.Lab3.Name = "Lab3";
            this.Lab3.Size = new System.Drawing.Size(66, 33);
            this.Lab3.TabIndex = 40;
            this.Lab3.Text = "温度";
            this.Lab3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab10
            // 
            this.Lab10.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab10.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab10.Location = new System.Drawing.Point(289, 154);
            this.Lab10.Name = "Lab10";
            this.Lab10.Size = new System.Drawing.Size(67, 38);
            this.Lab10.TabIndex = 41;
            this.Lab10.Text = "GPS";
            this.Lab10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab2
            // 
            this.Lab2.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab2.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab2.Location = new System.Drawing.Point(210, 114);
            this.Lab2.Name = "Lab2";
            this.Lab2.Size = new System.Drawing.Size(73, 33);
            this.Lab2.TabIndex = 42;
            this.Lab2.Text = "模组";
            this.Lab2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab9
            // 
            this.Lab9.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab9.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab9.Location = new System.Drawing.Point(210, 154);
            this.Lab9.Name = "Lab9";
            this.Lab9.Size = new System.Drawing.Size(73, 38);
            this.Lab9.TabIndex = 43;
            this.Lab9.Text = "ADC";
            this.Lab9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab8
            // 
            this.Lab8.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab8.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab8.Location = new System.Drawing.Point(119, 154);
            this.Lab8.Name = "Lab8";
            this.Lab8.Size = new System.Drawing.Size(85, 38);
            this.Lab8.TabIndex = 44;
            this.Lab8.Text = "DOOR";
            this.Lab8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Lab1
            // 
            this.Lab1.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.Lab1.Font = new System.Drawing.Font("宋体", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.Lab1.Location = new System.Drawing.Point(119, 114);
            this.Lab1.Name = "Lab1";
            this.Lab1.Size = new System.Drawing.Size(85, 33);
            this.Lab1.TabIndex = 45;
            this.Lab1.Text = "版本号";
            this.Lab1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timerLab
            // 
            this.timerLab.AutoSize = true;
            this.timerLab.Font = new System.Drawing.Font("宋体", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.timerLab.Location = new System.Drawing.Point(12, 265);
            this.timerLab.Name = "timerLab";
            this.timerLab.Size = new System.Drawing.Size(93, 29);
            this.timerLab.TabIndex = 46;
            this.timerLab.Text = "00:00";
            this.timerLab.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(859, 351);
            this.Controls.Add(this.timerLab);
            this.Controls.Add(this.Lab1);
            this.Controls.Add(this.Lab8);
            this.Controls.Add(this.Lab9);
            this.Controls.Add(this.Lab2);
            this.Controls.Add(this.Lab10);
            this.Controls.Add(this.Lab3);
            this.Controls.Add(this.Lab11);
            this.Controls.Add(this.Lab4);
            this.Controls.Add(this.Lab12);
            this.Controls.Add(this.Lab5);
            this.Controls.Add(this.Lab13);
            this.Controls.Add(this.Lab6);
            this.Controls.Add(this.Lab14);
            this.Controls.Add(this.Lab7);
            this.Controls.Add(this.lab15);
            this.Controls.Add(this.TestBtn);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.downloadPBar);
            this.Controls.Add(this.logTb);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.StartBtn);
            this.Name = "Form1";
            this.Text = "3G download Tool";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button StartBtn;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox logTb;
        private System.Windows.Forms.ProgressBar downloadPBar;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button TestBtn;
        private System.IO.Ports.SerialPort serialPort1;
        public System.Windows.Forms.Label lab15;
        public System.Windows.Forms.Label Lab7;
        public System.Windows.Forms.Label Lab14;
        public System.Windows.Forms.Label Lab6;
        public System.Windows.Forms.Label Lab13;
        public System.Windows.Forms.Label Lab5;
        public System.Windows.Forms.Label Lab12;
        public System.Windows.Forms.Label Lab4;
        public System.Windows.Forms.Label Lab11;
        public System.Windows.Forms.Label Lab3;
        public System.Windows.Forms.Label Lab10;
        public System.Windows.Forms.Label Lab2;
        public System.Windows.Forms.Label Lab9;
        public System.Windows.Forms.Label Lab8;
        public System.Windows.Forms.Label Lab1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label timerLab;
    }
}

