namespace ShipIt
{
	public class Harbour
	{
		private string name;
		private int id;
		private double depth;
		private string remarks;

		public Harbour(string name, double depth, string remarks = "")
		{
			this.name = name;
			this.depth = depth;
			this.remarks = remarks;
		}

		public Harbour(string name, double depth, int id, string remarks = "")
		{
			this.name = name;
			this.depth = depth;
			this.id = id;
			this.remarks = remarks;
		}

		public string Name => name;
		public double Depth => depth;
		public string Remarks => remarks;

		public override string ToString() => Name;
	}
}