using System;

namespace SQLiteSample.iOS
{
	public class GetServiceResponseData
	{
		public bool CampusChanged { get; set; }

		public bool ContactsChanged { get; set; }

		public bool ArticleChanged { get; set; }

		public bool FacultiesChanged { get; set; }

		public bool GalleriesChanged { get; set; }

		public bool PhotosChanged { get; set; }

		public bool VideosChanged { get; set; }

		public bool EventsChanged { get; set; }

		public bool SettingsChanged { get; set; }

		public string YoutubeChannel { get; set; }

		public string TwitterAccount { get; set; }

		public string FacebookPage { get; set; }

		public bool UseFaculties { get; set; }

		public int CampusID { get; set; }

		public string CampusName { get; set; }

		public string City { get; set; }

		public string State { get; set; }

		public string Country { get; set; }

		public string CampusAddress { get; set; }

		public long LocationLongitude { get; set; }

		public long LocationLatitude { get; set; }

		public object CampusMapImage { get; set; }

		public bool Active { get; set; }
	}

}

