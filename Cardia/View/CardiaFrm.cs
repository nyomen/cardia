﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MGT.ECG_Signal_Generator;
using MGT.HRM.Emulator;
using MGT.HRM;
using MGT.HRM.Zephyr_HxM;
using System.Collections.Concurrent;
using MGT.HRM.CMS50;
using MGT.HRM.HRP;
using System.Reflection.Emit;

namespace MGT.Cardia
{
    public partial class CardiaFrm : Form
    {
        #region Fields

        private Cardia cardia;
        private Bundle bundle;

        List<ToolStripMenuItem> deviceMenuItems = new List<ToolStripMenuItem>();

        #region UI status

        private bool btnStartFlag = true;
        private int startingFormHeight;
        bool startingFormHeightFlag = true;

        #endregion

        #endregion

        #region Constructor & initialization

        public CardiaFrm(Cardia cardia)
        {
            this.cardia = cardia;

            InitializeComponent();

            cardia.StatusChanged += cardia_StatusChanged;
            cardia.BundleChanged += cardia_BundleChanged;
            cardia.ColorChanged += cardia_ColorChanged;
            cardia.MainFontChanged += Cardia_MainFontChanged;
            cardia.FontSizeChanged += Cardia_FontSizeChanged;
            cardia.AutoStartChanged += cardia_AutoStartChanged;
            cardia.StartShrinkedChanged += cardia_StartShrinkedChanged;
            cardia.ChartTimeChanged += cardia_ChartTimeChanged;
            cardia.VolumeChanged += cardia_VolumeChanged;
            cardia.PlayBeatChanged += cardia_PlayBeatChanged;
            cardia.PlayAlarmChanged += cardia_PlayAlarmChanged;
            cardia.WidthChanged += cardia_WidthChanged;
            cardia.LocationChanged += cardia_LocationChanged;
            screenColorPicker1.ColorChanged += ScreenColorPicker1_ColorChanged;

            cardia.Started += cardia_Started;
            cardia.Stopped += cardia_Stopped;

            cardia.PacketProcessed += cardia_PacketProcessed;
            cardia.SignalGenerated += cardia_SignalGenerated;

            cardia.AlarmTripped += cardia_AlarmTripped;

            RegisterShrinkedWindowDrag();
            InitializeDevices();
            InitializeAlarmPanel();
            InitializeLogPanel();
            InitializeNetworkPanel();
        }

        private void InitializeDevices()
        {
            foreach (Bundle bundle in cardia.Bundles)
            {
                ToolStripMenuItem item = new ToolStripMenuItem();
                item.Text = bundle.Device.Name;
                item.Click += new EventHandler(miDevicesItem_Clicked);
                item.Tag = bundle;
                miDevice.DropDownItems.Insert(miDevice.DropDownItems.Count - 2, item);
                deviceMenuItems.Add(item);
            }
        }

        #endregion

        #region Cardia event handlers

        void cardia_StatusChanged(object sender, string status, bool error)
        {
            if (this.IsHandleCreated)
            {
                this.Invoke(new MethodInvoker(delegate()
                {
                    tslStatus.Text = status;

                    if (error)
                        System.Media.SystemSounds.Hand.Play();
                }));
            }
            else
            {
                tslStatus.Text = status;
            }
        }

        void cardia_BundleChanged(object sender, Bundle newBundle)
        {
            if (bundle != null)
                bundle.DeviceControlForm.Hide();

            bundle = newBundle;
            ResetUI();

            foreach (ToolStripItem item in miDevice.DropDownItems)
            {
                if (!(item is ToolStripMenuItem))
                    continue;

                ToolStripMenuItem menuItem = (ToolStripMenuItem)item;

                if (menuItem.Tag == newBundle)
                    menuItem.Checked = true;
                else
                    menuItem.Checked = false;
            }

            try
            {
                newBundle.InitControlForm();
            }
            catch (Exception e)
            {
                tslStatus.Text = e.Message;
                LockUI();
            }
        }


