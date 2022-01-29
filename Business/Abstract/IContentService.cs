using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContentService
    {
        List<Content> GetAll();
        void Add(Content content);
        void Update(Content content);
        void Delete(Content content);

        Content GetById(int id);
        List<Content> GetAllByHeadingId(int headingId);
        List<Content> GetAllByWriterId(int writerId);
    }
}
