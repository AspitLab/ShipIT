using System.Collections.Generic;
using System.Data;

namespace ShipIt
{
    public class Model
    {
        private string name;
        private double depth;
        private int tonnage;
        private int maxContainers;
        private int id;

        public List<Harbour> Restrictions = new List<Harbour>();

        public Model(string name, double depth, int tonnage, int maxContainers)
        {
            this.name = name;
            this.depth = depth;
            this.tonnage = tonnage;
            this.maxContainers = maxContainers;
        }

        public Model(int id, string name, double depth, int tonnage, int maxContainers)
        {
            this.id = id;
            this.name = name;
            this.depth = depth;
            this.tonnage = tonnage;
            this.maxContainers = maxContainers;
        }

        public void Add(DataAccess dataAccess)
        {
            if (HasId)
                throw new ItemExistsInDbException();

			id = dataAccess.InsertModel(this);
		}
            DataSet ds = dataAccess.ExecReturn($"CreateModel '{Name}', {Depth}, {Tonnage}, {MaxContainers}");
            id = ds.Tables[0].Rows[0].Field<int>("Id");
        }

        /// <summary>
        /// Edits an entry in table Models in the database.
        /// Author: jako6292 (23/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Edit(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"EditModel {id}, '{name}', {depth}, {tonnage}, {maxContainers}");
        }

        /// <summary>
        /// Deletes an entry in table Models in the database.
        /// Author: jako6292 (24/11/2017)
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Delete(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"DeleteModel {id}");
        }

		public string Name => name;
		public double Depth => depth;
		public int Tonnage => tonnage;
		public int MaxContainers => maxContainers;
		public bool HasId => (!(ReferenceEquals(null, id) || id == 0));

		public int GetId() => id;

		public override string ToString() => Name;
	}
}