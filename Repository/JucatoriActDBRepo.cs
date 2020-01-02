using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    class JucatoriActDBRepo : DBRepository<string, JucatorActiv>
    {
        internal override void LoadData()
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=" + databaseName + ";Initial Catalog=" + catalog + ";User ID=" + UserName + ";Password=" + Pass;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand com;
            SqlDataReader dataReader;
            string sql;

            sql = "select JucatorId, MeciId, NrPuncte, Tip from JucatorActiv";
            com = new SqlCommand(sql, cnn);
            dataReader = com.ExecuteReader();
            while (dataReader.Read())
            {
                TipJucator tip = (dataReader.GetValue(3).ToString().Equals("R"))? TipJucator.REZERVA : TipJucator.PARTICIPANT;
                base.AddOneFromDB(new JucatorActiv ((int)dataReader.GetValue(0), (int)dataReader.GetValue(1), (int)dataReader.GetValue(2), tip));
            }
            while (dataReader.Read())
            {
                TipJucator tip = (dataReader.GetValue(3).ToString().Equals("R")) ? TipJucator.REZERVA : TipJucator.PARTICIPANT;
                base.AddOneFromDB(new JucatorActiv((int)dataReader.GetValue(0), (int)dataReader.GetValue(1), (int)dataReader.GetValue(2), tip));
            }
            cnn.Close();
        }
        internal override void InsertInDB(JucatorActiv element)
        {
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=" + databaseName + ";Initial Catalog=" + catalog + ";User ID=" + UserName + ";Password=" + Pass;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand com;
            SqlDataAdapter adapter = new SqlDataAdapter();
            string tip = (element.Tip.Equals(TipJucator.PARTICIPANT)) ? "P" : "R" ;

            string sql = "insert into JucatorActiv (JucatorId, MeciId, nrPuncte, tip) values ('" + element.Id + "','" + element.IdMeci + "'," 
                + element.NrPuncteInscrise +"','" + tip + ");";
            com = new SqlCommand(sql, cnn);
            adapter.InsertCommand = new SqlCommand(sql, cnn);
            int a = adapter.InsertCommand.ExecuteNonQuery();

            Console.WriteLine(a);
            com.Dispose();
            cnn.Close();
        }
    }
}
