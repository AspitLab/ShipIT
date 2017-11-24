using System;
using System.Data;

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

        public Order(Harbour origin, Harbour destination, DateTime date, double weight, int containers)
        {
            this.date = date;
            this.weight = weight;
            this.containers = containers;
            this.origin = origin;
            this.destination = destination;
        }

        public Order(int id, Harbour origin, Harbour destination, DateTime date, double weight, int containers)
        {
            this.id = id;
            this.date = date;
            this.weight = weight;
            this.containers = containers;
            this.origin = origin;
            this.destination = destination;
        }

        public int Id => id;
        public Harbour Origin => origin;
        public Harbour Destination => destination;
        public DateTime Date => date;
        public double Weight => weight;
        public int Containers => containers;
        public bool HasId => ReferenceEquals(null, id);

        /// <summary>
        /// Adds an entry to table Orders in the database.
        /// Author: jako6292 (23/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess</param>
        public void Add(DataAccess dataAccess)
        {
            if(HasId)
                throw new ItemExistsInDbException();

            DataSet ds = dataAccess.ExecReturn($"CreateOrder '{origin}', {destination}, {containers}, {weight}, {date}");
            id = ds.Tables[0].Rows[0].Field<int>("Id");
        }

        /// <summary>
        /// Edits an entry in table Orders in the database.
        /// Author: jako6292 (23/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Update(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"EditOrder {id}, '{origin}', {destination}, {containers}, {weight}, {date}");
        }

        /// <summary>
        /// Deletes an entry in table Orders in the database.
        /// Author: jako6292 (24/11/2017)
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Delete(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"DeleteOrder {id}");
        }

        //public void LoadFromDB(DataAccess dataAccess)
        //{
        //    if(!HasId)
        //        throw new DataException();

        //    DataSet ds = dataAccess.ExecReturn($"CreateModel {id}");
        //    id = ds.Tables[0].Rows[0].Field<int>("Id");
        //}

        public override string ToString() => $"{Date.ToString("dd/MM/yyyy")}: {Origin} -> {Destination}";
    }
}