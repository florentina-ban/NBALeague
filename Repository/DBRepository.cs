using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    abstract class DBRepository<Id, E> : InMemoryRepo<Id,E> where E:BaseClass<Id> 
    {

        public string databaseName { get; set; }
        public string catalog { get; set; }
        public string userName;
        public string UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public string pass;

        public string Pass
        {
            get { return pass; }
            set { pass = value; }
        }

        internal abstract void LoadData();
        
        public DBRepository():base()
        {
            databaseName = ConfigurationManager.AppSettings["dataBaseName"];
            catalog = ConfigurationManager.AppSettings["catalog"];
            userName = ConfigurationManager.AppSettings["user"];
            pass = ConfigurationManager.AppSettings["pass"];
            //LoadData();
        }

        internal abstract void InsertInDB(E element);

        public override E Adauga(E element)
        {
            E returnedValue = base.Adauga(element);
            if (returnedValue == null)
                InsertInDB(element);
            return returnedValue;
        }

        public void AddOneFromDB(E element) {
            base.Adauga(element);
        }
    }
}
