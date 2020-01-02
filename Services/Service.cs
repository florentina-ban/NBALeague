using NBALeague.Domain;
using NBALeague.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Services
{
   class Service<Id, E, Repo> where E : BaseClass<Id> where Repo:DBRepository<Id, E>
    {
        public Repo  myRepo;
      
        public Service(Repo myRepo)
        {
            this.myRepo = myRepo;
            myRepo.LoadData();
        }
       
        public virtual void AdaugaAll(params E[] elem)
        {
            myRepo.AdaugaAll(elem);
        }

        /* daca nu exista il adauga si returneaza null
        daca exista deja intoarce inapoi elementul */
        public virtual E Adauga(E element)
        {
            return myRepo.Adauga(element);
        }
        /*daca exista returneaza obiectul eliminat
          daca nu exista returneaza null */
        public virtual E Elimina(Id cod)
        {
            return myRepo.Elimina(cod);

        }

        virtual public List<E> getToti()
        {
            return myRepo.getToti();
        }

        public E GetOne(Id id)
        {
            return myRepo.GetOne(id);
        }

    }
}
