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
		private DataTable _dtGpxList = new DataTable();
		private StravaToken _token;
		public MainForm()
		{
			InitializeComponent();
			
		}
		private void btnLoad_Click(object sender, EventArgs e)
		{
			String sPathSportSessions = tbPath.Text + "Sport-sessions";
			String sPathGPPSData = tbPath.Text + "Sport-sessions\\GPS-data";

			string[] fileEntries = Directory.GetFiles(sPathSportSessions);
			string[] fileEntriesGpx = Directory.GetFiles(sPathGPPSData);

			_blRuntasticActivities = new BindingList<RuntasticActivity>();
			_dtGpxList = new DataTable();

			foreach (string fileName in fileEntries)
			{
				String jsonString = System.IO.File.ReadAllText(fileName);
				RuntasticActivity Activity = Newtonsoft.Json.JsonConvert.DeserializeObject<RuntasticActivity>(jsonString, new EpochDateTimeConverter());
				_blRuntasticActivities.Add(Activity);
			}
			dgvImport.DataSource = _blRuntasticActivities;

			_dtGpxList.Columns.Add("File Path");
			foreach (string fileName in fileEntriesGpx)
			{
				DataRow rowNew = _dtGpxList.NewRow();
				rowNew["File Path"] = fileName;
				_dtGpxList.Rows.Add(rowNew);
			}
			dgvGpx.DataSource = _dtGpxList;
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
			int index = 0;
			foreach (RuntasticActivity ac in _blRuntasticActivities)
			{
				try
				{
					DetailedActivity resultActivity;
					var name = "Activity " + index++;
					var type = "Run";
					var startDateLocal = ac.created_at.ToString("yyyy-MM-dd-THH:mm:ssZ");
					var elapsedTime = (int)(ac.duration / 1000);
					var distance = ac.distance;
					var photoIds = "";
					resultActivity = apiActivities.CreateActivity(name, type, startDateLocal, elapsedTime,
						null, distance, null, photoIds, null);
				}
				catch (Exception except)
				{
					MessageBox.Show(except.Message, "Strava Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				break;
			}
			MessageBox.Show("Import done", "Strava Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}

		private void btnGpxImport_Click(object sender, EventArgs e)
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

			var apiUpload = new UploadsApi();
			foreach (DataRow rowFile in _dtGpxList.Rows)
			{
				try
				{
					Upload resultUpload;
					Upload poolingUpdate;
					var apiInstance = new UploadsApi();
					var file = File.OpenRead(rowFile["File Path"].ToString());
					resultUpload = apiUpload.CreateUpload(file, null, null, null, null, "gpx", null);
					int index = 0;
					do
					{
						System.Threading.Thread.Sleep(1000);
						poolingUpdate = apiUpload.GetUploadById(resultUpload.Id);
						if (20 < index++) break;
					}
					while (poolingUpdate.ActivityId == null);
				}
				catch (Exception except)
				{
					MessageBox.Show(except.Message, "Strava GPX Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
				break;
			}
			MessageBox.Show("Import done", "Strava GPX Import", MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
	}
}
