using System;

using UIKit;
using System.Net;

namespace SQLiteSample.iOS
{
	public partial class ViewController : UIViewController, IResultInterface
	{


		public ViewController (IntPtr handle) : base (handle)
		{
			/// <summary>
			/// Views the did load.
			/// </summary>
			/// <returns>The did load.</returns>
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();

			// Perform any additional setup after loading the view, typically from a nib.
			Button.AccessibilityIdentifier = "myButton";

			var database = new Database ();

			Button.TouchUpInside += delegate {

				//				var getChangeApi = new ChangeControlApi (this);
				//				getChangeApi.ChangeControl ("15-Apr-2016");

				//				var backgroundTask = new Thread (new ThreadStart (() => {
				//					//RestClient client = new RestClient ("http://teamsstudentapp.rtosoftware.com.au/TeamsStudentApp/ChangeControl");
				//					RestClient client = new RestClient ("http://teamsstudentapp.rtosoftware.com.au/TeamsStudentApp/Campuses");
				//					RestRequest request = new RestRequest (Method.GET);
				//
				//					//request.AddHeader ("SearchDate", "15-Apr-2016");
				//
				//					//GetServiceResponseData response = (GetServiceResponseData)client.Execute (request);
				//
				//					IRestResponse<GetServiceResponseData> response = client.Execute<GetServiceResponseData> (request);
				//
				//					var jsonObj = Newtonsoft.Json.JsonConvert.DeserializeObject<List <GetServiceResponseData>> (response.Content);
				//
				//					//RestSharp.Deserializers.
				//
				//					foreach (var item in jsonObj) {
				//
				//						Console.WriteLine (item.CampusAddress + "  " + item.CampusName);
				//						
				//					}
				//				}));
				//				backgroundTask.Start ();

				database.UpdateData ();

				Console.WriteLine (" button clicked..... ");
				Console.WriteLine (" button clicked..... ");
				Console.WriteLine (" button clicked..... ");
				Console.WriteLine (" button clicked..... ");
			};

		}

		#region IResultInterface implementation

		public void getResult (string result)
		{
			try {
				if (!string.IsNullOrEmpty (result) && !result.Contains ("<!DOCTYPE html><html><head><title>Apache Tomcat/8.0.30 - Error report</title>")) {
					//var responseObj = Newtonsoft.Json.JsonConvert.DeserializeObject<GetServiceResponseData> (result);

					InvokeOnMainThread (async () => {


					});
				}
			} catch (WebException e) {
				InvokeOnMainThread (() => Console.WriteLine (e.Message));
			}
		}

		#endregion

	}
}
