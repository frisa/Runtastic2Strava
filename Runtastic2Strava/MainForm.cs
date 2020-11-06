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

namespace Runtastic2Strava
{
	public partial class MainForm : Form
	{
		private DataTable _dtRuntasticActivities = new DataTable();
		public MainForm()
		{
			InitializeComponent();
			
		}

		private void btnLoad_Click(object sender, EventArgs e)
		{
			String sPathSportSessions = tbPath.Text + "Sport-sessions";
			string[] fileEntries = Directory.GetFiles(sPathSportSessions);
			PropertyDescriptorCollection props = TypeDescriptor.GetProperties(typeof(RuntasticActivity));
			_dtRuntasticActivities = new DataTable();
			for (int i = 0; i < props.Count; i++)
			{
				PropertyDescriptor prop = props[i];
				_dtRuntasticActivities.Columns.Add(prop.Name, prop.PropertyType);
			}
			foreach (string fileName in fileEntries)
			{
				String jsonString = System.IO.File.ReadAllText(fileName);
				RuntasticActivity Activity = Newtonsoft.Json.JsonConvert.DeserializeObject<RuntasticActivity>(jsonString);
				object[] values = new object[props.Count];
				for (int i = 0; i < values.Length; i++)
				{
					values[i] = props[i].GetValue(Activity);
				}
				_dtRuntasticActivities.Rows.Add(values);
			}
			dgvImport.DataSource = _dtRuntasticActivities;
		}

		private void btnBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbdExport = new FolderBrowserDialog();
			if (DialogResult.OK == fbdExport.ShowDialog())
			{
				tbPath.Text = fbdExport.SelectedPath;
			}
		}

		private void btnImport_Click(object sender, EventArgs e)
		{

		}
	}
}
