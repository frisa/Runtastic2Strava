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
        public string start_time { get; set; }
        public string end_time { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public string start_time_timezone_offset { get; set; }
        public string end_time_timezone_offset { get; set; }
        public string distance { get; set; }
        public string duration { get; set; }
        public string elevation_gain { get; set; }
        public string elevation_loss { get; set; }
        public string average_speed { get; set; }
        public string calories { get; set; }
        public string longitude { get; set; }
        public string latitude { get; set; }
        public string max_speed { get; set; }
        public string pause_duration { get; set; }
        public string duration_per_km { get; set; }
        public string temperature { get; set; }
        public string pulse_avg { get; set; }
        public string pulse_max { get; set; }
        public string avg_cadence { get; set; }
        public string max_cadence { get; set; }
        public string manual { get; set; }
        public string edited { get; set; }
        public string completed { get; set; }
        public string live_tracking_active { get; set; }
        public string live_tracking_enabled { get; set; }
        public string cheering_enabled { get; set; }
        public string indoor { get; set; }
        public string id { get; set; }
        public string weather_condition_id { get; set; }
        public string surface_id { get; set; }
        public string subjective_feeling_id { get; set; }
        public string sport_type_id { get; set; }
        public string[] user_equipment_ids { get; set; }
    }
    public static class CStravaImporter
	{
        public static StravaToken RenewToken()
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
                return Newtonsoft.Json.JsonConvert.DeserializeObject<StravaToken>(result.Content);
            }
            return new StravaToken();
        }
    }
}
