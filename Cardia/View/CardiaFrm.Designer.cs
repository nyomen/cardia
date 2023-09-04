namespace MGT.Cardia
{
    partial class CardiaFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CardiaFrm));
            this.lbColor = new System.Windows.Forms.Label();
            this.lbChartTime = new System.Windows.Forms.Label();
            this.nudChartTime = new System.Windows.Forms.NumericUpDown();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.shrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.unshrinkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ssBottom = new System.Windows.Forms.StatusStrip();
            this.tslStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.pnlControl = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.lbVolume = new System.Windows.Forms.Label();
            this.tbVolume = new System.Windows.Forms.TrackBar();
            this.btnStartStop = new System.Windows.Forms.Button();
            this.flpClients = new System.Windows.Forms.FlowLayoutPanel();
            this.msTop = new System.Windows.Forms.MenuStrip();
            this.miDevice = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAutostart = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemStartShrinked = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.miDeviceConfigure = new System.Windows.Forms.ToolStripMenuItem();
            this.alarmToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.soundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.miSoundPlayBeat = new System.Windows.Forms.ToolStripMenuItem();
            this.miSoundPlayAlarm = new System.Windows.Forms.ToolStripMenuItem();
            this.logToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.networkToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.abcToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tbFontSize = new System.Windows.Forms.TrackBar();
            this.ecgDisplay = new MGT.Cardia.ECGDisplay();
            this.screenColorPicker1 = new MGT.Cardia.ScreenColorPicker();
            ((System.ComponentModel.ISupportInitialize)(this.nudChartTime)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            this.ssBottom.SuspendLayout();
            this.pnlControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).BeginInit();
            this.flpClients.SuspendLayout();
            this.msTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).BeginInit();
            this.SuspendLayout();
            // 
            // lbColor
            // 
            this.lbColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbColor.AutoSize = true;
            this.lbColor.Location = new System.Drawing.Point(4, 8);
            this.lbColor.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbColor.Name = "lbColor";
            this.lbColor.Size = new System.Drawing.Size(50, 20);
            this.lbColor.TabIndex = 5;
            this.lbColor.Text = "Color:";
            // 
            // lbChartTime
            // 
            this.lbChartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbChartTime.AutoSize = true;
            this.lbChartTime.Location = new System.Drawing.Point(129, 8);
            this.lbChartTime.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbChartTime.Name = "lbChartTime";
            this.lbChartTime.Size = new System.Drawing.Size(86, 20);
            this.lbChartTime.TabIndex = 11;
            this.lbChartTime.Text = "Chart time:";
            // 
            // nudChartTime
            // 
            this.nudChartTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.nudChartTime.Location = new System.Drawing.Point(223, 6);
            this.nudChartTime.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.nudChartTime.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nudChartTime.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nudChartTime.Name = "nudChartTime";
            this.nudChartTime.Size = new System.Drawing.Size(66, 26);
            this.nudChartTime.TabIndex = 31;
            this.nudChartTime.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nudChartTime.ValueChanged += new System.EventHandler(this.nudChartTime_ValueChanged);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.shrinkToolStripMenuItem,
            this.unshrinkToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(154, 68);
            // 
            // shrinkToolStripMenuItem
            // 
            this.shrinkToolStripMenuItem.Name = "shrinkToolStripMenuItem";
            this.shrinkToolStripMenuItem.Size = new System.Drawing.Size(153, 32);
            this.shrinkToolStripMenuItem.Text = "Shrink";
            this.shrinkToolStripMenuItem.Click += new System.EventHandler(this.shrinkToolStripMenuItem_Click);
            // 
            // unshrinkToolStripMenuItem
            // 
            this.unshrinkToolStripMenuItem.Name = "unshrinkToolStripMenuItem";
            this.unshrinkToolStripMenuItem.Size = new System.Drawing.Size(153, 32);
            this.unshrinkToolStripMenuItem.Text = "Unshrink";
            this.unshrinkToolStripMenuItem.Visible = false;
            this.unshrinkToolStripMenuItem.Click += new System.EventHandler(this.unshrinkToolStripMenuItem_Click);
            // 
            // ssBottom
            // 
            this.ssBottom.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.ssBottom.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslStatus});
            this.ssBottom.Location = new System.Drawing.Point(0, 303);
            this.ssBottom.Name = "ssBottom";
            this.ssBottom.Padding = new System.Windows.Forms.Padding(2, 0, 21, 0);
            this.ssBottom.Size = new System.Drawing.Size(885, 22);
            this.ssBottom.SizingGrip = false;
            this.ssBottom.TabIndex = 32;
            this.ssBottom.Text = "ssBottom";
            // 
            // tslStatus
            // 
            this.tslStatus.Name = "tslStatus";
            this.tslStatus.Size = new System.Drawing.Size(0, 15);
            // 
            // pnlControl
            // 
            this.pnlControl.Controls.Add(this.button1);
            this.pnlControl.Controls.Add(this.screenColorPicker1);
            this.pnlControl.Controls.Add(this.lbVolume);
            this.pnlControl.Controls.Add(this.tbVolume);
            this.pnlControl.Controls.Add(this.btnStartStop);
            this.pnlControl.Controls.Add(this.lbColor);
            this.pnlControl.Controls.Add(this.nudChartTime);
            this.pnlControl.Controls.Add(this.lbChartTime);
            this.pnlControl.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlControl.Location = new System.Drawing.Point(0, 263);
            this.pnlControl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pnlControl.Name = "pnlControl";
            this.pnlControl.Size = new System.Drawing.Size(885, 40);
            this.pnlControl.TabIndex = 34;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(524, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(96, 35);
            this.button1.TabIndex = 40;
            this.button1.Text = "Font";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.fontSelectorBtn_Click);
            // 
            // lbVolume
            // 
            this.lbVolume.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbVolume.AutoSize = true;
            this.lbVolume.Location = new System.Drawing.Point(297, 7);
            this.lbVolume.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbVolume.Name = "lbVolume";
            this.lbVolume.Size = new System.Drawing.Size(67, 20);
            this.lbVolume.TabIndex = 39;
            this.lbVolume.Text = "Volume:";
            // 
            // tbVolume
            // 
            this.tbVolume.Location = new System.Drawing.Point(360, 0);
            this.tbVolume.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbVolume.Name = "tbVolume";
            this.tbVolume.Size = new System.Drawing.Size(156, 69);
            this.tbVolume.TabIndex = 38;
            this.tbVolume.Value = 5;
            this.tbVolume.Scroll += new System.EventHandler(this.tbVolume_Scroll);
            // 
            // btnStartStop
            // 
            this.btnStartStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStartStop.Location = new System.Drawing.Point(776, 0);
            this.btnStartStop.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnStartStop.Name = "btnStartStop";
            this.btnStartStop.Size = new System.Drawing.Size(96, 35);
            this.btnStartStop.TabIndex = 37;
            this.btnStartStop.Text = "Start";
            this.btnStartStop.UseVisualStyleBackColor = true;
            this.btnStartStop.Click += new System.EventHandler(this.btnStartStop_Click);
            // 
            // flpClients
            // 
            this.flpClients.BackColor = System.Drawing.Color.Black;
            this.flpClients.Controls.Add(this.ecgDisplay);
            this.flpClients.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flpClients.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpClients.Location = new System.Drawing.Point(0, 36);
            this.flpClients.Margin = new System.Windows.Forms.Padding(0);
            this.flpClients.Name = "flpClients";
            this.flpClients.Size = new System.Drawing.Size(885, 227);
            this.flpClients.TabIndex = 36;
            this.flpClients.Resize += new System.EventHandler(this.flpClients_Resize);
            // 
            // msTop
            // 
            this.msTop.GripMargin = new System.Windows.Forms.Padding(2, 2, 0, 2);
            this.msTop.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.msTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miDevice,
            this.alarmToolStripMenuItem,
            this.soundToolStripMenuItem,
            this.logToolStripMenuItem,
            this.networkToolStripMenuItem,
            this.aboutToolStripMenuItem});
            this.msTop.Location = new System.Drawing.Point(0, 0);
            this.msTop.Name = "msTop";
            this.msTop.Size = new System.Drawing.Size(885, 36);
            this.msTop.TabIndex = 37;
            // 
            // miDevice
            // 
            this.miDevice.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAutostart,
            this.toolStripMenuItemStartShrinked,
            this.toolStripSeparator1,
            this.toolStripSeparator2,
            this.miDeviceConfigure});
            this.miDevice.Name = "miDevice";
            this.miDevice.Size = new System.Drawing.Size(80, 30);
            this.miDevice.Text = "Device";
            // 
            // toolStripMenuItemAutostart
            // 
            this.toolStripMenuItemAutostart.CheckOnClick = true;
            this.toolStripMenuItemAutostart.Name = "toolStripMenuItemAutostart";
            this.toolStripMenuItemAutostart.Size = new System.Drawing.Size(223, 34);
            this.toolStripMenuItemAutostart.Text = "Autostart";
            this.toolStripMenuItemAutostart.CheckedChanged += new System.EventHandler(this.toolStripMenuItemAutostart_CheckedChanged);
            // 
            // toolStripMenuItemStartShrinked
            // 
            this.toolStripMenuItemStartShrinked.CheckOnClick = true;
            this.toolStripMenuItemStartShrinked.Name = "toolStripMenuItemStartShrinked";
            this.toolStripMenuItemStartShrinked.Size = new System.Drawing.Size(223, 34);
            this.toolStripMenuItemStartShrinked.Text = "Start shrinked";
            this.toolStripMenuItemStartShrinked.CheckedChanged += new System.EventHandler(this.toolStripMenuItemStartShrinked_CheckedChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(220, 6);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(220, 6);
            // 
            // miDeviceConfigure
            // 
            this.miDeviceConfigure.Name = "miDeviceConfigure";
            this.miDeviceConfigure.Size = new System.Drawing.Size(223, 34);
            this.miDeviceConfigure.Text = "Configuration";
            this.miDeviceConfigure.Click += new System.EventHandler(this.miDeviceConfigure_Click);
            // 
            // alarmToolStripMenuItem
            // 
            this.alarmToolStripMenuItem.Name = "alarmToolStripMenuItem";
            this.alarmToolStripMenuItem.Size = new System.Drawing.Size(75, 30);
            this.alarmToolStripMenuItem.Text = "Alarm";
            this.alarmToolStripMenuItem.Click += new System.EventHandler(this.alarmToolStripMenuItem_Click);
            // 
            // soundToolStripMenuItem
            // 
            this.soundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.miSoundPlayBeat,
            this.miSoundPlayAlarm});
            this.soundToolStripMenuItem.Name = "soundToolStripMenuItem";
            this.soundToolStripMenuItem.Size = new System.Drawing.Size(80, 30);
            this.soundToolStripMenuItem.Text = "Sound";
            // 
            // miSoundPlayBeat
            // 
            this.miSoundPlayBeat.Name = "miSoundPlayBeat";
            this.miSoundPlayBeat.Size = new System.Drawing.Size(195, 34);
            this.miSoundPlayBeat.Text = "Play beat";
            this.miSoundPlayBeat.Click += new System.EventHandler(this.miSoundPlayBeat_Click);
            // 
            // miSoundPlayAlarm
            // 
            this.miSoundPlayAlarm.Name = "miSoundPlayAlarm";
            this.miSoundPlayAlarm.Size = new System.Drawing.Size(195, 34);
            this.miSoundPlayAlarm.Text = "Play alarm";
            this.miSoundPlayAlarm.Click += new System.EventHandler(this.miSoundPlayAlarm_Click);
            // 
            // logToolStripMenuItem
            // 
            this.logToolStripMenuItem.Name = "logToolStripMenuItem";
            this.logToolStripMenuItem.Size = new System.Drawing.Size(58, 30);
            this.logToolStripMenuItem.Text = "Log";
            this.logToolStripMenuItem.Click += new System.EventHandler(this.miLog_Click);
            // 
            // networkToolStripMenuItem
            // 
            this.networkToolStripMenuItem.Name = "networkToolStripMenuItem";
            this.networkToolStripMenuItem.Size = new System.Drawing.Size(95, 30);
            this.networkToolStripMenuItem.Text = "Network";
            this.networkToolStripMenuItem.Click += new System.EventHandler(this.miNetwork_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(78, 30);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // abcToolStripMenuItem
            // 
            this.abcToolStripMenuItem.Name = "abcToolStripMenuItem";
            this.abcToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // tbFontSize
            // 
            this.tbFontSize.Location = new System.Drawing.Point(628, 264);
            this.tbFontSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.tbFontSize.Maximum = 30;
            this.tbFontSize.Minimum = 1;
            this.tbFontSize.Name = "tbFontSize";
            this.tbFontSize.Size = new System.Drawing.Size(138, 69);
            this.tbFontSize.TabIndex = 41;
            this.tbFontSize.Value = 10;
            this.tbFontSize.Scroll += new System.EventHandler(this.tbFontSize_Scroll);
            // 
            // ecgDisplay
            // 
            this.ecgDisplay.Alarm = false;
            this.ecgDisplay.BackColor = System.Drawing.Color.Lime;
            this.ecgDisplay.Beat = false;
            this.ecgDisplay.BPM = null;
            this.ecgDisplay.BrushSize = 8;
            this.ecgDisplay.ChartTime = 4000;
            this.ecgDisplay.Color = System.Drawing.Color.Lime;
            this.ecgDisplay.FontMultiplier = 1F;
            this.ecgDisplay.Interval = 20;
            this.ecgDisplay.Location = new System.Drawing.Point(0, 0);
            this.ecgDisplay.MainFont = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ecgDisplay.Margin = new System.Windows.Forms.Padding(0);
            this.ecgDisplay.MaxBPM = null;
            this.ecgDisplay.MaximumSize = new System.Drawing.Size(0, 231);
            this.ecgDisplay.MinBPM = null;
            this.ecgDisplay.MinimumSize = new System.Drawing.Size(888, 231);
            this.ecgDisplay.Name = "ecgDisplay";
            this.ecgDisplay.Nickname = null;
            this.ecgDisplay.Offset = 20;
            this.ecgDisplay.Padding = new System.Windows.Forms.Padding(3, 3, 3, 3);
            this.ecgDisplay.ShowNickname = false;
            this.ecgDisplay.Size = new System.Drawing.Size(888, 231);
            this.ecgDisplay.TabIndex = 38;
            this.ecgDisplay.MouseEnter += new System.EventHandler(this.ecgDisplay_MouseEnter);
            this.ecgDisplay.MouseLeave += new System.EventHandler(this.ecgDisplay_MouseLeave);
            // 
            // screenColorPicker1
            // 
            this.screenColorPicker1.Color = System.Drawing.Color.Empty;
            this.screenColorPicker1.Location = new System.Drawing.Point(61, 0);
            this.screenColorPicker1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.screenColorPicker1.Name = "screenColorPicker1";
            this.screenColorPicker1.Size = new System.Drawing.Size(60, 38);
            this.screenColorPicker1.Text = "screenColorPicker1";
            // 
            // CardiaFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 325);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.tbFontSize);
            this.Controls.Add(this.flpClients);
            this.Controls.Add(this.pnlControl);
            this.Controls.Add(this.ssBottom);
            this.Controls.Add(this.msTop);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.msTop;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(6130, 381);
            this.MinimumSize = new System.Drawing.Size(898, 381);
            this.Name = "CardiaFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Cardia";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HRMUISmall_FormClosing);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Main_Paint);
            this.Move += new System.EventHandler(this.Main_Move);
            this.Resize += new System.EventHandler(this.Main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.nudChartTime)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ssBottom.ResumeLayout(false);
            this.ssBottom.PerformLayout();
            this.pnlControl.ResumeLayout(false);
            this.pnlControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbVolume)).EndInit();
            this.flpClients.ResumeLayout(false);
            this.msTop.ResumeLayout(false);
            this.msTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbFontSize)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lbColor;
        private System.Windows.Forms.Label lbChartTime;
        private System.Windows.Forms.NumericUpDown nudChartTime;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem shrinkToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem unshrinkToolStripMenuItem;
        private System.Windows.Forms.StatusStrip ssBottom;
        private System.Windows.Forms.ToolStripStatusLabel tslStatus;
        private System.Windows.Forms.Panel pnlControl;
        private System.Windows.Forms.Button btnStartStop;
        private System.Windows.Forms.FlowLayoutPanel flpClients;
        private ECGDisplay ecgDisplay;
        private System.Windows.Forms.MenuStrip msTop;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miDevice;
        private System.Windows.Forms.ToolStripMenuItem logToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem networkToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem miDeviceConfigure;
        private System.Windows.Forms.TrackBar tbVolume;
        private System.Windows.Forms.Label lbVolume;
        private System.Windows.Forms.ToolStripMenuItem abcToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alarmToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem soundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem miSoundPlayBeat;
        private System.Windows.Forms.ToolStripMenuItem miSoundPlayAlarm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAutostart;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemStartShrinked;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private ScreenColorPicker screenColorPicker1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TrackBar tbFontSize;
    }
}