using System.Data;

namespace ShipIt
{
	public class DataAccess : CommonDataAccess
	{
		public DataAccess(string connectionString) : base(connectionString)
		{
		}

		public void ExecCommand(string sql) => ExecuteNonQuery(sql);

		private DataSet ExecReturn(string sql) => ExecuteQuery(sql);

		public DataRowCollection GetAllModels() => ExecReturn("GetAllModels").Tables[0].Rows;

		public int InsertModel(Model model) => ExecReturn($"CreateModel '{model.Name}', {model.Depth}, {model.Tonnage}, {model.MaxContainers}").Tables[0].Rows[0].Field<int>("Id");

		public int InsertShip(Ship ship) => ExecReturn($"CreateShip '{ship.Model.GetId()}', {ship.Name}").Tables[0].Rows[0].Field<int>("Id");
	}
}