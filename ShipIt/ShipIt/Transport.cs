using System.Data;

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

        public Transport(int id, Order order, Ship ship)
        {
            this.id = id;
            this.order = order;
            this.ship = ship;
        }

        public int Id => id;
        public Order Order => order;
        public Ship Ship => ship;
        public bool HasId => ReferenceEquals(null, id);

        /// <summary>
        /// Adds an entry to table Transports in the database.
        /// Author: jako6292 (23/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Add(DataAccess dataAccess)
        {
            if(HasId)
                throw new ItemExistsInDbException();

            DataSet ds = dataAccess.ExecReturn($"CreateTransport {order.Id}, {ship.Id}");
            id = ds.Tables[0].Rows[0].Field<int>("Id");
        }

        /// <summary>
        /// Edits an entry in table Transports in the database.
        /// Author: jako6292 (23/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Update(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"EditTransport {id}, {order.Id}, {ship.Id}");
        }

        /// <summary>
        /// Deletes an entry in table Transports in the database.
        /// Author: jako6292 (24/11/2017)
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Delete(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"DeleteTransport {id}");
        }

        public override string ToString() => $"{Ship} {Order}";
    }
}