using System.Collections.Generic;
using System.Data;

namespace ShipIt
{
	public class Model
	{
		private string name;
		private double depth;
		private int tonnage;
		private int maxContainers;
		private int id;

		public List<Harbour> Restrictions = new List<Harbour>();

		public Model(string name, double depth, int tonnage, int maxContainers)
		{
			this.name = name;
			this.depth = depth;
			this.tonnage = tonnage;
			this.maxContainers = maxContainers;
		}

		public Model(string name, double depth, int tonnage, int maxContainers, int id)
		{
			this.name = name;
			this.depth = depth;
			this.tonnage = tonnage;
			this.maxContainers = maxContainers;
			this.id = id;
		}

		public void InsertIntoDB(DataAccess dataAccess)
		{
			if (HasId)
				throw new ItemExistsInDbException();

			DataSet ds = dataAccess.ExecReturn($"CreateModel '{Name}', {Depth}, {Tonnage}, {MaxContainers}");
			id = ds.Tables[0].Rows[0].Field<int>("Id");
		}

		public void LoadFromDB(DataAccess dataAccess)
		{
			if (!HasId)
				throw new DataException();

			DataSet ds = dataAccess.ExecReturn($"CreateModel '{Name}', {Depth}, {Tonnage}, {MaxContainers}");
			id = ds.Tables[0].Rows[0].Field<int>("Id");
		}

		public string Name => name;
		public double Depth => depth;
		public int Tonnage => tonnage;
		public int MaxContainers => maxContainers;
		public bool HasId => ReferenceEquals(null, id);

		public override string ToString() => Name;
	}
}