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
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
            // Configure OAuth2 access token for authorization: strava_oauth
            Configuration.Default.AccessToken = "YOUR_ACCESS_TOKEN";

            ActivitiesApi apiInstance = new ActivitiesApi();
            var name = "Running";  // string | The name of the activity.
            var type = "Run";  // string | Type of activity. For example - Run, Ride etc.
            var startDateLocal = "20201104";  // string | ISO 8601 formatted date time.
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
