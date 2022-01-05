using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IRepository<T>
    {
        //CRUD Operations
        List<T> List();
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
    }
}
