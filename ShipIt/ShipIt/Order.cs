using System;

namespace ShipIt
{
	public class Order
	{
		private DateTime date;
		private double weight;
		private int containers;
		private Harbour origin;
		private Harbour destination;
		private int id;

		public Order(DateTime date, double weight, int containers, Harbour origin, Harbour destination)
		{
			this.date = date;
			this.weight = weight;
			this.containers = containers;
			this.origin = origin;
			this.destination = destination;
		}

		public Order(DateTime date, double weight, int containers, Harbour origin, Harbour destination, int id)
		{
			this.date = date;
			this.weight = weight;
			this.containers = containers;
			this.origin = origin;
			this.destination = destination;
			this.id = id;
		}

		public DateTime Date => date;
		public double Weight => weight;
		public int Containers => containers;
		public Harbour Origin => origin;
		public Harbour Destination => destination;

		public override string ToString() => $"{Date.ToString("dd/MM/yyyy")}: {Origin} -> {Destination}";
	}
}