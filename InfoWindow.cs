using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

namespace XJoy
{
	public partial class InfoWindow : Form
	{
		public InfoWindow()
		{
			InitializeComponent();

			string gitVersion = "<unknown version>";

			using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("XJoy.gitversion.txt"))
			{
				if(stream != null)
				{
					using (StreamReader reader = new StreamReader(stream))
					{
						gitVersion = reader.ReadLine();
					}
				}
			}

			Version assemblyVersion = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
			string assemblyDisplay = String.Format("{0}.{1}.{2} r{3}",
				assemblyVersion.Major, assemblyVersion.Minor, assemblyVersion.Build, assemblyVersion.Revision);

			labelVersion.Text = gitVersion;
			labelAssemblyVersion.Text = assemblyDisplay;
		}

		private void linkMasterKenth_Click(object sender, EventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.masterkenth.com/");
		}
	}
}
