using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Repository.Data
{
    public class DbConection
    {

        string connectionString = "Host=myserver;Port=5432;Database=parcial1;Username=postgres;Password=12345;";

        public DbConection(string _connectionString)
        {
            this.connectionString = _connectionString;
        }

        public IDbConnection dbConnection()
        {

            try
            {
                IDbConnection conexion = new NpgsqlConnection(connectionString);
                conexion.Open();
                return conexion;
            }
            catch (Exception ex)
            {
                throw new NpgsqlException(ex.Message);
            }
        }
    }
}