using SQLite;


namespace SQLiteSample.iOS
{
	[Table ("CreativeCrewSeasia")]
	public class Stock
	{
		[SQLite.PrimaryKey,SQLite.AutoIncrement]
		public int Key{ get; set; }

		[MaxLength (100),Column ("EmployeeName")]
		public string Name{ get; set; }

		public string Technology{ get; set; }


	}
}

