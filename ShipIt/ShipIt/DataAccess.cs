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
	}
}