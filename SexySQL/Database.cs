using System;
using System.Data;
using System.Linq;
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
            dbConnection.Query(@"CREATE TABLE  IF NOT EXISTS birja_for_andrey.currency_data(
                ID SERIAL PRIMARY KEY, 
                DATETIME TIMESTAMP NOT NULL, 
                DOLLAR FLOAT NOT NULL, 
                EURO FLOAT NOT NULL, 
                JENA FLOAT NOT NULL
                );");
        }

        public async Task InsertCurrencyData(CurrencyData item)
        {
            await using var dbConnection = new NpgsqlConnection(ConnectionString);
            var num = dbConnection.Query<int>("SELECT count('id') FROM birja_for_andrey.currency_data;");
            var a = await dbConnection.ExecuteAsync($"insert into birja_for_andrey.currency_data values (@id,@dt,@dollar,@euro,@yena);",
                new
                {
                    id = num.ToArray()[0] + 1,
                    dt = item.Date,
                    dollar = item.Dollar,
                    euro = item.Euro,
                    yena = item.Jena
                });
        }
    }
}