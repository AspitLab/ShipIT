using System.Collections.Generic;
using System.Data;

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

        public Ship(int id, Model model, string name)
        {
            this.id = id;
            this.model = model;
            this.name = name;
        }

        public int Id => id;
        public Model Model => model;
        public string Name => name;
        public bool HasId => ReferenceEquals(null, id);

        /// <summary>
        /// Adds an entry to table Ships in the database.
        /// Author: jako6292 (23/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Create(DataAccess dataAccess)
        {
            if(HasId)
                throw new ItemExistsInDbException();

            DataSet ds = dataAccess.ExecReturn($"CreateShip {model.Id}, '{Name}'");
            id = ds.Tables[0].Rows[0].Field<int>("Id");
        }

        /// <summary>
        /// Edits an entry in table Ships in the database.
        /// Author: jako6292 (23/11/2017).
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Update(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"EditShip {id}, {model.Id}, '{Name}'");
        }

        /// <summary>
        /// Deletes an entry in table Ships in the database.
        /// Author: jako6292 (24/11/2017)
        /// </summary>
        /// <param name="dataAccess">An instance of DataAccess.</param>
        public void Delete(DataAccess dataAccess)
        {
            if(!HasId)
                throw new DataException();

            dataAccess.ExecCommand($"DeleteShip {id}");
        }

        public override string ToString() => Name;
    }
}