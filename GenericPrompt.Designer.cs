namespace XJoy
{
	partial class GenericPrompt
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
			this.buttonB = new System.Windows.Forms.Button();
			this.buttonA = new System.Windows.Forms.Button();
			this.labelBody = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// buttonB
			// 
			this.buttonB.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.buttonB.Location = new System.Drawing.Point(152, 73);
			this.buttonB.Name = "buttonB";
			this.buttonB.Size = new System.Drawing.Size(120, 23);
			this.buttonB.TabIndex = 0;
			this.buttonB.Text = "<Option B>";
			this.buttonB.UseVisualStyleBackColor = true;
			// 
			// buttonA
			// 
			this.buttonA.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.buttonA.Location = new System.Drawing.Point(12, 73);
			this.buttonA.Name = "buttonA";
			this.buttonA.Size = new System.Drawing.Size(120, 23);
			this.buttonA.TabIndex = 0;
			this.buttonA.Text = "<Option A>";
			this.buttonA.UseVisualStyleBackColor = true;
			// 
			// labelBody
			// 
			this.labelBody.Location = new System.Drawing.Point(12, 9);
			this.labelBody.Name = "labelBody";
			this.labelBody.Size = new System.Drawing.Size(260, 61);
			this.labelBody.TabIndex = 1;
			this.labelBody.Text = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Mauris vehicula fermentu" +
    "m rhoncus. Duis orci neque, commodo at orci nec, ullamcorper tempus purus. Integ" +
    "er eu elementum erat.";
			this.labelBody.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// GenericPrompt
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(284, 99);
			this.ControlBox = false;
			this.Controls.Add(this.labelBody);
			this.Controls.Add(this.buttonA);
			this.Controls.Add(this.buttonB);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "GenericPrompt";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "GenericPrompt";
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button buttonB;
		private System.Windows.Forms.Button buttonA;
		private System.Windows.Forms.Label labelBody;
	}
}