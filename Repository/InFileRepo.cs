using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    class InFileRepo<Id, E> : InMemoryRepo<Id, E> where E:BaseClass<Id> 
    {
        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }

        public InFileRepo(string fileName)
        {
            FileName = fileName;
            LoadData();
        }

        public void WriteToFile()
        {

        }
        public void LoadData()
        {

        }
        public override E Adauga(E element)
        {
            E returnValue=base.Adauga(element);
            WriteToFile();
            return returnValue;
        }
       
    }
}
