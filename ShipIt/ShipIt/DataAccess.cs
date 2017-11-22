using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShipIt
{
	public class DataAccess : CommonDataAccess
	{
		public DataAccess(string connectionString) : base(connectionString) { }

		public void ExecCommand(string sql) => ExecuteNonQuery(sql);
		public DataSet ExecReturn(string sql) => ExecuteQuery(sql);
	}
}