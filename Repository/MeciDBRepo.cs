using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    class MeciDBRepo : DBRepository<int, Meci>
    {
        private EchipaDBRepo echipeRepo;

        public MeciDBRepo(EchipaDBRepo echipeRepo)
        {
            this.echipeRepo = echipeRepo;
        }

        internal override void InsertInDB(Meci element)
        {
            throw new NotImplementedException();
        }

        internal override void LoadData()
        {// not ready!
            
            string connetionString;
            SqlConnection cnn;
            connetionString = @"Data Source=" + databaseName + ";Initial Catalog=" + catalog + ";User ID=" + UserName + ";Password=" + Pass;
            cnn = new SqlConnection(connetionString);
            cnn.Open();

            SqlCommand com;
            SqlDataReader dataReader;
            string sql;

            sql = "select MeciId, Echipa2,Echipa2, Scor2, Scor2, Data from Meci";
            com = new SqlCommand(sql, cnn);
            dataReader = com.ExecuteReader();
            List<Echipa> echipe = echipeRepo.getToti();
            while (dataReader.Read())
            {
                Echipa e1 = echipeRepo.GetOne((int)dataReader.GetValue(1));
                Echipa e2 = echipeRepo.GetOne((int)dataReader.GetValue(2));
                base.AddOneFromDB(new Meci((int)dataReader.GetValue(0), e1,e2,(int)dataReader.GetValue(2),(int)dataReader.GetValue(3),(DateTime)dataReader.GetValue(4)));
            }
            cnn.Close();
           
        }
    }
}
