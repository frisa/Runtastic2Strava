using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Strava.NET.Api;
using Strava.NET.Client;
using Strava.NET.Model;
using System.Data;
using System.ComponentModel;

namespace Runtastic2Strava
{
    public class StravaToken
    {
        public string token_type { get; set; }
        public string access_token { get; set; }
        public string refresh_token { get; set; }
        public int expires_at { get; set; }
    }
    public class RuntasticActivity
    {
        public DateTime start_time { get; set; }
        public DateTime end_time { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public int start_time_timezone_offset { get; set; }
        public int end_time_timezone_offset { get; set; }
        public int distance { get; set; }
        public int duration { get; set; }
        public int elevation_gain { get; set; }
        public int elevation_loss { get; set; }
        public float average_speed { get; set; }
        public int calories { get; set; }
        public float longitude { get; set; }
        public float latitude { get; set; }
        public float max_speed { get; set; }
        public int pause_duration { get; set; }
        public int duration_per_km { get; set; }
        public float temperature { get; set; }
        public int pulse_avg { get; set; }
        public int pulse_max { get; set; }
        public int avg_cadence { get; set; }
        public int max_cadence { get; set; }
        public bool manual { get; set; }
        public bool edited { get; set; }
        public bool completed { get; set; }
        public bool live_tracking_active { get; set; }
        public bool live_tracking_enabled { get; set; }
        public bool cheering_enabled { get; set; }
        public bool indoor { get; set; }
        public string id { get; set; }
        public string weather_condition_id { get; set; }
        public string surface_id { get; set; }
        public string subjective_feeling_id { get; set; }
        public string sport_type_id { get; set; }
        public string[] user_equipment_ids { get; set; }
    }
    public class ImageMetaData
    {
        public DateTime created_at { get; set; }
        public float latitude { get; set; }
        public float longitude { get; set; }
        public int id { get; set; }
    }
    public class ImageSessionAlbum
    {
        public string id { get; set; }
        public string sample_id { get; set; }
        public int[] photos_ids { get; set; }
    }
    public static class CStravaImporter
	{
        public static StravaToken RenewToken()
        {
            Dictionary<string, string> values = new Dictionary<string, string>();
            values.Add("grant_type", "refresh_token");
            values.Add("client_id", "55818");
            values.Add("client_secret", "f7517d6028515a37d54eb5a22f2d1a252d93097c");
            values.Add("refresh_token", "77ca157ea781429f7a56585d40d6d092228cf6e4");
            Configuration.DefaultApiClient.RestClient.BaseUrl = "https://www.strava.com/oauth";
            RestSharp.RestResponse result = Configuration.DefaultApiClient.CallApi("token", RestSharp.Method.POST, values,
                "grant_type=refresh_token&client_id=55818&client_secret=f7517d6028515a37d54eb5a22f2d1a252d93097c&refresh_token=ed9d3d6c85b3806a03bfb75e5b9bc41ee6edddfb",
                values,
                values, new Dictionary<string, RestSharp.FileParameter>(), new string[0] { }) as RestSharp.RestResponse;
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                Configuration.DefaultApiClient.RestClient.BaseUrl = Configuration.DefaultApiClient.BasePath;
                return Newtonsoft.Json.JsonConvert.DeserializeObject<StravaToken>(result.Content);
            }
            return new StravaToken();
        }
    }
}
