using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace XJoy
{
	public partial class MainForm : Form
	{
		public class DeviceListItem
		{
			public string DisplayName;
			public byte DeviceIndex;

			public DeviceListItem(string Name, byte Index)
			{
				DisplayName = Name;
				DeviceIndex = Index;
			}

			public override string ToString()
			{
				return DisplayName;
			}
		}

		XInputManager XInputObj;
		vJoyManager vJoyObj;
		bool bIsActive = false;

		Thread feederThread = null;

		public MainForm()
		{
			InitializeComponent();
			try
			{
				XInputObj = new XInputManager();
				vJoyObj = new vJoyManager();
				RefreshDeviceList();
			}
			catch (System.IO.FileNotFoundException e)
			{
				MessageBox.Show("FileNotFoundException: " + e.FileName + ". This may occur because of missing DLLs. Make sure to include everything! Application will exit..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(-1);
			}
			catch (Exception e)
			{
				MessageBox.Show("Error: " + e.Message + ". This may occur because of missing DLLs. Make sure to include everything! Application will exit..", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				Environment.Exit(-1);
			}
		}

		private void SetActiveState(bool bActive)
		{
			if(bActive)
			{
				if(XInputObj.ActiveController != null && comboVJoyDevices.SelectedItem != null)
				{

					DeviceListItem vJoyItem = comboVJoyDevices.SelectedItem as DeviceListItem;
					if(vJoyObj != null)
					{
						vJoyObj.InitDevice(vJoyItem.DeviceIndex);
						if(vJoyObj.IsDeviceAcquired)
						{
							buttonActivate.Text = "Deactivate";
							panelControls.Enabled = false;
							bIsActive = true;
							StartThread();
						}
						else
						{
							SetInfoText("Failed to acquire vJoy device.", Color.Red);
						}
					}	
					else
					{
						SetInfoText("vJoy device appears to be invalid.", Color.Red);
					}
				}
			}
			else
			{
				bIsActive = false;
				buttonActivate.Enabled = false;
				StopThread();
				vJoyObj.ReleaseDevice();
				buttonActivate.Enabled = (XInputObj.ActiveController != null && comboVJoyDevices.SelectedItem != null);
				buttonActivate.Text = "Activate";
				panelControls.Enabled = true;
				SetInfoText("Select devices and press Activate to enable.", Color.Black);
			}
		}

		public void StartThread()
		{
			if(feederThread != null)
			{
				StopThread();
			}

			feederThread = new Thread(new ThreadStart(this.ThreadFunc));
			feederThread.Start();
		}

		public void StopThread()
		{
			if(feederThread != null)
			{
				SetInfoText("Stopping feeder thread.", Color.DarkCyan);
				//feederThread.Abort();
				bool threadDead = feederThread.Join(2000);
				if (!threadDead)
				{
					SetInfoText("Stopping feeder thread.", Color.Red);
					feederThread.Abort();
					feederThread.Join();
				}
			}
		}

		private int RemapValueToVJoy(int Value, int XMin, int XMax, vJoyManager.AxisExtents vJoyLimit)
		{
			float value = (float)vJoyLimit.Min + ((float)Value - ((float)XMin)) / (((float)XMax) - ((float)XMin)) * ((float)vJoyLimit.Max - (float)vJoyLimit.Min);
			return (int)Math.Round(value);
		}

		public void ThreadFunc()
		{
			try
			{
				this.BeginInvoke((Action)(() =>
				{
					SetInfoText("Running feeder.", Color.Green);
				}));

				XInputManager.InputState stateData;
				vJoyManager.AxisExtents XLimit = vJoyObj.GetAxisExtents(HID_USAGES.HID_USAGE_X);
				vJoyManager.AxisExtents YLimit = vJoyObj.GetAxisExtents(HID_USAGES.HID_USAGE_Y);
				vJoyManager.AxisExtents RXLimit = vJoyObj.GetAxisExtents(HID_USAGES.HID_USAGE_RX);
				vJoyManager.AxisExtents RYLimit = vJoyObj.GetAxisExtents(HID_USAGES.HID_USAGE_RY);
				vJoyManager.AxisExtents SL0Limit = vJoyObj.GetAxisExtents(HID_USAGES.HID_USAGE_SL0);
				vJoyManager.AxisExtents SL1Limit = vJoyObj.GetAxisExtents(HID_USAGES.HID_USAGE_SL1);

				Console.WriteLine("XLimit: " + XLimit.Min + ", " + XLimit.Max);

				while (bIsActive)
				{
					// Thread body
					stateData = XInputObj.GetState();

					vJoyObj.SetButton(1, stateData.bButtonA);
					vJoyObj.SetButton(2, stateData.bButtonB);
					vJoyObj.SetButton(3, stateData.bButtonX);
					vJoyObj.SetButton(4, stateData.bButtonY);

					vJoyObj.SetButton(5, stateData.bButtonDPadLeft);
					vJoyObj.SetButton(6, stateData.bButtonDPadRight);
					vJoyObj.SetButton(7, stateData.bButtonDPadUp);
					vJoyObj.SetButton(8, stateData.bButtonDPadDown);

					vJoyObj.SetButton(9, stateData.bButtonLeftThumb);
					vJoyObj.SetButton(10, stateData.bButtonRightThumb);

					vJoyObj.SetButton(11, stateData.bButtonLeftShoulder);
					vJoyObj.SetButton(12, stateData.bButtonRightShoulder);

					vJoyObj.SetButton(13, stateData.bButtonStart);
					vJoyObj.SetButton(14, stateData.bButtonBack);

					vJoyObj.SetAxis(HID_USAGES.HID_USAGE_X, RemapValueToVJoy(stateData.LeftStickX, -32768, 32767, XLimit));
					vJoyObj.SetAxis(HID_USAGES.HID_USAGE_Y, RemapValueToVJoy(stateData.LeftStickY, -32768, 32767, YLimit));

					vJoyObj.SetAxis(HID_USAGES.HID_USAGE_RX, RemapValueToVJoy(stateData.RightStickX, -32768, 32767, RXLimit));
					vJoyObj.SetAxis(HID_USAGES.HID_USAGE_RY, RemapValueToVJoy(stateData.RightStickY, -32768, 32767, RYLimit));

					vJoyObj.SetAxis(HID_USAGES.HID_USAGE_SL0, RemapValueToVJoy(stateData.LeftTrigger, 0, 255, SL0Limit));
					vJoyObj.SetAxis(HID_USAGES.HID_USAGE_SL1, RemapValueToVJoy(stateData.RightTrigger, 0, 255, SL1Limit));

					Thread.Sleep(16);
				}

				// Thread done/canceled
			}
			catch (ThreadAbortException)
			{
				// Thread aborted
			}
		}

		public void SetInfoText(string text, Color color)
		{
			labelInfo.Text = text;
			labelInfo.ForeColor = color;
		}

		private void RefreshUIState()
		{
			if(XInputObj.ActiveController == null || comboVJoyDevices.SelectedItem == null)
			{
				SetActiveState(false);
				buttonActivate.Enabled = false;
			}
			else
			{
				buttonActivate.Enabled = true;
			}
		}

		private void RefreshDeviceList()
		{
			comboDevices.Items.Clear();

			bool[] activeControllers = XInputObj.GetActiveControllerIndices();
			for(int i = 0; i < activeControllers.Length; i++)
			{
				if(activeControllers[i])
				{
					comboDevices.Items.Add(new DeviceListItem("XInput Controller #" + (i + 1), (byte)i));
				}
			}

			comboVJoyDevices.Items.Clear();
			bool[] activeVJoyDevices = vJoyObj.GetAvailableIndices();
			for(int i = 0; i < activeVJoyDevices.Length; i++)
			{
				if(activeVJoyDevices[i])
				{
					comboVJoyDevices.Items.Add(new DeviceListItem("vJoy Controller #" + (i + 1), (byte)i));
				}
			}

			RefreshUIState();
		}

		private void MainForm_Resize(object sender, EventArgs e)
		{
			if(this.WindowState == FormWindowState.Minimized)
			{
				this.ShowInTaskbar = false;
			}
			else if(this.WindowState == FormWindowState.Normal)
			{
				this.ShowInTaskbar = true;
				this.BringToFront();
			}
		}

		private void showXJoyWindowToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.BringToFront();
			this.ShowInTaskbar = true;
			this.WindowState = FormWindowState.Normal;
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StopThread();
			Application.Exit();
		}

		private void buttonInfo_Click(object sender, EventArgs e)
		{
			InfoWindow iw = new InfoWindow();
			iw.ShowDialog();
		}

		private void MainNotifyIcon_DoubleClick(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Normal;
			this.ShowInTaskbar = true;
			this.BringToFront();
		}

		private void buttonActivate_Click(object sender, EventArgs e)
		{
			SetActiveState(!bIsActive);
		}

		private void comboDevices_SelectedIndexChanged(object sender, EventArgs e)
		{
			DeviceListItem item = comboDevices.SelectedItem as DeviceListItem;
			if(item != null)
			{
				XInputObj.InitControllerIndex(item.DeviceIndex);
				RefreshUIState();
			}
		}

		private void comboVJoyDevices_SelectedIndexChanged(object sender, EventArgs e)
		{
			DeviceListItem item = comboVJoyDevices.SelectedItem as DeviceListItem;
			if(item != null)
			{
				RefreshUIState();
			}
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			RefreshDeviceList();
		}
	}
}
