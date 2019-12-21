using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    class EchipaDBRepo : DBRepository<int, Echipa>
    {
        internal override void LoadData()
        {
            string connetionString;
            SqlConnection cnn;

            string dbn = ConfigurationManager.AppSettings["dataBaseName"];
            connetionString = @"Data Source=" + dbn + ";Initial Catalog=" + catalog + ";User ID=" + UserName + ";Password=" + Pass;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand com;
            SqlDataReader dataReader;
            string sql;

            sql = "select EchipaId, Nume from Echipa ";
            com = new SqlCommand(sql, cnn);
            dataReader = com.ExecuteReader();
            while (dataReader.Read())
            {
                base.AddOneFromDB(new Echipa((int)dataReader.GetValue(0), dataReader.GetValue(1).ToString()));
            }
            cnn.Close();
        }
        internal override void InsertInDB(Echipa element)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=" + databaseName + ";Initial Catalog=" + catalog + ";User ID=" + UserName + ";Password=" + Pass;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand com;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string sql = "insert into Echipa (Nume) values ('" + element.Nume+");";
            com = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            int a = adapter.InsertCommand.ExecuteNonQuery();

            Console.WriteLine(a);
            com.Dispose();
            cnn.Close();
        }
    }
    
}
