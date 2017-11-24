using System.Collections.Generic;
using System.Data;
using System.Windows;

namespace ShipIt
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DataAccess dataAccess = new DataAccess("Data Source=10.205.44.39,49172;Initial Catalog=ShipIt;User id=Aspit;Password=Server2012;");
		public List<Model> Models = new List<Model>();
		public List<Ship> Ships = new List<Ship>();
		public List<Harbour> Harbour = new List<Harbour>();
		public List<Order> Orders = new List<Order>();
		public List<Transport> Transports = new List<Transport>();

		private enum DisplayMode { Model, Ship, Harbour, Order, Transport, None }

		private DisplayMode currentBox = DisplayMode.None;

		public MainWindow()
		{
			InitializeComponent();
			LoadGridView(DisplayMode.Model);
			UpdateComboBoxes();
		}

		private void ButtonCreateModel_Click(object sender, RoutedEventArgs e)
		{
			if (
				   (double.TryParse(TextBoxModelDepth.Text, out double depth) || TextBoxModelDepth.Text.EndsWith("."))
				   &&
				   int.TryParse(TextBoxModelTonnage.Text, out int tonnage)
				   &&
				   int.TryParse(TextBoxModelMaxContainers.Text, out int maxContainers)
				   )
			{
				Model model = new Model(TextBoxModelName.Text, depth, tonnage, maxContainers);
				Models.Add(model);
				model.InsertIntoDB(dataAccess);
				LoadGridView(DisplayMode.Model);
			}
		}

		private void ButtonCreateShip_Click(object sender, RoutedEventArgs e)
		{
			if (ComboBoxShipModel.SelectedItem != null)
			{
				Ship ship = new Ship((Model)ComboBoxShipModel.SelectedItem, TextBoxShipName.Text);
				Ships.Add(ship);
				ship.InsertIntoDB(dataAccess);
				LoadGridView(DisplayMode.Ship);
			}
		}

		private void ButtonCreateHarbour_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonCreateOrder_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonCreateTransport_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonDeleteModel_Click(object sender, RoutedEventArgs e)
		{
			currentBox = DisplayMode.None;
		}

		private void ButtonDeleteShip_Click(object sender, RoutedEventArgs e)
		{
			currentBox = DisplayMode.None;
		}

		private void ButtonDeleteHarbour_Click(object sender, RoutedEventArgs e)
		{
			currentBox = DisplayMode.None;
		}

		private void ButtonDeleteOrder_Click(object sender, RoutedEventArgs e)
		{
			currentBox = DisplayMode.None;
		}

		private void ButtonDeleteTransport_Click(object sender, RoutedEventArgs e)
		{
			currentBox = DisplayMode.None;
		}

		private void LoadGridView(DisplayMode mode)
		{
			switch (mode)
			{
				case DisplayMode.None:
					{
						break;
					}
				case DisplayMode.Model:
					{
						foreach (DataRow row in dataAccess.GetAllModels())
						{
							Models.Add(new Model
								(
								row.Field<string>("Name"),
								row.Field<double>("Depth"),
								row.Field<int>("Tonnage"),
								row.Field<int>("MaxContainers"),
								row.Field<int>("Id")
								));
						}
						DataGridOverView.ItemsSource = Models;
						DataGridOverView.Items.Refresh();
						break;
					}
				case DisplayMode.Ship:
					{
						break;
					}
				case DisplayMode.Harbour:
					{
						break;
					}
				case DisplayMode.Order:
					{
						break;
					}
				case DisplayMode.Transport:
					{
						break;
					}
			}
		}

		private void ButtonOverViewModel_Click(object sender, RoutedEventArgs e) => LoadGridView(DisplayMode.Model);

		private void ButtonOverViewShip_Click(object sender, RoutedEventArgs e) => LoadGridView(DisplayMode.Ship);

		private void ButtonOverViewHarbour_Click(object sender, RoutedEventArgs e) => LoadGridView(DisplayMode.Harbour);

		private void ButtonOverViewOrder_Click(object sender, RoutedEventArgs e) => LoadGridView(DisplayMode.Order);

		private void ButtonOverViewTransport_Click(object sender, RoutedEventArgs e) => LoadGridView(DisplayMode.Transport);

		private void UpdateComboBoxes()
		{
			ComboBoxShipModel.ItemsSource = Models;
			ComboBoxShipModel.Items.Refresh();
		}
	}
}