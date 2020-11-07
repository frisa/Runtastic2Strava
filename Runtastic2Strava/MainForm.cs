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
		private BindingList<RuntasticActivity> _blRuntasticActivities;
		private StravaToken _token;
		public MainForm()
		{
			InitializeComponent();
			
		}
		private void btnLoad_Click(object sender, EventArgs e)
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

			_blRuntasticActivities = new BindingList<RuntasticActivity>();
			dgvImport.DataSource = _blRuntasticActivities;
			int index = 0;

			String sPathSessions = tbPath.Text + "Sport-sessions";
			String sPathGps = tbPath.Text + "Sport-sessions\\GPS-data";
			String sPathSessionAlbums = tbPath.Text + "Photos\\Images-meta-data\\Sport-session-albums";
			String sPathPhotos = tbPath.Text + "Photos";

			foreach (string sSessionFilePath in Directory.GetFiles(sPathSessions))
			{
				String sSessionFile = Path.GetFileName(sSessionFilePath);
				String sGpsFile = Path.Combine(sPathGps, Path.ChangeExtension(sSessionFile, "gpx"));
				String sPhotoFile = Path.ChangeExtension(sSessionFile, "json");
				RuntasticActivity ac = Newtonsoft.Json.JsonConvert.DeserializeObject<RuntasticActivity>(System.IO.File.ReadAllText(sSessionFilePath), new EpochDateTimeConverter());
				DetailedActivity resultActivity = null;
				if (File.Exists(sGpsFile))
				{
					try
					{ 
						Upload resultUpload;
						var file = File.OpenRead(sGpsFile);
						var apiUpload = new UploadsApi();
						resultUpload = apiUpload.CreateUpload(file, null, null, null, null, "gpx", null);
						int timeOut = 0;
						do
						{
							System.Threading.Thread.Sleep(500);
							resultUpload = apiUpload.GetUploadById(resultUpload.Id);
							if (20 < timeOut++) break;
						}
						while ((resultUpload.Status.ToString().Contains("Your activity is still being processed.")));
						if (resultUpload.ActivityId != null)
						{
							var apiActivity = new ActivitiesApi();
							resultActivity = apiActivity.UpdateActivityById(resultUpload.ActivityId, null);
						}
					}
					catch (Exception except)                                    
					{
						MessageBox.Show(except.Message, "Strava Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}             
				else
				{
					try
					{
						ActivitiesApi apiActivities = new ActivitiesApi();
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
				}

				if (resultActivity != null)
				{
					String sPhotoSessionAlbum = Path.Combine(sPathSessionAlbums, ac.id);
					sPhotoSessionAlbum = Path.ChangeExtension(sPhotoSessionAlbum, "json");
					if (File.Exists(sPhotoSessionAlbum))
					{
						ImageSessionAlbum imageSessionAlbum = Newtonsoft.Json.JsonConvert.DeserializeObject<ImageSessionAlbum>(System.IO.File.ReadAllText(sPhotoSessionAlbum));
						foreach (int photoId in imageSessionAlbum.photos_ids)
						{
							String photoFile = Path.ChangeExtension(photoId.ToString(), "jpg");
							if (File.Exists(Path.Combine(sPathPhotos, photoFile)))
							{
								//resultActivity.Photos
								MessageBox.Show("");
							}
						}
					}
					_blRuntasticActivities.Add(ac);
				}
				break;
			}
		}
		private void btnBrowse_Click(object sender, EventArgs e)
		{
			FolderBrowserDialog fbdExport = new FolderBrowserDialog();
			if (DialogResult.OK == fbdExport.ShowDialog())
			{
				tbPath.Text = fbdExport.SelectedPath;
			}
		}
	}
}
