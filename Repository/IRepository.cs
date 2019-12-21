using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    interface IRepository<Id, E> where E : BaseClass<Id>
    {


        void AdaugaAll(params E[] elem);

        E Adauga(E element);

        /*daca exista returneaza obiectul eliminat
          daca nu exista returneaza null */
        E Elimina(Id cod);

        List<E> getToti();

        int Lungime();

        E GetOne(Id id);
    }

}

