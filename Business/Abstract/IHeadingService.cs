using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetAll();
        List<Heading> GetAllByWriterId(int id);

        void Add(Heading heading);
        void Update(Heading heading);
        void Delete(Heading heading);

        Heading GetById(int id);
    }
}
