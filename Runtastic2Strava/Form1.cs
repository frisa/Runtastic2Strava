using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

using Strava.NET.Api;
using Strava.NET.Client;
using Strava.NET.Model;

namespace Runtastic2Strava
{
    public class TokenModel
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_at { get; set; }
    }

	public partial class Form1 : Form
	{
        static TokenModel token;
        static TokenModel RenewToken()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("grant_type", "refresh_token");
            values.Add("client_id", "55818");
            values.Add("client_secret", "f7517d6028515a37d54eb5a22f2d1a252d93097c");
            values.Add("refresh_token", "ed9d3d6c85b3806a03bfb75e5b9bc41ee6edddfb");
            Configuration.DefaultApiClient.RestClient.BaseUrl = "https://www.strava.com/oauth";
            RestSharp.RestResponse result = Configuration.DefaultApiClient.CallApi("token", RestSharp.Method.POST, values,
                "grant_type=refresh_token&client_id=55818&client_secret=f7517d6028515a37d54eb5a22f2d1a252d93097c&refresh_token=ed9d3d6c85b3806a03bfb75e5b9bc41ee6edddfb",
                values,
                values, new Dictionary<string, RestSharp.FileParameter>(), new string[0] { }) as RestSharp.RestResponse;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Configuration.DefaultApiClient.RestClient.BaseUrl = Configuration.DefaultApiClient.BasePath;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<TokenModel>(result.Content);
            }
            return new TokenModel();
        }
        public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            token = RenewToken();
            // Configure OAuth2 access token for authorization: strava_oauth
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
                Debug.WriteLine(result);
            }
            catch (Exception except)
            {
                Debug.Print("Exception when calling ActivitiesApi.CreateActivity: " + except.Message);
            }
        }
	}
}
