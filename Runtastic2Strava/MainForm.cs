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
using System.Security;

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
		private void logActivity(RuntasticActivity ac, Color color)
		{
			_blRuntasticActivities.Add(ac);
			dgvImport.Rows[dgvImport.Rows.Count - 1].DefaultCellStyle.BackColor = color;
			dgvImport.Refresh();
			dgvImport.Update();
		}
		private void log(String message)
		{
			rtbLog.Text = rtbLog.Text + message + System.Environment.NewLine;
			rtbLog.Refresh();
		}
		private void btnLoad_Click(object sender, EventArgs e)
		{
			_token = CStravaImporter.RenewToken(tbClient.Text, tbClientSecret.Text, tbRefreshToken.Text);
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
			log("Tokens Loaded");

			_blRuntasticActivities = new BindingList<RuntasticActivity>();
			dgvImport.DataSource = _blRuntasticActivities;
			int index = 0;

			String sPathSessions = Path.Combine(tbPath.Text,"Sport-sessions");
			String sPathGps = Path.Combine(sPathSessions, "GPS-data");
			String sPathSessionAlbums = Path.Combine(tbPath.Text,"Photos\\Images-meta-data\\Sport-session-albums");
			String sPathPhotos = Path.Combine(tbPath.Text,"Photos");

			foreach (string sSessionFilePath in Directory.GetFiles(sPathSessions))
			{
				String sSessionFile = Path.GetFileName(sSessionFilePath);
				String sGpsFile = Path.Combine(sPathGps, Path.ChangeExtension(sSessionFile, "gpx"));
				String sPhotoFile = Path.ChangeExtension(sSessionFile, "json");
				RuntasticActivity ac = Newtonsoft.Json.JsonConvert.DeserializeObject<RuntasticActivity>(System.IO.File.ReadAllText(sSessionFilePath), new EpochDateTimeConverter());
				DetailedActivity resultActivity = null;
				index++;
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
							System.Threading.Thread.Sleep(2000);
							resultUpload = apiUpload.GetUploadById(resultUpload.Id);
							System.Windows.Forms.Application.DoEvents();
							if (30 < timeOut++)
							{
								MessageBox.Show("Timeout");
								break;
							}
						}
						while ((resultUpload.Status.ToString().Contains("Your activity is still being processed.")));
						if ((resultUpload.Status.ToString().Contains("Your activity is ready.")))
						{
							logActivity(ac, Color.Green);
							log(index.ToString() + " -> " + resultUpload.ActivityId + " uploaded form:" + Path.GetFileName(file.Name));
						}
						else
						{
							logActivity(ac, Color.Red);
							log(index.ToString() + " -> " + resultUpload.Status.ToString() + " " + Path.GetFileName(file.Name));
						}
						System.Windows.Forms.Application.DoEvents();
					}
					catch (Exception except)                                    
					{
						log(index.ToString() + " -> " + except.Message);
						logActivity(ac, Color.Red);
					}
				}             
				else
				{
					try
					{
						ActivitiesApi apiActivities = new ActivitiesApi();
						var name = "Activity " + index;
						var type = "Run";
						var startDateLocal = ac.created_at.ToString("yyyy-MM-dd-THH:mm:ssZ");
						var elapsedTime = (int)(ac.duration / 1000);
						var distance = ac.distance;
						var photoIds = "";
						resultActivity = apiActivities.CreateActivity(name, type, startDateLocal, elapsedTime,
							null, distance, null, photoIds, null);
						logActivity(ac, Color.Green);
						log(index.ToString() + " -> " + resultActivity.Name + " done manualy");
					}
					catch (Exception except)
					{
						log(index.ToString() + " -> " + except.Message);
						logActivity(ac, Color.Red);
					}
				}
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
