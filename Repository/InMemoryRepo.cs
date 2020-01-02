using NBALeague.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Repository
{
    class InMemoryRepo<Id, E> : IRepository<Id,E> where E: BaseClass<Id> 
    {
        private  List<E> toti;

        public InMemoryRepo()
        {
            this.toti = new List<E>();
        }

        public virtual void AdaugaAll(params E[] elem)
        {
            elem.ToList().ForEach(e => this.Adauga(e));
        }

        /* daca nu exista il adauga si returneaza null
        daca exista deja intoarce inapoi elementul */
        public virtual E Adauga(E element)
        {
            bool exists = toti.Any(e => e.Id.Equals(element.Id));
            if (!exists)
            {
                toti.Add(element);
                return null;
            }
            else return element;
        }
        /*daca exista returneaza obiectul eliminat
          daca nu exista returneaza null */
        public virtual E Elimina(Id cod)
        {
            if (!toti.Any(e => e.Id.Equals(cod)))
                return null;
            else
            {
                E element=toti.Where(e=>e.Id.Equals(cod)).ToList().ElementAt(0);
                toti = toti.Where(e => !e.Id.Equals(cod)).ToList();
                return element;
            }

        }

        virtual public List<E> getToti()
        {
            return toti;
        }

        public E GetOne(Id id)
        {
            E[] li = toti.Where(x => x.Id.Equals(id)).ToArray();
            if (li.Length == 0)
                return null;
             return li[0];
        }

        public int Lungime()
        {
            return toti.Count();
        }
    }
}