        void Cardia_MainFontChanged(object sender, Font mainFont)
        {
            ecgDisplay.MainFont = mainFont;
        }


        private void Cardia_FontSizeChanged(object sender, double fontSize)
        {
            ecgDisplay.FontMultiplier = fontSize;
        }

        void cardia_ColorChanged(object sender, Color color)
        {
            ecgDisplay.Color = color;

            foreach (ECGDisplay clientDisplay in displays.Values)
            {
                clientDisplay.Color = color;
            }
        }

        void cardia_AutoStartChanged(object sender, bool arg)
        {
            toolStripMenuItemAutostart.Checked = arg;
        }

        void cardia_StartShrinkedChanged(object sender, bool arg)
        {
            toolStripMenuItemStartShrinked.Checked = arg;
        }

        void cardia_ChartTimeChanged(object sender, int chartTime)
        {
            nudChartTime.Value = chartTime;

            int time = chartTime * 1000;

            ecgDisplay.ChartTime = time;

            foreach (ECGDisplay clientDisplay in displays.Values)
            {
                clientDisplay.ChartTime = time;
            }
        }

        void cardia_VolumeChanged(object sender, int arg)
        {
            tbVolume.Value = arg;
        }

        void cardia_PlayBeatChanged(object sender, bool arg)
        {
            miSoundPlayBeat.Checked = arg;
        }

        void cardia_PlayAlarmChanged(object sender, bool arg)
        {
            miSoundPlayAlarm.Checked = arg;
        }

        void cardia_WidthChanged(object sender, int width)
        {
            this.Width = width;
        }

        void cardia_LocationChanged(object sender, Point? location)
        {
            if (location != null)
                this.Location = location.Value;
            else
                this.StartPosition = FormStartPosition.CenterScreen;
        }

