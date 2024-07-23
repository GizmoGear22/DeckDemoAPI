using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;
using Models;

namespace DBAccess.DBAccessPoint
{
	public class DBCardAccess : IDBCardAccess
	{
		private readonly IConfiguration _configuration;
		public DBCardAccess(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string CnnVal()
		{
			return _configuration.GetConnectionString("DBAccessHandler");
		}

		public async Task<List<T>> DBGetConnectionHandler<T>(string sqlString)
		{
			using (var connection = new SqlConnection(CnnVal()))
				try
				{
					connection.Open();
					var data = await connection.QueryAsync<T>(sqlString);
					return data.ToList();
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex.Message);
					throw;
				}

		}
		public async Task<List<T>> DBGetConnectionHandlerByType<T>(string sqlString, CardType param)
		{
			using (var connection = new SqlConnection(CnnVal()))
			{
				var parameter = new { type = param };
				var data = await connection.QueryAsync<T>(sqlString, parameter);
				return data.ToList();
			}
		}

		public async Task<T> GetConnectionHandlerById<T>(string sqlString, int Id)
		{
			using (var connection = new SqlConnection(CnnVal()))
			{
				try
				{
					var parameter = new { id = Id };
					var data = await connection.QueryFirstOrDefaultAsync<T>(sqlString, parameter);
					return data;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}
			}
		}

		public async Task<int> DBPostConnectionHandler(string sqlString, object param)
		{
			using (var connection = new SqlConnection(CnnVal()))
			{
				try
				{
					var data = await connection.ExecuteAsync(sqlString, param);
					return data;
				}
				catch (Exception ex)
				{
					throw new Exception(ex.Message);
				}


			}
		}
	}
}
