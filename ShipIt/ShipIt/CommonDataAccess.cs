using System;
using System.Data;
using System.Data.SqlClient;

namespace ShipIt
{
	public class CommonDataAccess
	{
		private string connectionString;

		/// <summary>
		/// Initializes a new instance of the CommonDataAccess class.
		/// Needs a connection string for the connection.
		/// </summary>
		/// <param name="conString">Connection string to the database</param>
		public CommonDataAccess(string conString) => connectionString = conString;

		/// <summary>
		/// Method used to make a query to the database with an SQL statement,
		/// that maintains data in the database. The SQL statement should be
		/// INSERT, DELETE or UPDATE.
		/// </summary>
		/// <param name="sql">The SQL statement to be sent to the database</param>
		/// <returns>Affected rows</returns>
		/// <exception cref="SqlException">Thrown when the server returns a warning or error.</exception>
		protected int ExecuteNonQuery(string sql)
		{
			int affectedRows = 0; //Used to store the affected rows

			//Uses the connection and command
			//The using makes sure to close and dispose the objects in the end
			using (SqlConnection con = new SqlConnection(connectionString))
			using (SqlCommand command = new SqlCommand(sql, con))
			{
				try
				{
					con.Open();
					affectedRows = command.ExecuteNonQuery();
				}
				catch (Exception)
				{
					throw;
				}
			}

			return affectedRows;
		}

		/// <summary>
		/// Method used to make a query for data in the database.
		/// This is used with an SQL statement using SELECT.
		/// </summary>
		/// <param name="sql">The SQL statement to be sent to the database</param>
		/// <returns>A DataSet object containing the result</returns>
		/// <exception cref="SqlException">Thrown when the server returns a warning or error.</exception>
		protected DataSet ExecuteQuery(string sql)
		{
			DataSet dataSet = new DataSet(); //The dataset to be returned

			//Uses the connection and command
			//The using makes sure to close and dispose the objects in the end
			using (SqlConnection con = new SqlConnection(connectionString))
			using (SqlCommand command = new SqlCommand(sql, con))
			{
				try
				{
					//Open the connection
					con.Open();
					//Get the data from the database
					SqlDataAdapter da = new SqlDataAdapter(command);

					da.Fill(dataSet);
				}
				catch (Exception)
				{
					throw;
				}
			}
			return dataSet;
		}
	}
}