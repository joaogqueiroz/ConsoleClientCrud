using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projeto04.Repositories
{
    //<T> generic data type
    public abstract class BaseRepository<T>
    {
        public abstract void Insert(T obj);
        public abstract  void Alter(T obj);
        public abstract void Delete(T obj);
        public abstract List<T> Consult();
        public abstract T ConsultByID(Guid id);


    }
}
