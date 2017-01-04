
namespace SQLiteSample.iOS
{
	public class ChangeControlApi
	{
		readonly IResultInterface loginInterface;

		public ChangeControlApi (IResultInterface loginInterface)
		{
			this.loginInterface = loginInterface;
		}

		public void ChangeControl (string date)
		{
			//true for POST api
			var handler = new GetRestServiceHandler ("ChangeControl");
			handler.GetResponse (loginInterface, null, date);  
		}
	}
}

