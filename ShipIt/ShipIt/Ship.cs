using System.Collections.Generic;

namespace ShipIt
{
	public class Ship
	{
		private int id;
		private Model model;
		private string name;
		public List<Harbour> Restrictions = new List<Harbour>();

		public Ship(Model model, string name)
		{
			this.model = model;
			this.name = name;
		}

		public Ship(Model model, string name, int id)
		{
			this.model = model;
			this.name = name;
			this.id = id;
		}

		public void InsertIntoDB(DataAccess dataAccess)
		{
			if (HasId)
				throw new ItemExistsInDbException();

			id = dataAccess.InsertShip(this);
		}

		public bool HasId => (!(ReferenceEquals(null, id) || id == 0));
		public Model Model => model;
		public string Name => name;

		public override string ToString() => Name;
	}
}