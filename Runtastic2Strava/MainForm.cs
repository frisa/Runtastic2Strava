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
using Strava.NET.Client;
using Strava.NET.Model;
using Strava.NET.Api;

namespace Runtastic2Strava
{
	public partial class MainForm : Form
	{
		private DataTable _dtRuntasticActivities = new DataTable();
		private StravaToken _token;
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
			StravaToken _token = CStravaImporter.RenewToken();
			Configuration.ApiKey.Add("access_token", "1673f57e5ae557ad251c0e559e4afab3ab106c74");
			Configuration.ApiKey.Add("refresh_token", "ed9d3d6c85b3806a03bfb75e5b9bc41ee6edddfb");

			ActivitiesApi apiInstance = new ActivitiesApi();
			var name = "Running";  // string | The name of the activity.
			var type = "Run";  // string | Type of activity. For example - Run, Ride etc.
			var startDateLocal = "2020-11-06T00:05:19Z";  // string | ISO 8601 formatted date time.
			var elapsedTime = 56;  // int? | In seconds.
			var description = "Toto je popisek";  // string | Description of the activity. (optional) 
			float distance = 3.4F;  // float? | In meters. (optional)
			var trainer = 56;  // int? | Set to 1 to mark as a trainer activity. (optional) 
			var photoIds = "";  // string | List of native photo ids to attach to the activity. (optional) 
			var commute = 56;  // int? | Set to 1 to mark as commute. (optional) 

			try
			{
				// Create an Activity
				DetailedActivity result = apiInstance.CreateActivity(name, type, startDateLocal, elapsedTime, description, distance, trainer, photoIds, commute);
			}
			catch (Exception except)
			{
				MessageBox.Show(except.Message, "Strava Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
