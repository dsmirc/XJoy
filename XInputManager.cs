using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SharpDX.XInput;

namespace XJoy
{
	public class XInputManager
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

		public enum Inputs
		{
			LSX = 0,
			LSY,
			RSX,
			RSY,
			LT,
			RT,
			A,
			B,
			X,
			Y,
			LB,
			RB,
			DPadLeft,
			DPadRight,
			DPadUp,
			DPadDown,
			LeftStick,
			RightStick,
			Start,
			Back
		}

		// Should match length of Inputs
		public const short InputCount = 20;
		public byte LastActiveControllerIndex = 0;

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
				LastActiveControllerIndex = Index;

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

		public static bool GetInputStateButtonValueFromInputType(ref InputState StateData, Inputs Button)
		{
			switch (Button)
			{
				case Inputs.A:
					return StateData.bButtonA;
				case Inputs.B:
					return StateData.bButtonB;
				case Inputs.X:
					return StateData.bButtonX;
				case Inputs.Y:
					return StateData.bButtonY;
				case Inputs.LB:
					return StateData.bButtonLeftShoulder;
				case Inputs.RB:
					return StateData.bButtonRightShoulder;
				case Inputs.DPadLeft:
					return StateData.bButtonDPadLeft;
				case Inputs.DPadRight:
					return StateData.bButtonDPadRight;
				case Inputs.DPadUp:
					return StateData.bButtonDPadUp;
				case Inputs.DPadDown:
					return StateData.bButtonDPadDown;
				case Inputs.LeftStick:
					return StateData.bButtonLeftThumb;
				case Inputs.RightStick:
					return StateData.bButtonRightThumb;
				case Inputs.Start:
					return StateData.bButtonStart;
				case Inputs.Back:
					return StateData.bButtonBack;

				case Inputs.LSX:
				case Inputs.LSY:
				case Inputs.RSX:
				case Inputs.RSY:
				case Inputs.LT:
				case Inputs.RT:
				default:
					return false;
			}
		}

		public static short GetInputStateAxisValueFromInputType(ref InputState StateData, Inputs Axis)
		{
			switch (Axis)
			{
				case Inputs.LSX:
					return StateData.LeftStickX;
				case Inputs.LSY:
					return StateData.LeftStickY;
				case Inputs.RSX:
					return StateData.RightStickX;
				case Inputs.RSY:
					return StateData.RightStickY;
				case Inputs.LT:
					return StateData.LeftTrigger;
				case Inputs.RT:
					return StateData.RightTrigger;
				case Inputs.A:
				case Inputs.B:
				case Inputs.X:
				case Inputs.Y:
				case Inputs.LB:
				case Inputs.RB:
				case Inputs.DPadLeft:
				case Inputs.DPadRight:
				case Inputs.DPadUp:
				case Inputs.DPadDown:
				case Inputs.LeftStick:
				case Inputs.RightStick:
				case Inputs.Start:
				case Inputs.Back:
				default:
					return 0;
			}
		}

		public static int[] GetAxisLimitsForInput(Inputs Axis)
		{
			switch (Axis)
			{
				case Inputs.LSX:
				case Inputs.LSY:
				case Inputs.RSX:
				case Inputs.RSY:
					return new int[] { -32768, 32767 };
				case Inputs.LT:
				case Inputs.RT:
					return new int[] { 0, 255 };
				case Inputs.A:
				case Inputs.B:
				case Inputs.X:
				case Inputs.Y:
				case Inputs.LB:
				case Inputs.RB:
				case Inputs.DPadLeft:
				case Inputs.DPadRight:
				case Inputs.DPadUp:
				case Inputs.DPadDown:
				case Inputs.LeftStick:
				case Inputs.RightStick:
				case Inputs.Start:
				case Inputs.Back:
				default:
					return new int[] { 0, 0 };
			}
		}
	}
}
