namespace ShipIt
{
	public class Transport
	{
		private Order order;
		private Ship ship;
		private int id;

		public Transport(Order order, Ship ship)
		{
			this.order = order;
			this.ship = ship;
		}

		public Transport(Order order, Ship ship, int id)
		{
			this.order = order;
			this.ship = ship;
			this.id = id;
		}

		public Order Order { get => order; set => order = value; }
		public Ship Ship => ship;

		public override string ToString() => $"{Ship} {Order}";
	}
}