using System;
using System.Data;
using System.Threading.Tasks;
using Dapper;
using Npgsql;

namespace SexySQL
{
    public class Database
    {
        private const string ConnectionString = 
            "Host=139.28.223.173;Port=5432;User ID=ovsidorenkov;Password=ovsidorenkov;Database=ovsidorenkov_db;";
        public Database()
        {
              CreateTable();
        }

        private static void CreateTable()
        {
            using IDbConnection dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();
            dbConnection.Query(@"CREATE TABLE  IF NOT EXISTS birja_for_andrey.CURRENCY_DATA (
                ID SERIAL PRIMARY KEY DEFAULT, 
                DATETIME timestamp NOT NULL, 
                DOLLAR FLOAT NOT NULL, 
                EURO FLOAT NOT NULL, 
                JENA FLOAT NOT NULL
                );");
        }

        public void InsertCurrencyData(CurrencyData item)
        {
            using IDbConnection dbConnection = new NpgsqlConnection(ConnectionString);
            dbConnection.Open();
            dbConnection.Query(
                "INSERT INTO birja_for_andrey.currency_data VALUES (2, '2021-01-01 00:00:00', 1.0, 1.0, 1.0);");
            // @$"INSERT INTO birja_for_andrey.CURRENCY_DATA  VALUES 
            //('{item.Date:yyyy-MM-dd HH:mm:ss.f}', '{item.Dollar}', '{item.Euro}', '{item.Jena}');"
        }
    }
}