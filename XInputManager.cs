using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.XInput;

namespace XJoy
{
	class XInputManager
	{
		public struct InputState
		{
			public bool bButtonA;
			public bool bButtonB;
			public bool bButtonX;
			public bool bButtonY;

			public bool bButtonDPadLeft;
			public bool bButtonDPadRight;
			public bool bButtonDPadUp;
			public bool bButtonDPadDown;

			public bool bButtonLeftThumb;
			public bool bButtonRightThumb;

			public bool bButtonLeftShoulder;
			public bool bButtonRightShoulder;

			public bool bButtonStart;
			public bool bButtonBack;

			public short LeftStickX;
			public short LeftStickY;

			public short RightStickX;
			public short RightStickY;

			public byte LeftTrigger;
			public byte RightTrigger;
		}

		private Controller m_activeController = null;

		public Controller ActiveController
		{
			get
			{
				return m_activeController;
			}
		}

		public XInputManager()
		{
		}

		public void InitControllerIndex(byte Index)
		{
			m_activeController = null;
			if (Index >= (byte)UserIndex.One && Index <= (byte)UserIndex.Four)
			{
				m_activeController = new Controller((UserIndex)Index);
				if (!m_activeController.IsConnected)
					m_activeController = null;
			}
		}

		public bool[] GetActiveControllerIndices()
		{
			bool[] activeControllers = new bool[4];

			Controller controller1 = new Controller(UserIndex.One);
			activeControllers[0] = controller1.IsConnected;
			Controller controller2 = new Controller(UserIndex.Two);
			activeControllers[1] = controller2.IsConnected;
			Controller controller3 = new Controller(UserIndex.Three);
			activeControllers[2] = controller3.IsConnected;
			Controller controller4 = new Controller(UserIndex.Four);
			activeControllers[3] = controller4.IsConnected;

			return activeControllers;
		}

		public InputState GetState()
		{
			if (m_activeController == null || !m_activeController.IsConnected)
				return new InputState();

			State ControllerData = m_activeController.GetState();

			InputState OutState = new InputState();
			OutState.bButtonA = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.A) == GamepadButtonFlags.A;
			OutState.bButtonB = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.B) == GamepadButtonFlags.B;
			OutState.bButtonX = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.X) == GamepadButtonFlags.X;
			OutState.bButtonY = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.Y) == GamepadButtonFlags.Y;
			OutState.bButtonDPadLeft = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.DPadLeft) == GamepadButtonFlags.DPadLeft;
			OutState.bButtonDPadRight = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.DPadRight) == GamepadButtonFlags.DPadRight;
			OutState.bButtonDPadUp = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.DPadUp) == GamepadButtonFlags.DPadUp;
			OutState.bButtonDPadDown = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.DPadDown) == GamepadButtonFlags.DPadDown;
			OutState.bButtonLeftThumb = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.LeftThumb) == GamepadButtonFlags.LeftThumb;
			OutState.bButtonRightThumb = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.RightThumb) == GamepadButtonFlags.RightThumb;
			OutState.bButtonLeftShoulder = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.LeftShoulder) == GamepadButtonFlags.LeftShoulder;
			OutState.bButtonRightShoulder = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.RightShoulder) == GamepadButtonFlags.RightShoulder;
			OutState.bButtonStart = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.Start) == GamepadButtonFlags.Start;
			OutState.bButtonBack = (ControllerData.Gamepad.Buttons & GamepadButtonFlags.Back) == GamepadButtonFlags.Back;
			OutState.LeftStickX = ControllerData.Gamepad.LeftThumbX;
			OutState.LeftStickY = ControllerData.Gamepad.LeftThumbY;
			OutState.RightStickX = ControllerData.Gamepad.RightThumbX;
			OutState.RightStickY = ControllerData.Gamepad.RightThumbY;
			OutState.LeftTrigger = ControllerData.Gamepad.LeftTrigger;
			OutState.RightTrigger = ControllerData.Gamepad.RightTrigger;

			return OutState;
		}
	}
}