        void cardia_Started(object sender)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                btnStartFlag = false;
                btnStartStop.Enabled = true;
                btnStartStop.Text = "Stop";
            }));
        }

        void cardia_Stopped(object sender)
        {
            if (!this.IsHandleCreated)
                return;

            this.Invoke(new MethodInvoker(delegate()
            {
                btnStartFlag = true;
                btnStartStop.Text = "Start";
                logPanel.ResetUI();
                ResetUI();
            }));
        }

        void cardia_PacketProcessed(object sender, HRMStatus hrmStatus)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                this.SuspendLayout();
                ecgDisplay.BPM = hrmStatus.HeartRate;
                ecgDisplay.MinBPM = hrmStatus.MinHeartRate;
                ecgDisplay.MaxBPM = hrmStatus.MaxHeartRate;
                tslStatus.Text = String.Format("Reading - {0} packets received", hrmStatus.TotalPackets);
                this.Text = String.Format("[{0} BPM] Cardia", hrmStatus.HeartRate.ToString());
                this.ResumeLayout();
            }));
        }

        void cardia_SignalGenerated(object sender, SignalGeneratedEventArgs e)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                ecgDisplay.Push(e.Time, e.Buffer);
            }));
        }

        void cardia_AlarmTripped(object sender, bool arg)
        {
            this.Invoke(new MethodInvoker(delegate()
            {
                ecgDisplay.Alarm = arg;
            }));
        }

        #endregion

        #region UI event handlers & helpers

        private void ScreenColorPicker1_ColorChanged(object sender, EventArgs e)
        {
            cardia.Color = (sender as ScreenColorPicker).Color;
        }

        private void miDevicesItem_Clicked(object sender, EventArgs e)
        {
            ToolStripMenuItem menuItem = (ToolStripMenuItem)sender;
            menuItem.Checked = true;
            cardia.Bundle = (Bundle)menuItem.Tag;
        }

        private void miSoundPlayBeat_Click(object sender, EventArgs e)
        {
            cardia.PlayBeat = !miSoundPlayBeat.Checked;
        }

        private void miSoundPlayAlarm_Click(object sender, EventArgs e)
        {
            cardia.PlayAlarm = !miSoundPlayAlarm.Checked;
        }

        private void toolStripMenuItemAutostart_CheckedChanged(object sender, EventArgs e)
        {
            cardia.AutoStart = (sender as ToolStripMenuItem).Checked;
        }

        private void toolStripMenuItemStartShrinked_CheckedChanged(object sender, EventArgs e)
        {
            cardia.StartShrinked = (sender as ToolStripMenuItem).Checked;
        }

        private void nudChartTime_ValueChanged(object sender, EventArgs e)
        {
            int value = Convert.ToInt32(nudChartTime.Value);

            cardia.ChartTime = value;
        }

        private void tbVolume_Scroll(object sender, EventArgs e)
        {
            cardia.Volume = tbVolume.Value;
        }

        FormWindowState previousWindowState = FormWindowState.Normal;

        private void Main_Resize(object sender, EventArgs e)
        {
            cardia.Width = this.Width;

            if (this.WindowState == FormWindowState.Normal && previousWindowState == FormWindowState.Minimized)
                SetFormHeight();

            previousWindowState = this.WindowState;
        }

        private void SetFormHeight()
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
            {
                this.MinimumSize = new Size(this.MinimumSize.Width, (displays.Count + 1) * ecgDisplay.Height + (startingFormHeight - ecgDisplay.Height));
                this.MaximumSize = new Size(this.MaximumSize.Width, (displays.Count + 1) * ecgDisplay.Height + (startingFormHeight - ecgDisplay.Height));
                this.Height = (displays.Count + 1) * ecgDisplay.Height + (startingFormHeight - ecgDisplay.Height);
            }
            else
            {
                this.MinimumSize = new Size(this.MinimumSize.Width, (displays.Count + 1) * ecgDisplay.Height);
                this.MaximumSize = new Size(this.MaximumSize.Width, (displays.Count + 1) * ecgDisplay.Height);
                this.Height = (displays.Count + 1) * ecgDisplay.Height;
            }
        }

        private void Main_Move(object sender, EventArgs e)
        {
            cardia.Location = this.Location;
        }

        private void Main_Paint(object sender, PaintEventArgs e)
        {
            if (startingFormHeightFlag)
            {
                startingFormHeightFlag = false;
                startingFormHeight = this.Height;

                if (cardia.configuration.AutoStart)
                    Start();
                if (cardia.configuration.StartInShrinkMode)
                    shrinkToolStripMenuItem_Click(null, null);
            }
        }

        private void HRMUISmall_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (cardia.NetworkRelay.Running)
                cardia.StopNetwork();
            cardia.Stop();
        }

        private void LockUI()
        {
            miDeviceConfigure.Enabled = false;
            btnStartStop.Enabled = false;
        }

        private void LockDevicesMenuItems()
        {
            foreach (ToolStripMenuItem item in deviceMenuItems)
                item.Enabled = false;
        }

        private void ResetUI()
        {
            btnStartFlag = true;

            this.Text = "Cardia";
            if (cardia.NetworkRelay != null && cardia.NetworkRelay.Running)
                ecgDisplay.Reset(false);
            else
                ecgDisplay.Reset(true);
            for (int i = 0; i < miDevice.DropDownItems.Count - 2; i++)
            {
                miDevice.DropDownItems[i].Enabled = true;
            }
            miDeviceConfigure.Enabled = true;
            btnStartStop.Enabled = true;

            bundle.DeviceControlForm.ResetUI();
        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            if (btnStartFlag)
                Start();
            else
                Stop();
        }

        private void Start()
        {
            LockDevicesMenuItems();
            btnStartStop.Enabled = false;
            logPanel.LockUI();
            cardia.Start();
        }

        private void Stop()
        {
            cardia.Stop();

            ResetUI();
        }

        private void miDeviceConfigure_Click(object sender, EventArgs e)
        {
            bundle.DeviceControlForm.Show();
            bundle.DeviceControlForm.Focus();
        }

        private void flpClients_Resize(object sender, EventArgs e)
        {
            for (int i = 0; i < flpClients.Controls.Count; i++)
            {
                flpClients.Controls[i].Width = flpClients.Width;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutFrm.Instance.Show();
            AboutFrm.Instance.Focus();
        }

        #region Shrink

        private void shrinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            unshrinkToolStripMenuItem.Visible = true;
            shrinkToolStripMenuItem.Visible = false;
            pnlControl.Visible = false;
            msTop.Visible = false;
            ssBottom.Visible = false;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;

            SetFormHeight();
        }

        private void unshrinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            shrinkToolStripMenuItem.Visible = true;
            unshrinkToolStripMenuItem.Visible = false;
            pnlControl.Visible = true;
            msTop.Visible = true;
            ssBottom.Visible = true;

            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;

            SetFormHeight();

            this.Cursor = Cursors.Default;
        }

        public Point downPoint = Point.Empty;

        private void RegisterShrinkedWindowDrag()
        {
            this.MouseDown += new MouseEventHandler(HRMUISmall_MouseDown);
            this.MouseMove += new MouseEventHandler(HRMUISmall_MouseMove);
            this.MouseUp += new MouseEventHandler(HRMUISmall_MouseUp);

            ecgDisplay.MouseDown += new MouseEventHandler(HRMUISmall_MouseDown);
            ecgDisplay.MouseMove += new MouseEventHandler(HRMUISmall_MouseMove);
            ecgDisplay.MouseUp += new MouseEventHandler(HRMUISmall_MouseUp);
        }

        void HRMUISmall_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            downPoint = new Point(e.X, e.Y);
        }

        void HRMUISmall_MouseMove(object sender, MouseEventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                return;

            if (downPoint == Point.Empty)
                return;

            Point location = new Point(this.Left + e.X - downPoint.X, this.Top + e.Y - downPoint.Y);
            this.Location = location;
        }

        void HRMUISmall_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.FormBorderStyle != System.Windows.Forms.FormBorderStyle.None)
                return;

            if (e.Button != MouseButtons.Left)
                return;

            downPoint = Point.Empty;
        }

        private void ecgDisplay_MouseEnter(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
            {
                this.Cursor = Cursors.SizeAll;
            }
        }

        private void ecgDisplay_MouseLeave(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == System.Windows.Forms.FormBorderStyle.None)
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        #endregion

        #region Alarm

        private AlarmFrm alarmPanel;

        private void InitializeAlarmPanel()
        {
            alarmPanel = new AlarmFrm(cardia);
        }

        private void alarmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alarmPanel.Show();
            alarmPanel.Focus();
        }

        #endregion

        #region Log panel

        private LogFrm logPanel;

        private void InitializeLogPanel()
        {
            logPanel = new LogFrm(cardia);
        }

        private void miLog_Click(object sender, EventArgs e)
        {
            logPanel.Show();
            logPanel.Focus();
        }

        #endregion

        #region Networking

        NetworkFrm networkPanel;
        IDictionary<int, ECGDisplay> displays = new ConcurrentDictionary<int, ECGDisplay>();

        private bool InitializeNetworkPanel()
        {
            networkPanel = new NetworkFrm(cardia);
            cardia.NetworkConnected += cardia_NetworkConnected;
            cardia.NetworkDisconnected += cardia_NetworkDisconnected;
            cardia.NetworkClientConnected += cardia_NetworkClientConnected;
            cardia.NetworkClientDisconnected += cardia_NetworkClientDisconnected;
            cardia.NetworkMessageReceived += cardia_NetworkMessageReceived;
            cardia.ClientSignalGenerated += cardia_ClientSignalGenerated;

            return true;
        }

        void cardia_ClientSignalGenerated(object sender, int clientId, SignalGeneratedEventArgs e)
        {
            this.Invoke((MethodInvoker)(
                delegate()
                {
                    try
                    {
                        displays[clientId].Push(e.Time, e.Buffer);
                    }
                    catch (KeyNotFoundException) { }
                }
            ));
        }

        void cardia_NetworkMessageReceived(object sender, HeartRateMessage message)
        {
            this.Invoke((MethodInvoker)(
                delegate()
                {
                    displays[message.ClientId].BPM = message.BPM;
                    displays[message.ClientId].MinBPM = message.MinBPM;
                    displays[message.ClientId].MaxBPM = message.MaxBPM;
                }
            ));
        }

        void cardia_NetworkClientDisconnected(object sender, int clientId)
        {
            if (!this.IsHandleCreated)
                return;

            this.Invoke((MethodInvoker)(
                delegate()
                {
                    try
                    {
                        ECGDisplay clientDisplay = displays[clientId];
                        flpClients.Controls.Remove(clientDisplay);
                        clientDisplay.Dispose();
                        displays.Remove(clientId);
                        SetFormHeight();
                    }
                    catch (KeyNotFoundException) { }
                }
            ));
        }

        void cardia_NetworkClientConnected(object sender, int clientId, string nickname)
        {
            ECGDisplay clientDisplay = new ECGDisplay();
            displays[clientId] = clientDisplay;

            this.Invoke((MethodInvoker)(
                delegate()
                {
                    this.SuspendLayout();
                    SetFormHeight();

                    flpClients.Controls.Add(clientDisplay);

                    clientDisplay.BrushSize = ecgDisplay.BrushSize;
                    clientDisplay.ChartTime = Convert.ToInt32(nudChartTime.Value) * 1000;
                    clientDisplay.Dock = System.Windows.Forms.DockStyle.Top;
                    clientDisplay.Interval = ecgDisplay.Interval;
                    clientDisplay.Margin = ecgDisplay.Margin;
                    clientDisplay.Name = "ecgDisplay_" + clientId;
                    clientDisplay.Nickname = nickname;
                    clientDisplay.Offset = ecgDisplay.Offset;
                    clientDisplay.Padding = ecgDisplay.Padding;
                    clientDisplay.ShowNickname = true;
                    clientDisplay.Size = ecgDisplay.Size;

                    clientDisplay.MouseDown += HRMUISmall_MouseDown;
                    clientDisplay.MouseMove += HRMUISmall_MouseMove;
                    clientDisplay.MouseUp += HRMUISmall_MouseUp;
                    clientDisplay.MouseEnter += ecgDisplay_MouseEnter;
                    clientDisplay.MouseLeave += ecgDisplay_MouseLeave;

                    this.ResumeLayout();
                }
            ));
        }

        void cardia_NetworkDisconnected(object sender, bool error)
        {
            this.Invoke(new MethodInvoker(
                delegate()
                {
                    ecgDisplay.ShowNickname = false;

                    foreach (ECGDisplay clientDisplay in displays.Values)
                    {
                        flpClients.Controls.Remove(clientDisplay);
                        clientDisplay.Dispose();
                    }
                    displays.Clear();
                    SetFormHeight();
                }
            ));
        }

        void cardia_NetworkConnected(object sender, string nickname)
        {
            this.Invoke(new MethodInvoker(
                delegate()
                {
                    ecgDisplay.Nickname = nickname;
                    ecgDisplay.ShowNickname = true;
                }
            ));
        }

        private void miNetwork_Click(object sender, EventArgs e)
        {
            networkPanel.Show();
            networkPanel.Focus();
        }

        #endregion Networking

        private void fontSelectorBtn_Click(object sender, EventArgs e)
        {
            FontDialog fontDlg = new FontDialog();
            if (fontDlg.ShowDialog() != DialogResult.Cancel)
            {
                cardia.MainFont = fontDlg.Font;
            }
        }

        private void tbFontSize_Scroll(object sender, EventArgs e)
        {
            cardia.FontSize = tbFontSize.Value/10.0;
        }
    }
}
