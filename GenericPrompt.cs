using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XJoy
{
	public partial class GenericPrompt : Form
	{
		public GenericPrompt()
		{
			InitializeComponent();
		}

		/// <summary>
		/// Creates a prompt
		/// </summary>
		/// <param name="Title">Text displayed at the top.</param>
		/// <param name="BodyText">Main display text.</param>
		/// <param name="OptionA">Option text for option A (left).</param>
		/// <param name="OptionB">Option text for option B (right).</param>
		/// <returns>True if option A was used.</returns>
		public static bool DoPrompt(string Title, string BodyText, string OptionA, string OptionB)
		{
			GenericPrompt GP = new GenericPrompt();
			GP.Text = Title;
			GP.labelBody.Text = BodyText;
			GP.buttonA.Text = OptionA;
			GP.buttonB.Text = OptionB;
			DialogResult dr = GP.ShowDialog();
						
			return dr == DialogResult.OK;
		}

		private void OnButtonClicked(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
