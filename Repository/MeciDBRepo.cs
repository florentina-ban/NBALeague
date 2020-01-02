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
        public EchipaDBRepo echipeRepo;
        public JucatoriActDBRepo jucActRepo;
        public JucatoriDBRepo jucRepo;

        public MeciDBRepo(EchipaDBRepo echipeRepo, JucatoriActDBRepo jucRepo, JucatoriDBRepo jRepo)
        {
            this.echipeRepo = echipeRepo;
            this.jucActRepo = jucRepo;
            this.jucRepo = jRepo;
        }

        internal override void InsertInDB(Meci element)
        {
            throw new NotImplementedException();
        }

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

            sql = "select MeciId, Echipa1, Echipa2, Data from Meci";
            com = new SqlCommand(sql, cnn);
            dataReader = com.ExecuteReader();
            List<Echipa> echipe = echipeRepo.getToti();
            while (dataReader.Read())
            {
                Echipa e1 = echipeRepo.GetOne((int)dataReader.GetValue(1));
                Echipa e2 = echipeRepo.GetOne((int)dataReader.GetValue(2));
                base.AddOneFromDB(new Meci((int)dataReader.GetValue(0), e1,e2,(DateTime)dataReader.GetValue(3)));
            }
            cnn.Close();
           
        }

        public Scor getScor(int idMeci)
        {
            Meci m = GetOne(idMeci);
            if (m == null)
                return null;
            else
            {
                int EId1 = m.echipa1.Id;
                int EId2 = m.echipa2.Id;

                int sc1 = jucActRepo.getToti().
                    Where(x => x.IdMeci == idMeci && jucRepo.GetOne(x.IdJucator).EchipaMea.Id == EId1)
                    .Sum(x => x.NrPuncteInscrise);

                int sc2 = jucActRepo.getToti().
                    Where(x => x.IdMeci == idMeci && jucRepo.GetOne(x.IdJucator).EchipaMea.Id == EId2)
                    .Sum(x => x.NrPuncteInscrise);

                return new Scor(sc1, sc2, m.echipa1, m.echipa2);
            }

        }

        public List<Scor> getScor(int Eid1, int Eid2)
        {
            List <Meci> mlist = getToti().Where(x=> x.echipa1.Id==Eid1 && x.echipa2.Id==Eid2).ToList();
            if (mlist.ToArray<Meci>().Length == 0)
                return null;
            else
            {
                List<Scor> scorList = new List<Scor>();
                mlist.ForEach(meci =>
                {
                    int sc1 = jucActRepo.getToti().
                        Where(x => x.IdMeci == meci.Id && jucRepo.GetOne(x.IdJucator).EchipaMea.Id == Eid1)
                        .Sum(x => x.NrPuncteInscrise);

                    int sc2 = jucActRepo.getToti().
                        Where(x => x.IdMeci == meci.Id && jucRepo.GetOne(x.IdJucator).EchipaMea.Id == Eid2)
                        .Sum(x => x.NrPuncteInscrise);

                    scorList.Add(new Scor(sc1, sc2, meci.echipa1, meci.echipa2));
                });
                return scorList;
            }
        }
    }
}
