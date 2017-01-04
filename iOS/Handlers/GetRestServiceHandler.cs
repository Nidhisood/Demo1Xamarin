using System;
using System.Threading;
using RestSharp;

namespace SQLiteSample.iOS
{
	public class GetRestServiceHandler
	{
		//const string baseUrl = "http://115.248.100.78:8080/ws/user/";
		const string baseUrl = "http://teamsstudentapp.rtosoftware.com.au/TeamsStudentApp/";
		readonly string service_url;

		#if __IOS__
		const string token = "NeBQFdgxJseCJXNbJSjTA8ZGTEKMGCCS6bc8xJyf9W5QhSRkyZKjbP6nn9QAa4NQ";
		const string application_type = "IPHONE";
		#endif

		#if __ANDROID__
				string token = "peF2jMXB6JzkjpDfgpZyjW6DQX7aC43gMX4HxESbYm2pEY9MQpEPN3BxYJJEnkbK";
				string application_type="ANDROID";
				#endif

		public GetRestServiceHandler (string methodName)
		{
			service_url = baseUrl + methodName;
		}

		public void GetResponse (IResultInterface resultInterface, String parameter, string SearchDate)//, bool isPost, string session)
		{
			var backgroundTask = new Thread (new ThreadStart (() => {
				var client = new RestClient (service_url);
				var request = new RestRequest (); 

//				if (isPost)
//					request.Method = Method.POST;
//				else
//					request.Method = Method.PUT;

				request.Method = Method.GET;

				request.AddHeader ("Application-Type", application_type);
				request.AddHeader ("SearchDate", SearchDate);
				//request.AddHeader ("session", session);
				request.AddParameter ("application/json", parameter, ParameterType.RequestBody);
				var response = client.Execute (request);
				var content = response.Content;

				resultInterface.getResult (content); 

			}));
			backgroundTask.Start ();
		}

		public void GetLoginResponse (IResultInterface resultInterface, String parameter, string deviceId)
		{
			var backgroundTask = new Thread (new ThreadStart (() => {
				var client = new RestClient (service_url);
				var request = new RestRequest (); 

				request.Method = Method.POST;
				request.AddHeader ("Application-Type", application_type);
				request.AddHeader ("Application-Token", token);
				request.AddHeader ("Device-Id", deviceId);
				request.AddParameter ("application/json", parameter, ParameterType.RequestBody);
				var response = client.Execute (request);
				var content = response.Content;

				resultInterface.getResult (content); 

			}));
			backgroundTask.Start ();
		}

	}
}

