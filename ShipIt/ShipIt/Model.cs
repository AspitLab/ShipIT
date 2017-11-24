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

			id = dataAccess.InsertModel(this);
		}

		public string Name => name;
		public double Depth => depth;
		public int Tonnage => tonnage;
		public int MaxContainers => maxContainers;
		public bool HasId => (!(ReferenceEquals(null, id) || id == 0));

		public int GetId() => id;

		public override string ToString() => Name;
	}
}