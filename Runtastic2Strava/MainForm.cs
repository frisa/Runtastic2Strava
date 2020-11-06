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


using Newtonsoft.Json;

namespace Runtastic2Strava
{
	public partial class MainForm : Form
	{
		private BindingList<RuntasticActivity> _blRuntasticActivities = new BindingList<RuntasticActivity>();
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
			_blRuntasticActivities = new BindingList<RuntasticActivity>();

			foreach (string fileName in fileEntries)
			{
				String jsonString = System.IO.File.ReadAllText(fileName);
				RuntasticActivity Activity = Newtonsoft.Json.JsonConvert.DeserializeObject<RuntasticActivity>(jsonString, new EpochDateTimeConverter());
				_blRuntasticActivities.Add(Activity);
			}
			dgvImport.DataSource = _blRuntasticActivities;
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
			_token = CStravaImporter.RenewToken();
			if (Configuration.ApiKey.ContainsKey("access_token"))
			{
				Configuration.ApiKey.Remove("access_token");
			}
			Configuration.ApiKey.Add("access_token", _token.access_token);

			if (Configuration.ApiKey.ContainsKey("refresh_token"))
			{
				Configuration.ApiKey.Remove("refresh_token");
			}
			Configuration.ApiKey.Add("refresh_token", _token.refresh_token);

			ActivitiesApi apiActivities = new ActivitiesApi();
			var apiUpload = new UploadsApi();

			int index = 0;
			foreach (RuntasticActivity ac in _blRuntasticActivities)
			{
				Upload resultUpload;
				DetailedActivity resultActivity;
				try
				{
					//var name = "Running " + index++;  // String | The name of the activity.
					//var type = "Run";  // String | Type of activity. For example - Run, Ride etc.
					//var startDateLocal = ac.created_at.ToString("yyyy-MM-dd-THH:mm:ssZ");  // Date | ISO 8601 formatted date time.
					//var elapsedTime = (int)(ac.duration / 1000);  // Integer | In seconds.
					//var description = "Imported from Runtastic";  // String | Description of the activity. (optional) 
					//var distance = ac.distance;  // Float | In meters. (optional) 
					//var trainer = 0;  // Integer | Set to 1 to mark as a trainer activity. (optional)
					//var photoIds = "";
					//var commute = 0;  // Integer | Set to 1 to mark as commute. (optional) 
					//resultActivity = apiActivities.CreateActivity(name, type, startDateLocal,elapsedTime,
					//	description,distance,trainer,photoIds,commute);
					Upload poolingUpdate;
					var apiInstance = new UploadsApi();
					var file = File.OpenRead(@"d:\test2.gpx"); // File | The uploaded file. (optional) 
					resultUpload = apiUpload.CreateUpload(file, null, null, null, null, "gpx", null);
					do
					{
						System.Threading.Thread.Sleep(1000);
						poolingUpdate = apiUpload.GetUploadById(resultUpload.Id);
					}
					while (poolingUpdate.ActivityId == null);
				}
				catch (Exception except)
				{
					MessageBox.Show(except.Message, "Strava Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				if (index == 3)
				{
					break;
				}
			}
		}
	}
}
