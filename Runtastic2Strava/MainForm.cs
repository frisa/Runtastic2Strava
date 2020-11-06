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
	public class EpochDateTimeConverter : Newtonsoft.Json.JsonConverter
	{
		public override bool CanConvert(Type objectType)
		{
			return objectType == typeof(DateTime);
		}

		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
		{
			var t = long.Parse(reader.Value.ToString());
			return new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddMilliseconds(t);
		}

		public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
		{
			throw new NotImplementedException();
		}
	}
	public partial class MainForm : Form
	{
		private BindingList<RuntasticActivity> _blRuntasticActivities = new BindingList<RuntasticActivity>();
		private StravaToken _token;
		public MainForm()
		{
			InitializeComponent();
			
		}

		private static readonly DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

		public static DateTime FromUnixTime(long unixTime)
		{
			return epoch.AddSeconds(unixTime);
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
			Configuration.ApiKey.Add("access_token", _token.access_token);
			Configuration.ApiKey.Add("refresh_token", _token.refresh_token);

			ActivitiesApi apiInstance = new ActivitiesApi();
			try
			{
				//foreach (DataRow rActivity in _dtRuntasticActivities.Rows)
				//{
				//int i = 0;
				//DataRow rActivity = _dtRuntasticActivities.Rows[0];
				//String createdAt = rActivity["created_at"].ToString();


				//DetailedActivity result = apiInstance.CreateActivity(
				//	"Running" + i++ ,
				//	"Run",
				//	createdAt ,
				//	Int32.Parse(rActivity["duration"].ToString()), 
				//	"Imported from Runtastic",
				//	Int32.Parse(rActivity["distance"].ToString()),
				//	56, 
				//	"", // string | List of native photo ids to attach to the activity. (optional) 
				//	56);
				//}
			}
			catch (Exception except)
			{
				MessageBox.Show(except.Message, "Strava Import Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
