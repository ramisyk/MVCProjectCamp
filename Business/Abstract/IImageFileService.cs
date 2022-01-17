using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IImageFileService
    {
        List<ImageFile> GetAll();
        void Add(ImageFile imageFile);
        void Update(ImageFile imageFile);
        void Delete(ImageFile imageFile);

        ImageFile GetById(int id);
    }
}
