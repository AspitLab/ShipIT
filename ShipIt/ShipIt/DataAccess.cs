using System.Data;

namespace ShipIt
{
	public class DataAccess : CommonDataAccess
	{
		public DataAccess(string connectionString) : base(connectionString)
		{
		}

		public void ExecCommand(string sql) => ExecuteNonQuery(sql);

        public DataSet ExecReturn(string sql) => ExecuteQuery(sql);

        /// <summary>
        /// Gets all entries in table Harbours in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <returns>A list of type Harbour.</returns>
        public List<Harbour> GetAllHarbours()
        {
            DataSet ds = ExecReturn("GetAllHarbours");

            List<Harbour> harbours = new List<Harbour>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Harbour h = new Harbour(
                    dr.Field<int>("Id"),
                    dr.Field<string>("Name"),
                    dr.Field<double>("Depth"));

                harbours.Add(h);
            }
            return harbours;
        }

        /// <summary>
        /// Gets a specific entry int table Harbours in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <param name="id">The id of the wanted harbour.</param>
        /// <returns>An object of type Harbour.</returns>
        public Harbour GetSpecificHarbour(int id)
        {
            DataSet ds = ExecReturn($"GetSpecificHarbour {id}");

            Harbour harbour = new Harbour(
                ds.Tables[0].Rows[0].Field<int>("Id"),
                ds.Tables[0].Rows[0].Field<string>("Name"),
                ds.Tables[0].Rows[0].Field<double>("Depth"));

            return harbour;
        }

        /// <summary>
        /// Gets all entries in table Models in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <returns>A list of type Model.</returns>
        public List<Model> GetAllModels()
        {
            DataSet ds = ExecReturn("GetAllModels");

            List<Model> models = new List<Model>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Model m = new Model(
                    dr.Field<int>("Id"),
                    dr.Field<string>("Name"),
                    dr.Field<double>("Depth"),
                    dr.Field<int>("Tonnage"),
                    dr.Field<int>("MaxContainers"));

                models.Add(m);
            }
            return models;
        }

        /// <summary>
        /// Gets a specific entry int table Models in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <param name="id">The id of the wanted model.</param>
        /// <returns>An object of type Model.</returns>
        public Model GetSpecificModel(int id)
        {
            DataSet ds = ExecReturn($"GetSpecificModel {id}");

            Model model = new Model(
                ds.Tables[0].Rows[0].Field<int>("Id"),
                ds.Tables[0].Rows[0].Field<string>("Name"),
                ds.Tables[0].Rows[0].Field<double>("Depth"),
                ds.Tables[0].Rows[0].Field<int>("Tonnage"),
                ds.Tables[0].Rows[0].Field<int>("MaxContainers"));

            return model;
        }

        /// <summary>
        /// Gets all entries in table Orders in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <returns>A list of type Order.</returns>
        public List<Order> GetAllOrders()
        {
            DataSet ds = ExecReturn("GetAllOrders");

            List<Order> orders = new List<Order>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Order o = new Order(
                    dr.Field<int>("Id"),
                    GetSpecificHarbour(dr.Field<int>("OriginId")),
                    GetSpecificHarbour(dr.Field<int>("DestinationId")),
                    dr.Field<DateTime>("Date"),
                    dr.Field<int>("Tonnage"),
                    dr.Field<int>("Containers"));

                orders.Add(o);
            }
            return orders;
        }

        /// <summary>
        /// Gets a specific entry int table Orders in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <param name="id">The id of the wanted order.</param>
        /// <returns>An object of type Order.</returns>
        public Order GetSpecificOrder(int id)
        {
            DataSet ds = ExecReturn($"GetSpecificOrder {id}");

            Order order = new Order(
                    ds.Tables[0].Rows[0].Field<int>("Id"),
                    GetSpecificHarbour(ds.Tables[0].Rows[0].Field<int>("OriginId")),
                    GetSpecificHarbour(ds.Tables[0].Rows[0].Field<int>("DestinationId")),
                    ds.Tables[0].Rows[0].Field<DateTime>("Date"),
                    ds.Tables[0].Rows[0].Field<int>("Tonnage"),
                    ds.Tables[0].Rows[0].Field<int>("Containers"));

            return order;
        }

        /// <summary>
        /// Gets all entries in table Ships in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <returns>A list of type Ship.</returns>
        public List<Ship> GetAllShips()
        {
            DataSet ds = ExecReturn("GetAllShips");

            List<Ship> ships = new List<Ship>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Ship s = new Ship(
                    dr.Field<int>("Id"),
                    GetSpecificModel(dr.Field<int>("ModelId")),
                    dr.Field<string>("Name"));

                ships.Add(s);
            }
            return ships;
        }

        /// <summary>
        /// Gets a specific entry int table Ships in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <param name="id">The id of the wanted ship.</param>
        /// <returns>An object of type Ship.</returns>
        public Ship GetSpecificShip(int id)
        {
            DataSet ds = ExecReturn($"GetSpecificShip {id}");

            Ship ship = new Ship(
                ds.Tables[0].Rows[0].Field<int>("Id"),
                GetSpecificModel(ds.Tables[0].Rows[0].Field<int>("ModelId")),
                ds.Tables[0].Rows[0].Field<string>("Name"));

            return ship;
        }

        /// <summary>
        /// Gets all entries in table Transports in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <returns>A list of type Transport.</returns>
        public List<Transport> GetAllTransports()
        {
            DataSet ds = ExecReturn("GetAllTransports");

            List<Transport> transports = new List<Transport>();

            foreach(DataRow dr in ds.Tables[0].Rows)
            {
                Transport t = new Transport(
                    dr.Field<int>("Id"),
                    GetSpecificOrder(dr.Field<int>("OrderId")),
                    GetSpecificShip(dr.Field<int>("ShipId")));

                transports.Add(t);
            }
            return transports;
        }

        /// <summary>
        /// Gets a specific entry int table Transports in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <param name="id">The id of the wanted transport.</param>
        /// <returns>An object of type Transport.</returns>
        public Transport GetSpecificTransport(int id)
        {
            DataSet ds = ExecReturn($"GetSpecificShip {id}");

            Transport transport = new Transport(
                ds.Tables[0].Rows[0].Field<int>("Id"),
                GetSpecificOrder(ds.Tables[0].Rows[0].Field<int>("OrderId")),
                GetSpecificShip(ds.Tables[0].Rows[0].Field<int>("ShipId")));

            return transport;
        }
    }
		private DataSet ExecReturn(string sql) => ExecuteQuery(sql);

		public DataRowCollection GetAllModels() => ExecReturn("GetAllModels").Tables[0].Rows;

		public int InsertModel(Model model) => ExecReturn($"CreateModel '{model.Name}', {model.Depth}, {model.Tonnage}, {model.MaxContainers}").Tables[0].Rows[0].Field<int>("Id");

		public int InsertShip(Ship ship) => ExecReturn($"CreateShip '{ship.Model.GetId()}', {ship.Name}").Tables[0].Rows[0].Field<int>("Id");
	}
}