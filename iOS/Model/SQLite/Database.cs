using System;
using System.IO;
using SQLite;
using System.Collections.Generic;
using System.Linq;

namespace SQLiteSample.iOS
{
	public class Database
	{
		readonly SQLiteConnection db;

		// Review commit 3 fdfgdhfghfg

		public Database ()
		{
			const string databaseFileName = "TEAMSDatabase.db3";

#if __ANDROID__
			string libraryPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
#else
			string documentsPath = Environment.GetFolderPath (Environment.SpecialFolder.Personal);
			string librarypath = Path.Combine (documentsPath, "..", "Library");
#endif

			var dbPath = Path.Combine (librarypath, databaseFileName);
			db = new SQLiteConnection (dbPath);

			//var table = db.GetTableInfo ("CreativeCrewSeasia");

			if (!db.Table<Stock> ().Any () || db.Table<Stock> () == null)
				db.CreateTable<Stock> ();

			//			if (db.Table<Stock> ().Table.TableName != "CreativeCrewSeasia")
			//				db.CreateTable<Stock> ();

			Console.WriteLine ("path: " + documentsPath);
		}

		public void AddData ()
		{
			object locker = new object ();

			//db.Execute ("DELETE FROM CreativeCrewSeasia");
			var names = new List<string> {
				"Nidhi ",
				"Gurleen ",
				"Jagdeep ",
				"Sneh",
				"Gurjot",
				"Harjot",
				"Atinder",
				"Akash",
				"Vishal",
				"Dipanshu",
				"Harry",
				"Ravi",
				"PunnetPal",
				"Rakesh",
				"Garry",
				"Kamal Thakur",
				"Amrik",

			};

			var techs = new List<string> {
				"Android,Xamarin",
				"Phonegap,Xamarin",
				"Android,Xamarin",
				"Phonegap,Xamarin",
				"Android,Xamarin",
				"Android,Xamarin",
				"iOS,Xamarin",
				"Android",
				"Android,Xamarin",
				"Android,PhoneGap",
				"iOS,Xamarin",
				"Android,Xamarin",
				"iOS",
				"Android",
				"iOS",
				"Android",
				"iOS"
			};

			lock (locker) {

				if (db.Table<Stock> ().Count () == 0) {

					//stock.name = "Nidhi Sood";

					for (int i = 0; i < names.Count; i++) {
						var stock = new Stock ();
						stock.Key = i;
						stock.Name = names [i];
						stock.Technology = techs [i];
						db.Insert (stock);
					}

				}

				// only insert the data if it doesn't already exist
				//if (db.Table<Stock> ().Count () == 0) {
				// only insert the data if it doesn't already exist
				//				var newStock = new Stock ();
				//				newStock.Name = "AAPL";
				//				db.Insert (newStock);
				//				newStock = new Stock ();
				//				newStock.Name = "GOOG";
				//				db.Insert (newStock);
				//				newStock = new Stock ();
				//				newStock.Name = "MSFT";
				//				db.Insert (newStock);
				//}

			}

			var table = db.Table<Stock> ();

			foreach (var item in table) {
				Console.WriteLine (item.Key + ": name: " + item.Name + "  : tech: " + item.Technology);
			}

			Console.WriteLine (" table: " + db.Table<Stock> ().Table.TableName);
		}


		public void UpdateData ()
		{
			object locker = new object ();

			lock (locker) {

				var stock = new Stock ();
				stock.Name = "XYZ";
				stock.Technology = "Xamarin";

				var table = db.Table<Stock> ();
				var tableC = db.GetTableInfo ("CreativeCrewSeasia");

				db.Update (stock);

				foreach (var item in table) {
					Console.WriteLine (item.Key + ": name: " + item.Name + "  : tech: " + item.Technology);
				}
			}

		}
	}
}

