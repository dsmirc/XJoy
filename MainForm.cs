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

		public struct InputMapping
		{
			public enum MappingType
			{
				Button,
				Axis
			}

			public XInputManager.Inputs XInput;
			public uint ButtonIndex;
			public HID_USAGES vJoyAxis;
			public MappingType Type;

			public InputMapping(XInputManager.Inputs From, uint ToButton, HID_USAGES ToAxis, MappingType InputType)
			{
				XInput = From;
				ButtonIndex = ToButton;
				vJoyAxis = ToAxis;
				Type = InputType;
			}
		}

		public struct NullInput
		{
			public override string ToString()
			{
				return "<None>";
			}
		}

		XInputManager XInputObj;
		vJoyManager vJoyObj;
		bool bIsActive = false;

		// This is used by both the UI and worker thread
		// NOTE: No thread synchronization is made, if this causes problem then implement a lock
		List<InputMapping> InputMappings = new List<InputMapping>();

		Thread feederThread = null;

		public MainForm()
		{
			InitializeComponent();
			try
			{
				XInputObj = new XInputManager();
				vJoyObj = new vJoyManager();
				RefreshDeviceList();

				Application.ApplicationExit += new EventHandler(delegate (Object o, EventArgs a)
				{
					StopThread();

					// Bug or something but the notify icon lingers after exiting unless we explicitely dispose it
					if (MainNotifyIcon != null)
					{
						MainNotifyIcon.Icon = null;
						MainNotifyIcon.Dispose();
						MainNotifyIcon = null;
					}
				});
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

		private void RefreshComboboxes()
		{
			List<vJoyManager.AnalogInput> Axes = new List<vJoyManager.AnalogInput>();
			List<vJoyManager.DigitalInput> Buttons = new List<vJoyManager.DigitalInput>();

			if(comboVJoyDevices.SelectedItem != null)
			{
				DeviceListItem vJoyItem = comboVJoyDevices.SelectedItem as DeviceListItem;
				if(vJoyItem != null)
				{
					List<HID_USAGES> vJoyAxes = vJoyObj.GetExistingAxes(vJoyItem.DeviceIndex);
					int vJoyButtonCount = vJoyObj.GetButtonCount(vJoyItem.DeviceIndex);

					foreach (HID_USAGES axis in vJoyAxes)
					{
						Axes.Add(new vJoyManager.AnalogInput(axis, vJoyManager.AxisToFriendlyName(axis)));
					}

					for(uint i = 1; i < vJoyButtonCount + 1; i++)
					{
						Buttons.Add(new vJoyManager.DigitalInput(i, "Button #" + i));
					}
				}
			}

			foreach (Control item in RemappingPanel.Controls)
			{
				ComboBox cb = item as ComboBox;
				if (cb == null)
					continue;

				string TagString = cb.Tag as string;
				if (TagString != null)
				{
					if (TagString == "InputAnalog")
					{
						cb.Items.Clear();
						cb.Items.Add(new NullInput());
						cb.Items.AddRange(Axes.ToArray());
						if (cb.SelectedItem == null)
							cb.SelectedIndex = 0;
					}
					else if (TagString == "InputDigital")
					{
						cb.Items.Clear();
						cb.Items.Add(new NullInput());
						cb.Items.AddRange(Buttons.ToArray());
						if (cb.SelectedItem == null)
							cb.SelectedIndex = 0;
					}
				}
			}
		}

		private void UpdateInputMappings()
		{
			InputMappings.Clear();

			AddInputMappingFromBox(inputLSX.SelectedItem, XInputManager.Inputs.LSX);
			AddInputMappingFromBox(inputLSY.SelectedItem, XInputManager.Inputs.LSY);
			AddInputMappingFromBox(inputRSX.SelectedItem, XInputManager.Inputs.RSX);
			AddInputMappingFromBox(inputRSY.SelectedItem, XInputManager.Inputs.RSY);
			AddInputMappingFromBox(inputLT.SelectedItem, XInputManager.Inputs.LT);
			AddInputMappingFromBox(inputRT.SelectedItem, XInputManager.Inputs.RT);

			AddInputMappingFromBox(inputA.SelectedItem, XInputManager.Inputs.A);
			AddInputMappingFromBox(inputB.SelectedItem, XInputManager.Inputs.B);
			AddInputMappingFromBox(inputX.SelectedItem, XInputManager.Inputs.X);
			AddInputMappingFromBox(inputY.SelectedItem, XInputManager.Inputs.Y);
			AddInputMappingFromBox(inputLB.SelectedItem, XInputManager.Inputs.LB);
			AddInputMappingFromBox(inputRB.SelectedItem, XInputManager.Inputs.RB);
			AddInputMappingFromBox(inputDPadLeft.SelectedItem, XInputManager.Inputs.DPadLeft);
			AddInputMappingFromBox(inputDPadRight.SelectedItem, XInputManager.Inputs.DPadRight);
			AddInputMappingFromBox(inputDPadDown.SelectedItem, XInputManager.Inputs.DPadDown);
			AddInputMappingFromBox(inputDPadUp.SelectedItem, XInputManager.Inputs.DPadUp);
			AddInputMappingFromBox(inputLeftStick.SelectedItem, XInputManager.Inputs.LeftStick);
			AddInputMappingFromBox(inputRightStick.SelectedItem, XInputManager.Inputs.RightStick);
			AddInputMappingFromBox(inputStart.SelectedItem, XInputManager.Inputs.Start);
			AddInputMappingFromBox(inputBack.SelectedItem, XInputManager.Inputs.Back);
		}

		private void AddInputMappingFromBox(object SelectedItem, XInputManager.Inputs From)
		{
			if(SelectedItem != null)
			{
				vJoyManager.AnalogInput InputDataAnalog = SelectedItem as vJoyManager.AnalogInput;
				if(InputDataAnalog != null)
				{
					InputMappings.Add(new InputMapping(From, 0, InputDataAnalog.Axis, InputMapping.MappingType.Axis));
				}
				else
				{
					vJoyManager.DigitalInput InputDataDigital = SelectedItem as vJoyManager.DigitalInput;
					if(InputDataDigital != null)
					{
						InputMappings.Add(new InputMapping(From, InputDataDigital.ButtonIndex, HID_USAGES.HID_USAGE_X, InputMapping.MappingType.Button));
					}
				}
			}
		}

		/// <summary>
		/// Starts/stops the input thread and activates the mapping.
		/// </summary>
		/// <param name="bActive">If we are activating (T) or shutting down (F).</param>
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

		private void StartThread()
		{
			if(feederThread != null)
			{
				StopThread();
			}

			feederThread = new Thread(new ThreadStart(this.ThreadFunc));
			feederThread.Start();
		}

		private void StopThread()
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

		/// <summary>
		/// Remaps a value from XInput range to VJoy range. This is necessary because differences in axis values (e.g. negative short values, 0-255 ranges etc.).
		/// </summary>
		/// <param name="Value">The value to convert.</param>
		/// <param name="XMin">The minimum value of Value.</param>
		/// <param name="XMax">The maximum value of Value.</param>
		/// <param name="vJoyLimit">Struct defining the vJoy target limits.</param>
		/// <returns></returns>
		private int RemapValueToVJoy(int Value, int XMin, int XMax, vJoyManager.AxisExtents vJoyLimit)
		{
			float value = (float)vJoyLimit.Min + ((float)Value - ((float)XMin)) / (((float)XMax) - ((float)XMin)) * ((float)vJoyLimit.Max - (float)vJoyLimit.Min);
			return (int)Math.Round(value);
		}

		/// <summary>
		/// Main input forwarding function/loop (input thread).
		/// </summary>
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

				List<bool> finalButtonStates = new List<bool>();
				int ButtonCount = vJoyObj.GetButtonCount(vJoyObj.ActiveVJoyID);
				while (finalButtonStates.Count < ButtonCount) finalButtonStates.Add(false);

				Dictionary<HID_USAGES, int> finalHidValues = new Dictionary<HID_USAGES, int>();
				Dictionary<HID_USAGES, vJoyManager.AxisExtents> HidExtents = new Dictionary<HID_USAGES, vJoyManager.AxisExtents>();
				List<HID_USAGES> AvailableHidValues = vJoyObj.GetExistingAxes(vJoyObj.ActiveVJoyID);
				foreach (HID_USAGES axis in AvailableHidValues)
				{
					finalHidValues.Add(axis, 0);
					HidExtents.Add(axis, vJoyObj.GetAxisExtents(axis));
				}

				List<int> xInputMinRanges = new List<int>();
				List<int> xInputMaxRanges = new List<int>();

				for(int i = 0; i < XInputManager.InputCount; i++)
				{
					int[] inputRange = XInputManager.GetAxisLimitsForInput((XInputManager.Inputs) i);
					xInputMinRanges.Add(inputRange[0]);
					xInputMaxRanges.Add(inputRange[1]);
				}

				int tempHidValue = 0;
				while (bIsActive)
				{
					// Thread body
					stateData = XInputObj.GetState();


					for (int i = 0; i < finalButtonStates.Count; i++)
					{
						finalButtonStates[i] = false;
					}

					for (int i = 0; i < AvailableHidValues.Count; i++)
					{
						finalHidValues[AvailableHidValues[i]] = 0;
					}

					foreach (InputMapping inputMap in InputMappings)
					{
						switch (inputMap.Type)
						{
							case InputMapping.MappingType.Button:
								finalButtonStates[(int)inputMap.ButtonIndex] |= XInputManager.GetInputStateButtonValueFromInputType(ref stateData, inputMap.XInput);
								break;
							case InputMapping.MappingType.Axis:
								tempHidValue = XInputManager.GetInputStateAxisValueFromInputType(ref stateData, inputMap.XInput);
								tempHidValue = RemapValueToVJoy(tempHidValue, xInputMinRanges[(int)inputMap.XInput], xInputMaxRanges[(int)inputMap.XInput], HidExtents[inputMap.vJoyAxis]);
								finalHidValues[inputMap.vJoyAxis] = Math.Max(finalHidValues[inputMap.vJoyAxis], tempHidValue);
								break;
							default:
								break;
						}
					}

					for(uint i = 0; i < finalButtonStates.Count; i++)
					{
						vJoyObj.SetButton(i, finalButtonStates[(int)i]);
					}

					for(int i = 0; i < AvailableHidValues.Count; i++)
					{
						HID_USAGES Axis = AvailableHidValues[i];
						vJoyObj.SetAxis(Axis, finalHidValues[Axis]);
					}

					//vJoyObj.SetButton(1, stateData.bButtonA);
					//vJoyObj.SetButton(2, stateData.bButtonB);
					//vJoyObj.SetButton(3, stateData.bButtonX);
					//vJoyObj.SetButton(4, stateData.bButtonY);
					//
					//vJoyObj.SetButton(5, stateData.bButtonDPadLeft);
					//vJoyObj.SetButton(6, stateData.bButtonDPadRight);
					//vJoyObj.SetButton(7, stateData.bButtonDPadUp);
					//vJoyObj.SetButton(8, stateData.bButtonDPadDown);
					//
					//vJoyObj.SetButton(9, stateData.bButtonLeftThumb);
					//vJoyObj.SetButton(10, stateData.bButtonRightThumb);
					//
					//vJoyObj.SetButton(11, stateData.bButtonLeftShoulder);
					//vJoyObj.SetButton(12, stateData.bButtonRightShoulder);
					//
					//vJoyObj.SetButton(13, stateData.bButtonStart);
					//vJoyObj.SetButton(14, stateData.bButtonBack);
					//
					//vJoyObj.SetAxis(HID_USAGES.HID_USAGE_X, RemapValueToVJoy(stateData.LeftStickX, -32768, 32767, XLimit));
					//vJoyObj.SetAxis(HID_USAGES.HID_USAGE_Y, RemapValueToVJoy(stateData.LeftStickY, -32768, 32767, YLimit));
					//
					//vJoyObj.SetAxis(HID_USAGES.HID_USAGE_RX, RemapValueToVJoy(stateData.RightStickX, -32768, 32767, RXLimit));
					//vJoyObj.SetAxis(HID_USAGES.HID_USAGE_RY, RemapValueToVJoy(stateData.RightStickY, -32768, 32767, RYLimit));
					//
					//vJoyObj.SetAxis(HID_USAGES.HID_USAGE_SL0, RemapValueToVJoy(stateData.LeftTrigger, 0, 255, SL0Limit));
					//vJoyObj.SetAxis(HID_USAGES.HID_USAGE_SL1, RemapValueToVJoy(stateData.RightTrigger, 0, 255, SL1Limit));

					Thread.Sleep(16); // The delay between updates in ms (16 = ~60fps)
				}

				// Thread done/canceled
			}
			catch (ThreadAbortException)
			{
				// Thread aborted
			}
		}

		/// <summary>
		/// Changes the info message on the main UI.
		/// </summary>
		/// <param name="text">New text.</param>
		/// <param name="color">New text color.</param>
		public void SetInfoText(string text, Color color)
		{
			labelInfo.Text = text;
			labelInfo.ForeColor = color;
		}

		/// <summary>
		/// Update various UI elements.
		/// </summary>
		private void RefreshUIState()
		{
			if (XInputObj.ActiveController == null || comboVJoyDevices.SelectedItem == null)
			{
				SetActiveState(false);
				buttonActivate.Enabled = false;
			}
			else
			{
				buttonActivate.Enabled = true;
			}

			RefreshComboboxes();
		}

		/// <summary>
		/// Updates the list of available XInput and vJoy controllers.
		/// </summary>
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


		/** Events */

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
				RemappingPanel.Enabled = true;
				RefreshUIState();
			}
		}

		private void buttonRefresh_Click(object sender, EventArgs e)
		{
			RefreshDeviceList();
		}

		private void onInputMappingChanged(object sender, EventArgs e)
		{
			UpdateInputMappings();
		}
	}
}
