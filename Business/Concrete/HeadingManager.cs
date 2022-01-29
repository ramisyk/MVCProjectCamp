using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void Add(Heading heading)
        {
            _headingDal.Add(heading);
        }

        public void Delete(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public List<Heading> GetAll()
        {
            return _headingDal.GetAll();
        }
        public List<Heading> GetAllByWriterId(int id)
        {
            return _headingDal.GetAll(heading => heading.WriterId == id && heading.HeadingStatus ==true);
        }

        public Heading GetById(int id)
        {
            return _headingDal.Get(heading => heading.HeadingId == id);
        }

        public void Update(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
