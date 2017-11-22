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

		public Model Model => model;
		public string Name => name;

		public override string ToString() => Name;
	}
}