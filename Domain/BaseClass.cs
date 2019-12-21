using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NBALeague.Domain
{
    class BaseClass<T>
    {
        private T id;

        public T Id
        {
            get { return id; }
            set { id = value; }
        }



        public BaseClass(T id)
        {
            Id = id;
        }


        public override bool Equals(object obj)
        {
            var @class = obj as BaseClass<T>;
            return @class != null &&
                   EqualityComparer<T>.Default.Equals(id, @class.id) &&
                   EqualityComparer<T>.Default.Equals(Id, @class.Id);
        }

        public override string ToString()
        {
            return ("baseClass {id "+Id+" }");
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
