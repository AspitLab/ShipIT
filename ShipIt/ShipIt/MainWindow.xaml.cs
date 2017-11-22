using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace ShipIt
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public DataAccess dataAccess = new DataAccess("Data Source=10.205.44.39,49172;Initial Catalog=ShipIt;User id=Aspit;Password=Server2012;");
		public List<Model> Models = new List<Model>();

		public MainWindow()
		{
			InitializeComponent();
		}

		private void ButtonCreateModel_Click(object sender, RoutedEventArgs e)
		{
		}

		private void TextBoxModelTonnage_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void TextBoxModelMaxContainers_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void TextBoxOrderWeight_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void TextBoxOrderContainers_TextChanged(object sender, TextChangedEventArgs e)
		{
		}

		private void ButtonCreateShip_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonCreateHarbour_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonCreateOrder_Click(object sender, RoutedEventArgs e)
		{
		}

		private void ButtonCreateTransport_Click(object sender, RoutedEventArgs e)
		{
			new Transport();
		}
	}
}