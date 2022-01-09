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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void Add(Content content)
        {
            _contentDal.Add(content);
        }

        public void Delete(Content content)
        {
            _contentDal.Delete(content);
        }

        public List<Content> GetAll()
        {
            return _contentDal.GetAll();
        }

        public List<Content> GetAllByHeadingId(int headingId)
        {
            return _contentDal.GetAll(content => content.HeadingId == headingId);
        }

        public Content GetById(int id)
        {
            return _contentDal.Get(content => content.ContentId == id);
        }

        public void Update(Content content)
        {
            _contentDal.Update(content);
        }
    }
}
