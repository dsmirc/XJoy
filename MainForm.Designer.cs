namespace XJoy
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.MainNotifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
			this.NotifyContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.showXJoyWindowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.comboDevices = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.buttonRefresh = new System.Windows.Forms.Button();
			this.buttonInfo = new System.Windows.Forms.Button();
			this.buttonActivate = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.comboVJoyDevices = new System.Windows.Forms.ComboBox();
			this.labelInfo = new System.Windows.Forms.Label();
			this.panelControls = new System.Windows.Forms.Panel();
			this.RemappingPanel = new System.Windows.Forms.Panel();
			this.inputBack = new System.Windows.Forms.ComboBox();
			this.inputStart = new System.Windows.Forms.ComboBox();
			this.inputRightStick = new System.Windows.Forms.ComboBox();
			this.inputLeftStick = new System.Windows.Forms.ComboBox();
			this.inputDPadDown = new System.Windows.Forms.ComboBox();
			this.inputDPadUp = new System.Windows.Forms.ComboBox();
			this.inputDPadRight = new System.Windows.Forms.ComboBox();
			this.inputDPadLeft = new System.Windows.Forms.ComboBox();
			this.inputRB = new System.Windows.Forms.ComboBox();
			this.inputLB = new System.Windows.Forms.ComboBox();
			this.inputY = new System.Windows.Forms.ComboBox();
			this.inputX = new System.Windows.Forms.ComboBox();
			this.inputB = new System.Windows.Forms.ComboBox();
			this.inputA = new System.Windows.Forms.ComboBox();
			this.inputRT = new System.Windows.Forms.ComboBox();
			this.inputLT = new System.Windows.Forms.ComboBox();
			this.inputRSY = new System.Windows.Forms.ComboBox();
			this.inputRSX = new System.Windows.Forms.ComboBox();
			this.inputLSY = new System.Windows.Forms.ComboBox();
			this.label22 = new System.Windows.Forms.Label();
			this.label23 = new System.Windows.Forms.Label();
			this.label18 = new System.Windows.Forms.Label();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.label21 = new System.Windows.Forms.Label();
			this.label16 = new System.Windows.Forms.Label();
			this.label17 = new System.Windows.Forms.Label();
			this.label14 = new System.Windows.Forms.Label();
			this.label15 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.inputLSX = new System.Windows.Forms.ComboBox();
			this.label8 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.openFileDialogMapping = new System.Windows.Forms.OpenFileDialog();
			this.label3 = new System.Windows.Forms.Label();
			this.buttonLoadMapping = new System.Windows.Forms.Button();
			this.buttonSaveMapping = new System.Windows.Forms.Button();
			this.buttonClearMapping = new System.Windows.Forms.Button();
			this.saveFileDialogMapping = new System.Windows.Forms.SaveFileDialog();
			this.NotifyContextMenu.SuspendLayout();
			this.panelControls.SuspendLayout();
			this.RemappingPanel.SuspendLayout();
			this.SuspendLayout();
			// 
			// MainNotifyIcon
			// 
			this.MainNotifyIcon.BalloonTipIcon = System.Windows.Forms.ToolTipIcon.Info;
			this.MainNotifyIcon.BalloonTipText = "XJoy is down here and still running.";
			this.MainNotifyIcon.BalloonTipTitle = "XJoy";
			this.MainNotifyIcon.ContextMenuStrip = this.NotifyContextMenu;
			this.MainNotifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("MainNotifyIcon.Icon")));
			this.MainNotifyIcon.Text = "XJoy";
			this.MainNotifyIcon.Visible = true;
			this.MainNotifyIcon.DoubleClick += new System.EventHandler(this.MainNotifyIcon_DoubleClick);
			// 
			// NotifyContextMenu
			// 
			this.NotifyContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.showXJoyWindowToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
			this.NotifyContextMenu.Name = "NotifyContextMenu";
			this.NotifyContextMenu.Size = new System.Drawing.Size(179, 54);
			// 
			// showXJoyWindowToolStripMenuItem
			// 
			this.showXJoyWindowToolStripMenuItem.Name = "showXJoyWindowToolStripMenuItem";
			this.showXJoyWindowToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.showXJoyWindowToolStripMenuItem.Text = "Show XJoy Window";
			this.showXJoyWindowToolStripMenuItem.Click += new System.EventHandler(this.showXJoyWindowToolStripMenuItem_Click);
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(175, 6);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(178, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
			// 
			// comboDevices
			// 
			this.comboDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboDevices.FormattingEnabled = true;
			this.comboDevices.Items.AddRange(new object[] {
            "Xbox 360 Controller Wired",
            "NVidia Shield Controller",
            "RandomSoft© Basic Elite Airpad"});
			this.comboDevices.Location = new System.Drawing.Point(94, 3);
			this.comboDevices.Name = "comboDevices";
			this.comboDevices.Size = new System.Drawing.Size(209, 21);
			this.comboDevices.TabIndex = 1;
			this.comboDevices.SelectedIndexChanged += new System.EventHandler(this.comboDevices_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(3, 6);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(75, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "XInput Device";
			// 
			// buttonRefresh
			// 
			this.buttonRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonRefresh.BackgroundImage = global::XJoy.Properties.Resources.icon_refresh_darkgreen_24;
			this.buttonRefresh.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonRefresh.Location = new System.Drawing.Point(307, 2);
			this.buttonRefresh.Name = "buttonRefresh";
			this.buttonRefresh.Size = new System.Drawing.Size(23, 23);
			this.buttonRefresh.TabIndex = 3;
			this.buttonRefresh.UseVisualStyleBackColor = true;
			this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
			// 
			// buttonInfo
			// 
			this.buttonInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.buttonInfo.BackgroundImage = global::XJoy.Properties.Resources.icon_question_black_32;
			this.buttonInfo.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			this.buttonInfo.Location = new System.Drawing.Point(309, 326);
			this.buttonInfo.Name = "buttonInfo";
			this.buttonInfo.Size = new System.Drawing.Size(32, 32);
			this.buttonInfo.TabIndex = 4;
			this.buttonInfo.UseVisualStyleBackColor = true;
			this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
			// 
			// buttonActivate
			// 
			this.buttonActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonActivate.Location = new System.Drawing.Point(11, 331);
			this.buttonActivate.Name = "buttonActivate";
			this.buttonActivate.Size = new System.Drawing.Size(75, 23);
			this.buttonActivate.TabIndex = 5;
			this.buttonActivate.Text = "Activate";
			this.buttonActivate.UseVisualStyleBackColor = true;
			this.buttonActivate.Click += new System.EventHandler(this.buttonActivate_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(3, 33);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(66, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "vJoy Device";
			// 
			// comboVJoyDevices
			// 
			this.comboVJoyDevices.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.comboVJoyDevices.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboVJoyDevices.FormattingEnabled = true;
			this.comboVJoyDevices.Items.AddRange(new object[] {
            "Xbox 360 Controller Wired",
            "NVidia Shield Controller",
            "RandomSoft© Basic Elite Airpad"});
			this.comboVJoyDevices.Location = new System.Drawing.Point(94, 30);
			this.comboVJoyDevices.Name = "comboVJoyDevices";
			this.comboVJoyDevices.Size = new System.Drawing.Size(209, 21);
			this.comboVJoyDevices.TabIndex = 6;
			this.comboVJoyDevices.SelectedIndexChanged += new System.EventHandler(this.comboVJoyDevices_SelectedIndexChanged);
			// 
			// labelInfo
			// 
			this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelInfo.Location = new System.Drawing.Point(92, 326);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(204, 32);
			this.labelInfo.TabIndex = 8;
			this.labelInfo.Text = "Selected devices and press Activate to start.";
			this.labelInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// panelControls
			// 
			this.panelControls.Controls.Add(this.comboDevices);
			this.panelControls.Controls.Add(this.label1);
			this.panelControls.Controls.Add(this.buttonRefresh);
			this.panelControls.Controls.Add(this.label2);
			this.panelControls.Controls.Add(this.comboVJoyDevices);
			this.panelControls.Location = new System.Drawing.Point(11, 12);
			this.panelControls.Name = "panelControls";
			this.panelControls.Size = new System.Drawing.Size(330, 60);
			this.panelControls.TabIndex = 9;
			// 
			// RemappingPanel
			// 
			this.RemappingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.RemappingPanel.Controls.Add(this.inputBack);
			this.RemappingPanel.Controls.Add(this.inputStart);
			this.RemappingPanel.Controls.Add(this.inputRightStick);
			this.RemappingPanel.Controls.Add(this.inputLeftStick);
			this.RemappingPanel.Controls.Add(this.inputDPadDown);
			this.RemappingPanel.Controls.Add(this.inputDPadUp);
			this.RemappingPanel.Controls.Add(this.inputDPadRight);
			this.RemappingPanel.Controls.Add(this.inputDPadLeft);
			this.RemappingPanel.Controls.Add(this.inputRB);
			this.RemappingPanel.Controls.Add(this.inputLB);
			this.RemappingPanel.Controls.Add(this.inputY);
			this.RemappingPanel.Controls.Add(this.inputX);
			this.RemappingPanel.Controls.Add(this.inputB);
			this.RemappingPanel.Controls.Add(this.inputA);
			this.RemappingPanel.Controls.Add(this.inputRT);
			this.RemappingPanel.Controls.Add(this.inputLT);
			this.RemappingPanel.Controls.Add(this.inputRSY);
			this.RemappingPanel.Controls.Add(this.inputRSX);
			this.RemappingPanel.Controls.Add(this.inputLSY);
			this.RemappingPanel.Controls.Add(this.label22);
			this.RemappingPanel.Controls.Add(this.label23);
			this.RemappingPanel.Controls.Add(this.label18);
			this.RemappingPanel.Controls.Add(this.label19);
			this.RemappingPanel.Controls.Add(this.label20);
			this.RemappingPanel.Controls.Add(this.label21);
			this.RemappingPanel.Controls.Add(this.label16);
			this.RemappingPanel.Controls.Add(this.label17);
			this.RemappingPanel.Controls.Add(this.label14);
			this.RemappingPanel.Controls.Add(this.label15);
			this.RemappingPanel.Controls.Add(this.label12);
			this.RemappingPanel.Controls.Add(this.label13);
			this.RemappingPanel.Controls.Add(this.label11);
			this.RemappingPanel.Controls.Add(this.label10);
			this.RemappingPanel.Controls.Add(this.inputLSX);
			this.RemappingPanel.Controls.Add(this.label8);
			this.RemappingPanel.Controls.Add(this.label9);
			this.RemappingPanel.Controls.Add(this.label6);
			this.RemappingPanel.Controls.Add(this.label7);
			this.RemappingPanel.Controls.Add(this.label5);
			this.RemappingPanel.Controls.Add(this.label4);
			this.RemappingPanel.Enabled = false;
			this.RemappingPanel.Location = new System.Drawing.Point(11, 117);
			this.RemappingPanel.Name = "RemappingPanel";
			this.RemappingPanel.Size = new System.Drawing.Size(330, 203);
			this.RemappingPanel.TabIndex = 11;
			// 
			// inputBack
			// 
			this.inputBack.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputBack.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputBack.FormattingEnabled = true;
			this.inputBack.Location = new System.Drawing.Point(242, 182);
			this.inputBack.Name = "inputBack";
			this.inputBack.Size = new System.Drawing.Size(88, 21);
			this.inputBack.TabIndex = 50;
			this.inputBack.Tag = "InputDigital";
			this.inputBack.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputStart
			// 
			this.inputStart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputStart.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputStart.FormattingEnabled = true;
			this.inputStart.Location = new System.Drawing.Point(242, 162);
			this.inputStart.Name = "inputStart";
			this.inputStart.Size = new System.Drawing.Size(88, 21);
			this.inputStart.TabIndex = 49;
			this.inputStart.Tag = "InputDigital";
			this.inputStart.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputRightStick
			// 
			this.inputRightStick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputRightStick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputRightStick.FormattingEnabled = true;
			this.inputRightStick.Location = new System.Drawing.Point(242, 142);
			this.inputRightStick.Name = "inputRightStick";
			this.inputRightStick.Size = new System.Drawing.Size(88, 21);
			this.inputRightStick.TabIndex = 48;
			this.inputRightStick.Tag = "InputDigital";
			this.inputRightStick.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputLeftStick
			// 
			this.inputLeftStick.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputLeftStick.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputLeftStick.FormattingEnabled = true;
			this.inputLeftStick.Location = new System.Drawing.Point(242, 122);
			this.inputLeftStick.Name = "inputLeftStick";
			this.inputLeftStick.Size = new System.Drawing.Size(88, 21);
			this.inputLeftStick.TabIndex = 47;
			this.inputLeftStick.Tag = "InputDigital";
			this.inputLeftStick.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputDPadDown
			// 
			this.inputDPadDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputDPadDown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputDPadDown.FormattingEnabled = true;
			this.inputDPadDown.Location = new System.Drawing.Point(242, 102);
			this.inputDPadDown.Name = "inputDPadDown";
			this.inputDPadDown.Size = new System.Drawing.Size(88, 21);
			this.inputDPadDown.TabIndex = 46;
			this.inputDPadDown.Tag = "InputDigital";
			this.inputDPadDown.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputDPadUp
			// 
			this.inputDPadUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputDPadUp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputDPadUp.FormattingEnabled = true;
			this.inputDPadUp.Location = new System.Drawing.Point(242, 82);
			this.inputDPadUp.Name = "inputDPadUp";
			this.inputDPadUp.Size = new System.Drawing.Size(88, 21);
			this.inputDPadUp.TabIndex = 45;
			this.inputDPadUp.Tag = "InputDigital";
			this.inputDPadUp.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputDPadRight
			// 
			this.inputDPadRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputDPadRight.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputDPadRight.FormattingEnabled = true;
			this.inputDPadRight.Location = new System.Drawing.Point(242, 62);
			this.inputDPadRight.Name = "inputDPadRight";
			this.inputDPadRight.Size = new System.Drawing.Size(88, 21);
			this.inputDPadRight.TabIndex = 44;
			this.inputDPadRight.Tag = "InputDigital";
			this.inputDPadRight.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputDPadLeft
			// 
			this.inputDPadLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputDPadLeft.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputDPadLeft.FormattingEnabled = true;
			this.inputDPadLeft.Location = new System.Drawing.Point(242, 42);
			this.inputDPadLeft.Name = "inputDPadLeft";
			this.inputDPadLeft.Size = new System.Drawing.Size(88, 21);
			this.inputDPadLeft.TabIndex = 43;
			this.inputDPadLeft.Tag = "InputDigital";
			this.inputDPadLeft.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputRB
			// 
			this.inputRB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputRB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputRB.FormattingEnabled = true;
			this.inputRB.Location = new System.Drawing.Point(242, 22);
			this.inputRB.Name = "inputRB";
			this.inputRB.Size = new System.Drawing.Size(88, 21);
			this.inputRB.TabIndex = 42;
			this.inputRB.Tag = "InputDigital";
			this.inputRB.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputLB
			// 
			this.inputLB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputLB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputLB.FormattingEnabled = true;
			this.inputLB.Location = new System.Drawing.Point(242, 2);
			this.inputLB.Name = "inputLB";
			this.inputLB.Size = new System.Drawing.Size(88, 21);
			this.inputLB.TabIndex = 41;
			this.inputLB.Tag = "InputDigital";
			this.inputLB.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputY
			// 
			this.inputY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputY.FormattingEnabled = true;
			this.inputY.Location = new System.Drawing.Point(76, 182);
			this.inputY.Name = "inputY";
			this.inputY.Size = new System.Drawing.Size(88, 21);
			this.inputY.TabIndex = 40;
			this.inputY.Tag = "InputDigital";
			this.inputY.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputX
			// 
			this.inputX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputX.FormattingEnabled = true;
			this.inputX.Location = new System.Drawing.Point(76, 162);
			this.inputX.Name = "inputX";
			this.inputX.Size = new System.Drawing.Size(88, 21);
			this.inputX.TabIndex = 39;
			this.inputX.Tag = "InputDigital";
			this.inputX.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputB
			// 
			this.inputB.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputB.FormattingEnabled = true;
			this.inputB.Location = new System.Drawing.Point(76, 142);
			this.inputB.Name = "inputB";
			this.inputB.Size = new System.Drawing.Size(88, 21);
			this.inputB.TabIndex = 38;
			this.inputB.Tag = "InputDigital";
			this.inputB.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputA
			// 
			this.inputA.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputA.FormattingEnabled = true;
			this.inputA.Location = new System.Drawing.Point(76, 122);
			this.inputA.Name = "inputA";
			this.inputA.Size = new System.Drawing.Size(88, 21);
			this.inputA.TabIndex = 37;
			this.inputA.Tag = "InputDigital";
			this.inputA.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputRT
			// 
			this.inputRT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputRT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputRT.FormattingEnabled = true;
			this.inputRT.Location = new System.Drawing.Point(76, 102);
			this.inputRT.Name = "inputRT";
			this.inputRT.Size = new System.Drawing.Size(88, 21);
			this.inputRT.TabIndex = 36;
			this.inputRT.Tag = "InputAnalog";
			this.inputRT.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputLT
			// 
			this.inputLT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputLT.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputLT.FormattingEnabled = true;
			this.inputLT.Location = new System.Drawing.Point(76, 82);
			this.inputLT.Name = "inputLT";
			this.inputLT.Size = new System.Drawing.Size(88, 21);
			this.inputLT.TabIndex = 35;
			this.inputLT.Tag = "InputAnalog";
			this.inputLT.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputRSY
			// 
			this.inputRSY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputRSY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputRSY.FormattingEnabled = true;
			this.inputRSY.Location = new System.Drawing.Point(76, 62);
			this.inputRSY.Name = "inputRSY";
			this.inputRSY.Size = new System.Drawing.Size(88, 21);
			this.inputRSY.TabIndex = 34;
			this.inputRSY.Tag = "InputAnalog";
			this.inputRSY.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputRSX
			// 
			this.inputRSX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputRSX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputRSX.FormattingEnabled = true;
			this.inputRSX.Location = new System.Drawing.Point(76, 42);
			this.inputRSX.Name = "inputRSX";
			this.inputRSX.Size = new System.Drawing.Size(88, 21);
			this.inputRSX.TabIndex = 33;
			this.inputRSX.Tag = "InputAnalog";
			this.inputRSX.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// inputLSY
			// 
			this.inputLSY.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputLSY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputLSY.FormattingEnabled = true;
			this.inputLSY.Location = new System.Drawing.Point(76, 22);
			this.inputLSY.Name = "inputLSY";
			this.inputLSY.Size = new System.Drawing.Size(88, 21);
			this.inputLSY.TabIndex = 32;
			this.inputLSY.Tag = "InputAnalog";
			this.inputLSY.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// label22
			// 
			this.label22.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label22.Location = new System.Drawing.Point(170, 181);
			this.label22.Name = "label22";
			this.label22.Size = new System.Drawing.Size(66, 20);
			this.label22.TabIndex = 31;
			this.label22.Text = "Back";
			this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label23
			// 
			this.label23.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label23.Location = new System.Drawing.Point(170, 161);
			this.label23.Name = "label23";
			this.label23.Size = new System.Drawing.Size(66, 20);
			this.label23.TabIndex = 30;
			this.label23.Text = "Start";
			this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label18
			// 
			this.label18.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label18.Location = new System.Drawing.Point(170, 141);
			this.label18.Name = "label18";
			this.label18.Size = new System.Drawing.Size(66, 20);
			this.label18.TabIndex = 29;
			this.label18.Text = "Right Stick";
			this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label19
			// 
			this.label19.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label19.Location = new System.Drawing.Point(170, 121);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(66, 20);
			this.label19.TabIndex = 28;
			this.label19.Text = "Left Stick";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label20
			// 
			this.label20.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label20.Location = new System.Drawing.Point(170, 21);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(66, 20);
			this.label20.TabIndex = 27;
			this.label20.Text = "RB";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label21
			// 
			this.label21.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label21.Location = new System.Drawing.Point(170, 1);
			this.label21.Name = "label21";
			this.label21.Size = new System.Drawing.Size(66, 20);
			this.label21.TabIndex = 26;
			this.label21.Text = "LB";
			this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label16
			// 
			this.label16.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label16.Location = new System.Drawing.Point(170, 101);
			this.label16.Name = "label16";
			this.label16.Size = new System.Drawing.Size(66, 20);
			this.label16.TabIndex = 25;
			this.label16.Text = "DPad Down";
			this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label17
			// 
			this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label17.Location = new System.Drawing.Point(170, 81);
			this.label17.Name = "label17";
			this.label17.Size = new System.Drawing.Size(66, 20);
			this.label17.TabIndex = 24;
			this.label17.Text = "DPad Up";
			this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label14
			// 
			this.label14.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label14.Location = new System.Drawing.Point(170, 61);
			this.label14.Name = "label14";
			this.label14.Size = new System.Drawing.Size(66, 20);
			this.label14.TabIndex = 23;
			this.label14.Text = "DPad Right";
			this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label15
			// 
			this.label15.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label15.Location = new System.Drawing.Point(170, 41);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(66, 20);
			this.label15.TabIndex = 22;
			this.label15.Text = "DPad Left";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label12
			// 
			this.label12.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label12.Location = new System.Drawing.Point(4, 181);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(66, 20);
			this.label12.TabIndex = 21;
			this.label12.Text = "Y";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label13.Location = new System.Drawing.Point(4, 161);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(66, 20);
			this.label13.TabIndex = 20;
			this.label13.Text = "X";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label11
			// 
			this.label11.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label11.Location = new System.Drawing.Point(4, 141);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(66, 20);
			this.label11.TabIndex = 19;
			this.label11.Text = "B";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label10
			// 
			this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label10.Location = new System.Drawing.Point(4, 121);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(66, 20);
			this.label10.TabIndex = 18;
			this.label10.Text = "A";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// inputLSX
			// 
			this.inputLSX.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.inputLSX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.inputLSX.FormattingEnabled = true;
			this.inputLSX.Location = new System.Drawing.Point(76, 2);
			this.inputLSX.Name = "inputLSX";
			this.inputLSX.Size = new System.Drawing.Size(88, 21);
			this.inputLSX.TabIndex = 17;
			this.inputLSX.Tag = "InputAnalog";
			this.inputLSX.SelectedIndexChanged += new System.EventHandler(this.onInputMappingChanged);
			// 
			// label8
			// 
			this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label8.Location = new System.Drawing.Point(4, 101);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(66, 20);
			this.label8.TabIndex = 16;
			this.label8.Text = "RT";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label9
			// 
			this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label9.Location = new System.Drawing.Point(4, 81);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(66, 20);
			this.label9.TabIndex = 15;
			this.label9.Text = "LT";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label6
			// 
			this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label6.Location = new System.Drawing.Point(4, 61);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(66, 20);
			this.label6.TabIndex = 14;
			this.label6.Text = "RS Y";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label7.Location = new System.Drawing.Point(4, 41);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(66, 20);
			this.label7.TabIndex = 13;
			this.label7.Text = "RS X";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label5
			// 
			this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label5.Location = new System.Drawing.Point(4, 21);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(66, 20);
			this.label5.TabIndex = 12;
			this.label5.Text = "LS Y";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label4
			// 
			this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.label4.Location = new System.Drawing.Point(4, 1);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(66, 20);
			this.label4.TabIndex = 11;
			this.label4.Text = "LS X";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// openFileDialogMapping
			// 
			this.openFileDialogMapping.AddExtension = false;
			this.openFileDialogMapping.FileName = "openFileDialogMapping";
			this.openFileDialogMapping.Title = "Open Input Mapping File";
			// 
			// label3
			// 
			this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label3.Location = new System.Drawing.Point(12, 75);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(177, 45);
			this.label3.TabIndex = 10;
			this.label3.Text = "Input Remapping";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// buttonLoadMapping
			// 
			this.buttonLoadMapping.Location = new System.Drawing.Point(298, 88);
			this.buttonLoadMapping.Name = "buttonLoadMapping";
			this.buttonLoadMapping.Size = new System.Drawing.Size(44, 23);
			this.buttonLoadMapping.TabIndex = 51;
			this.buttonLoadMapping.Text = "Load";
			this.buttonLoadMapping.UseVisualStyleBackColor = true;
			this.buttonLoadMapping.Click += new System.EventHandler(this.buttonLoadMapping_Click);
			// 
			// buttonSaveMapping
			// 
			this.buttonSaveMapping.Location = new System.Drawing.Point(252, 88);
			this.buttonSaveMapping.Name = "buttonSaveMapping";
			this.buttonSaveMapping.Size = new System.Drawing.Size(44, 23);
			this.buttonSaveMapping.TabIndex = 51;
			this.buttonSaveMapping.Text = "Save";
			this.buttonSaveMapping.UseVisualStyleBackColor = true;
			this.buttonSaveMapping.Click += new System.EventHandler(this.buttonSaveMapping_Click);
			// 
			// buttonClearMapping
			// 
			this.buttonClearMapping.Location = new System.Drawing.Point(184, 88);
			this.buttonClearMapping.Name = "buttonClearMapping";
			this.buttonClearMapping.Size = new System.Drawing.Size(44, 23);
			this.buttonClearMapping.TabIndex = 51;
			this.buttonClearMapping.Text = "Clear";
			this.buttonClearMapping.UseVisualStyleBackColor = true;
			this.buttonClearMapping.Click += new System.EventHandler(this.buttonClearMapping_Click);
			// 
			// saveFileDialogMapping
			// 
			this.saveFileDialogMapping.AddExtension = false;
			this.saveFileDialogMapping.Title = "Save Input Mapping File";
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(351, 366);
			this.Controls.Add(this.buttonClearMapping);
			this.Controls.Add(this.buttonSaveMapping);
			this.Controls.Add(this.RemappingPanel);
			this.Controls.Add(this.buttonLoadMapping);
			this.Controls.Add(this.panelControls);
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.buttonActivate);
			this.Controls.Add(this.buttonInfo);
			this.Controls.Add(this.label3);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "MainForm";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "XJoy - XInput to vJoy";
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.NotifyContextMenu.ResumeLayout(false);
			this.panelControls.ResumeLayout(false);
			this.panelControls.PerformLayout();
			this.RemappingPanel.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.NotifyIcon MainNotifyIcon;
		private System.Windows.Forms.ContextMenuStrip NotifyContextMenu;
		private System.Windows.Forms.ToolStripMenuItem showXJoyWindowToolStripMenuItem;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.ComboBox comboDevices;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button buttonRefresh;
		private System.Windows.Forms.Button buttonInfo;
		private System.Windows.Forms.Button buttonActivate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox comboVJoyDevices;
		private System.Windows.Forms.Label labelInfo;
		private System.Windows.Forms.Panel panelControls;
		private System.Windows.Forms.Panel RemappingPanel;
		private System.Windows.Forms.ComboBox inputBack;
		private System.Windows.Forms.ComboBox inputStart;
		private System.Windows.Forms.ComboBox inputRightStick;
		private System.Windows.Forms.ComboBox inputLeftStick;
		private System.Windows.Forms.ComboBox inputDPadDown;
		private System.Windows.Forms.ComboBox inputDPadUp;
		private System.Windows.Forms.ComboBox inputDPadRight;
		private System.Windows.Forms.ComboBox inputDPadLeft;
		private System.Windows.Forms.ComboBox inputRB;
		private System.Windows.Forms.ComboBox inputLB;
		private System.Windows.Forms.ComboBox inputY;
		private System.Windows.Forms.ComboBox inputX;
		private System.Windows.Forms.ComboBox inputB;
		private System.Windows.Forms.ComboBox inputA;
		private System.Windows.Forms.ComboBox inputRT;
		private System.Windows.Forms.ComboBox inputLT;
		private System.Windows.Forms.ComboBox inputRSY;
		private System.Windows.Forms.ComboBox inputRSX;
		private System.Windows.Forms.ComboBox inputLSY;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ComboBox inputLSX;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.OpenFileDialog openFileDialogMapping;
		private System.Windows.Forms.Button buttonClearMapping;
		private System.Windows.Forms.Button buttonSaveMapping;
		private System.Windows.Forms.Button buttonLoadMapping;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.SaveFileDialog saveFileDialogMapping;
	}
}

