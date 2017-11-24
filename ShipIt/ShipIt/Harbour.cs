using System.Data;

namespace ShipIt
{
    public class Harbour
    {
        private string name;
        private int id;
        private double depth;

        public Harbour(string name, double depth)
        {
            this.name = name;
            this.depth = depth;
        }

        public Harbour(int id, string name, double depth)
        {
            this.id = id;
            this.name = name;
            this.depth = depth;
        }

        public int Id => id;
        public string Name => name;
        public double Depth => depth;
        public bool HasId => ReferenceEquals(null, id);

        /// <summary>
        /// Adds an entry to table Harbours in the database.
        /// Author: jako6292 (23/11/2017)
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess</param>
        public void Add(DataAccess dataAccess)
        {
            if(HasId)
                throw new ItemExistsInDbException();

            DataSet ds = dataAccess.ExecReturn($"CreateHarbour '{name}', {depth}");
            id = ds.Tables[0].Rows[0].Field<int>("Id");
        }

        /// <summary>
        /// Edits an entry in table Harbours in the database.
        /// Author: jako6292 (24/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Update(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"EditHarbour {id}, '{name}', {depth}");
        }

        /// <summary>
        /// Deletes an entry in table Harbours in the database.
        /// Author: jako6292 (24/11/2017)
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Delete(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"DeleteHarbour {id}");
        }

        public override string ToString() => Name;
    }
}