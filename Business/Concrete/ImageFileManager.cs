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
    public class ImageFileManager : IImageFileService
    {
        IImageFileDal _imageFileDal;

        public ImageFileManager(IImageFileDal imageFileDal)
        {
            _imageFileDal = imageFileDal;
        }

        public void Add(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public void Delete(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }

        public List<ImageFile> GetAll()
        {
            return _imageFileDal.GetAll();
        }

        public ImageFile GetById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ImageFile imageFile)
        {
            throw new NotImplementedException();
        }
    }
}
