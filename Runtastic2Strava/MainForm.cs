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

			ActivitiesApi apiInstance = new ActivitiesApi();
			try
			{
				foreach (RuntasticActivity ac in _blRuntasticActivities)
				{
					DetailedActivity result = apiInstance.CreateActivity(
																			"Running08",
																			"Ride",
																			ac.created_at.ToString("yyyy-MM-dd-THH:mm:ssZ"),
																			(int)(ac.duration / 1000),
																			"Imported from Runtastic",
																			ac.distance,
																			56,
																			"", 
																			56
																		) ;
					break;
				}


			}
			catch (Exception except)
			{
				MessageBox.Show(except.Message, "Strava Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
