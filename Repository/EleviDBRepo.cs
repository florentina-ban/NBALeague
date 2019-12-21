using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    class EleviDBRepo : DBRepository<int, Elev>
    {
        internal override void LoadData()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source="+databaseName+";Initial Catalog="+catalog+";User ID="+UserName+";Password="+Pass;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand com;
            SqlDataReader dataReader;
            string sql;

            sql = "select ElevId, Nume, Scoala from Elev";
            com = new SqlCommand(sql, cnn);
            dataReader = com.ExecuteReader();
            while (dataReader.Read())
            {
                base.AddOneFromDB(new Elev((int)dataReader.GetValue(0), dataReader.GetValue(1).ToString(), dataReader.GetValue(2).ToString()));
            }
            cnn.Close();
        }
        internal override void InsertInDB(Elev element)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=" + databaseName + ";Initial Catalog=" + catalog + ";User ID=" + UserName + ";Password=" + Pass;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand com;
            SqlDataAdapter adapter=new SqlDataAdapter();
            string sql="insert into Elev (Nume, Scoala, EchipaId) values ('"+element.Nume+"','"+element.Scoala+"',"+"2 );" ;
            com = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            int a=adapter.InsertCommand.ExecuteNonQuery();

              Console.WriteLine(a);
            com.Dispose();
            cnn.Close();
        }

    }
}
