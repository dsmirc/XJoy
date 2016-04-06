using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
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

		List<bool> ActiveXInputControllers = new List<bool>();
		List<bool> ActiveVJoyControllers = new List<bool>();

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

				string[] cmds = Environment.GetCommandLineArgs();
				HandleArguments(cmds);
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

		private void HandleArguments(string[] Args)
		{
			string fullCmd = "";
			for(int i = 0; i < Args.Length; i++)
			{
				fullCmd += Args[i] + " ";
			}
			fullCmd.TrimEnd(' ');
			Console.WriteLine("Cmd: " + fullCmd);

			for(int i = 0; i < Args.Length; i++)
			{
				HandleSingleArgument(Args, i);
			}
		}

		private void HandleSingleArgument(string[] Args, int Index)
		{
			if(Index < Args.Length)
			{
				bool indexIsLast = (Index == Args.Length - 1);
				string cmd = Args[Index];
				string cmd2 = "";
				if (!indexIsLast) cmd2 = Args[Index + 1];

				switch (cmd)
				{
					// Config file
					case "-c":
						{
							if (!indexIsLast)
							{
								Console.WriteLine("Detected config file: '" + cmd2 + "'");
								ReadConfigFile(cmd2);
							}
							break;
						}

					// Silent mode
					case "-s":
						{
							Console.WriteLine("Starting in silent mode (minimized).");
							this.WindowState = FormWindowState.Minimized;
							this.ShowInTaskbar = false;
							break;
						}

					// Auto-activate
					case "-a":
						{
							if (XInputObj.ActiveController != null && comboVJoyDevices.SelectedItem != null)
								Console.WriteLine("Auto-running feeder.");
							else
								Console.WriteLine("Could not auto-run; no valid controllers selected.");
							break;
						}

					default:
						break;
				}
			}
		}

		private void ReadConfigFile(string FName)
		{
			if(File.Exists(FName))
			{
				FileStream FS = File.Open(FName, FileMode.Open, FileAccess.Read);
				StreamReader FSR = new StreamReader(FS);

				Console.WriteLine("---- CONFIG START ----");
				string Line = null;
				while((Line = FSR.ReadLine()) != null)
				{
					string[] CfgLine = Line.Split('=');
					if(CfgLine.Length == 2)
					{
						string left = CfgLine[0].ToLower();
						string right = CfgLine[1].ToLower();

						// Selection of the xinput device
						if(left == "xinput")
						{
							if(right == "any")
							{
								comboDevices.SelectedIndex = 0;
								Console.WriteLine("Set XInput controller to first valid index.");
							}
							else
							{
								int index = -1;
								bool s = Int32.TryParse(right, out index);
								if (s)
								{
									if (index < ActiveXInputControllers.Count && ActiveXInputControllers[index])
									{
										ComboBox.ObjectCollection items = comboDevices.Items;
										for (int i = 0; i < items.Count; i++)
										{
											DeviceListItem dli = items[i] as DeviceListItem;
											if (dli != null && dli.DeviceIndex == index)
											{
												comboDevices.SelectedIndex = i;
												Console.WriteLine("Set XInput controller to #" + index);
												break;
											}
										}
									}
									else
									{
										Console.WriteLine("Invalid XInput controller index #" + index);
									}
								}
							}
						}
						// Selection of the vjoy device
						else if(left == "vjoy")
						{
							if(right == "any")
							{
								comboVJoyDevices.SelectedIndex = 0;
								Console.WriteLine("Set vJoy controller to first valid index.");
							}
							else
							{
								int index = -1;
								bool s = Int32.TryParse(right, out index);
								if (s)
								{
									if (index < ActiveVJoyControllers.Count && ActiveVJoyControllers[index])
									{
										ComboBox.ObjectCollection items = comboVJoyDevices.Items;
										for (int i = 0; i < items.Count; i++)
										{
											DeviceListItem dli = items[i] as DeviceListItem;
											if (dli != null && dli.DeviceIndex == index)
											{
												comboVJoyDevices.SelectedIndex = i;
												Console.WriteLine("Set vJoy controller to #" + index);
												break;
											}
										}
									}
									else
									{
										Console.WriteLine("Invalid vJoy controller index #" + index);
									}
								}
							}
						}
						else
						{
							ParseConfigMapping(left, right);
						}
					}
				}
				Console.WriteLine("----  CONFIG END  ----");

				FSR.Close();
			}
			else
			{
				Console.WriteLine("Could not find config file '" + FName + "'");
			}
		}

		private void ParseConfigMapping(string From, string To)
		{
			ComboBox inputControl = GetControlForInput(From);
			if(inputControl != null)
			{
				ComboBox.ObjectCollection items = inputControl.Items;
				HID_USAGES axis;
				bool isAxis = TryGetAxisFromString(To, out axis);

				if(isAxis)
				{
					for(int i = 0; i < items.Count; i++)
					{
						vJoyManager.AnalogInput inputData = items[i] as vJoyManager.AnalogInput;
						if(inputData != null)
						{
							if(inputData.Axis == axis)
							{
								inputControl.SelectedIndex = i;
								return;
							}
						}
					}
				}
				else
				{
					int buttonIndex;
					bool s = Int32.TryParse(To, out buttonIndex);
					if (s)
					{
						for (int i = 0; i < items.Count; i++)
						{
							vJoyManager.DigitalInput inputData = items[i] as vJoyManager.DigitalInput;
							if (inputData != null)
							{
								if (inputData.ButtonIndex == buttonIndex)
								{
									inputControl.SelectedIndex = i;
									return;
								}
							}
						}
						Console.WriteLine("Couldn't match button index #" + buttonIndex);
						return;
					}
				}
				Console.WriteLine("Failed to find input mapping for '" + To + "'");
				return;
			}
			else
			{
				Console.WriteLine("Failed to find input control for '" + From + "'");
				return;
			}
		}

		private ComboBox GetControlForInput(string From)
		{
			string lower = From.ToLower();
			switch (lower)
			{
				case "lsx":
					return inputLSX;
				case "lsy":
					return inputLSY;
				case "rsx":
					return inputRSX;
				case "rsy":
					return inputRSY;
				case "lt":
					return inputLT;
				case "rt":
					return inputRT;
				case "a":
					return inputA;
				case "b":
					return inputB;
				case "x":
					return inputX;
				case "y":
					return inputY;
				case "lb":
					return inputLB;
				case "rb":
					return inputRB;
				case "dpadleft":
					return inputDPadLeft;
				case "dpadright":
					return inputDPadRight;
				case "dpadup":
					return inputDPadUp;
				case "dpaddown":
					return inputDPadDown;
				case "leftstick":
					return inputLeftStick;
				case "rightstick":
					return inputRightStick;
				case "start":
					return inputStart;
				case "back":
					return inputBack;

				default:
					return null;
			}
		}

		private bool TryGetAxisFromString(string Input, out HID_USAGES Axis)
		{
			Axis = HID_USAGES.HID_USAGE_X;
			string inputLower = Input.ToLower();

			switch (inputLower)
			{
				case "x":
					Axis = HID_USAGES.HID_USAGE_X;
					break;
				case "y":
					Axis = HID_USAGES.HID_USAGE_Y;
					break;
				case "z":
					Axis = HID_USAGES.HID_USAGE_Z;
					break;
				case "rx":
					Axis = HID_USAGES.HID_USAGE_RX;
					break;
				case "ry":
					Axis = HID_USAGES.HID_USAGE_RY;
					break;
				case "rz":
					Axis = HID_USAGES.HID_USAGE_RZ;
					break;
				case "sl0":
					Axis = HID_USAGES.HID_USAGE_SL0;
					break;
				case "sl1":
					Axis = HID_USAGES.HID_USAGE_SL1;
					break;
				case "whl":
					Axis = HID_USAGES.HID_USAGE_WHL;
					break;
				case "pov":
					Axis = HID_USAGES.HID_USAGE_POV;
					break;

				default:
					return false;
			}

			return true;
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
								finalButtonStates[(int)inputMap.ButtonIndex - 1] |= XInputManager.GetInputStateButtonValueFromInputType(ref stateData, inputMap.XInput);
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
						vJoyObj.SetButton(i + 1, finalButtonStates[(int)i]);
					}

					for(int i = 0; i < AvailableHidValues.Count; i++)
					{
						HID_USAGES Axis = AvailableHidValues[i];
						vJoyObj.SetAxis(Axis, finalHidValues[Axis]);
					}

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

			ActiveXInputControllers.Clear();
			ActiveVJoyControllers.Clear();

			bool[] activeControllers = XInputObj.GetActiveControllerIndices();
			ActiveXInputControllers.AddRange(activeControllers);
			for(int i = 0; i < activeControllers.Length; i++)
			{
				if(activeControllers[i])
				{
					comboDevices.Items.Add(new DeviceListItem("XInput Controller #" + i, (byte)i));
				}
			}

			comboVJoyDevices.Items.Clear();
			bool[] activeVJoyDevices = vJoyObj.GetAvailableIndices();
			ActiveVJoyControllers.AddRange(activeVJoyDevices);
			for (int i = 0; i < activeVJoyDevices.Length; i++)
			{
				if(activeVJoyDevices[i])
				{
					comboVJoyDevices.Items.Add(new DeviceListItem("vJoy Controller #" + i, (byte)i));
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

		private void buttonClearMapping_Click(object sender, EventArgs e)
		{
			foreach (Control item in RemappingPanel.Controls)
			{
				ComboBox cb = item as ComboBox;
				if (cb == null)
					continue;

				string TagString = cb.Tag as string;
				if (TagString != null)
				{
					if (TagString == "InputAnalog" || TagString == "InputDigital")
					{
						cb.SelectedIndex = 0; // Should be '<none>'
					}
				}
			}
		}

		private void buttonLoadMapping_Click(object sender, EventArgs e)
		{
			DialogResult dr = openFileDialogMapping.ShowDialog();
			if(dr == DialogResult.OK)
			{
				ReadConfigFile(openFileDialogMapping.FileName);
			}
		}

		private void buttonSaveMapping_Click(object sender, EventArgs e)
		{
			DialogResult dr = saveFileDialogMapping.ShowDialog();
			if(dr == DialogResult.OK)
			{
				bool useSelectedXInput = false;
				bool useSelectedVJoy = false;
				DeviceListItem selectedvJoy = comboVJoyDevices.SelectedItem as DeviceListItem;

				if (XInputObj.ActiveController != null)
				{
					useSelectedXInput = GenericPrompt.DoPrompt("XInput Controller", "Use selected XInput controller index or any available controller?", "Selected (#" + XInputObj.LastActiveControllerIndex + ")", "Any");
				}

				if(selectedvJoy != null)
				{
					useSelectedVJoy = GenericPrompt.DoPrompt("vJoy Controller", "Use selected vJoy controller index or any available controller?", "Selected (#" + selectedvJoy.DeviceIndex + ")", "Any");
				}

				StreamWriter wr = new StreamWriter(saveFileDialogMapping.FileName, false);

				wr.WriteLine("XInput=" + ((useSelectedXInput) ? XInputObj.LastActiveControllerIndex.ToString() : "any"));
				wr.WriteLine("vJoy=" + ((useSelectedVJoy) ? selectedvJoy.DeviceIndex.ToString() : "any"));

				WriteInputLineToSaveFile(ref wr, inputLSX, "LSX");
				WriteInputLineToSaveFile(ref wr, inputLSY, "LSY");
				WriteInputLineToSaveFile(ref wr, inputRSX, "RSX");
				WriteInputLineToSaveFile(ref wr, inputRSY, "RSY");
				WriteInputLineToSaveFile(ref wr, inputLT, "LT");
				WriteInputLineToSaveFile(ref wr, inputRT, "RT");
				WriteInputLineToSaveFile(ref wr, inputA, "A");
				WriteInputLineToSaveFile(ref wr, inputB, "B");
				WriteInputLineToSaveFile(ref wr, inputX, "X");
				WriteInputLineToSaveFile(ref wr, inputY, "Y");
				WriteInputLineToSaveFile(ref wr, inputLB, "LB");
				WriteInputLineToSaveFile(ref wr, inputRB, "RB");
				WriteInputLineToSaveFile(ref wr, inputDPadLeft, "DPadLeft");
				WriteInputLineToSaveFile(ref wr, inputDPadRight, "DPadRight");
				WriteInputLineToSaveFile(ref wr, inputDPadUp, "DPadUp");
				WriteInputLineToSaveFile(ref wr, inputDPadDown, "DPadDown");
				WriteInputLineToSaveFile(ref wr, inputLeftStick, "LeftStick");
				WriteInputLineToSaveFile(ref wr, inputRightStick, "RightStick");
				WriteInputLineToSaveFile(ref wr, inputStart, "Start");
				WriteInputLineToSaveFile(ref wr, inputBack, "Back");

				wr.Close();				
			}
		}

		private void WriteInputLineToSaveFile(ref StreamWriter Writer, ComboBox Control, string XInputName)
		{
			if(Control.SelectedIndex != 0 && Control.SelectedItem != null)
			{
				vJoyManager.AnalogInput analog = Control.SelectedItem as vJoyManager.AnalogInput;
				if(analog != null)
				{
					string vJoyName = "";
					switch (analog.Axis)
					{
						case HID_USAGES.HID_USAGE_X:
							vJoyName = "X";
							break;
						case HID_USAGES.HID_USAGE_Y:
							vJoyName = "Y";
							break;
						case HID_USAGES.HID_USAGE_Z:
							vJoyName = "Z";
							break;
						case HID_USAGES.HID_USAGE_RX:
							vJoyName = "RX";
							break;
						case HID_USAGES.HID_USAGE_RY:
							vJoyName = "RY";
							break;
						case HID_USAGES.HID_USAGE_RZ:
							vJoyName = "RZ";
							break;
						case HID_USAGES.HID_USAGE_SL0:
							vJoyName = "SL0";
							break;
						case HID_USAGES.HID_USAGE_SL1:
							vJoyName = "SL1";
							break;
						case HID_USAGES.HID_USAGE_WHL:
							vJoyName = "WHL";
							break;
						case HID_USAGES.HID_USAGE_POV:
							vJoyName = "POV";
							break;
						default:
							return;
					}

					Writer.WriteLine(XInputName + "=" + vJoyName);
				}
				else
				{
					vJoyManager.DigitalInput digital = Control.SelectedItem as vJoyManager.DigitalInput;
					if(digital != null)
					{
						Writer.WriteLine(XInputName + "=" + digital.ButtonIndex.ToString());
					}
				}
			}
		}
	}
}
