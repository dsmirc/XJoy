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
	public partial class InfoWindow : Form
	{
		public InfoWindow()
		{
			InitializeComponent();

			Version v = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			labelVersion.Text = "v " + v.Major + "." + v.Minor + "." + v.Build + " r" + v.Revision;
		}

		private void linkMasterKenth_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.masterkenth.com/");
		}
	}
}
