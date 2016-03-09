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
			this.NotifyContextMenu.SuspendLayout();
			this.panelControls.SuspendLayout();
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
			this.NotifyContextMenu.Size = new System.Drawing.Size(179, 76);
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
			this.comboDevices.Size = new System.Drawing.Size(253, 21);
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
			this.buttonRefresh.Location = new System.Drawing.Point(351, 2);
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
			this.buttonInfo.Location = new System.Drawing.Point(353, 80);
			this.buttonInfo.Name = "buttonInfo";
			this.buttonInfo.Size = new System.Drawing.Size(32, 32);
			this.buttonInfo.TabIndex = 4;
			this.buttonInfo.UseVisualStyleBackColor = true;
			this.buttonInfo.Click += new System.EventHandler(this.buttonInfo_Click);
			// 
			// buttonActivate
			// 
			this.buttonActivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.buttonActivate.Location = new System.Drawing.Point(11, 85);
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
			this.comboVJoyDevices.Size = new System.Drawing.Size(253, 21);
			this.comboVJoyDevices.TabIndex = 6;
			this.comboVJoyDevices.SelectedIndexChanged += new System.EventHandler(this.comboVJoyDevices_SelectedIndexChanged);
			// 
			// labelInfo
			// 
			this.labelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.labelInfo.AutoSize = true;
			this.labelInfo.Location = new System.Drawing.Point(92, 90);
			this.labelInfo.Name = "labelInfo";
			this.labelInfo.Size = new System.Drawing.Size(218, 13);
			this.labelInfo.TabIndex = 8;
			this.labelInfo.Text = "Selected devices and press Activate to start.";
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
			this.panelControls.Size = new System.Drawing.Size(374, 60);
			this.panelControls.TabIndex = 9;
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(395, 120);
			this.Controls.Add(this.panelControls);
			this.Controls.Add(this.labelInfo);
			this.Controls.Add(this.buttonActivate);
			this.Controls.Add(this.buttonInfo);
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
			this.ResumeLayout(false);
			this.PerformLayout();

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
	}
}

