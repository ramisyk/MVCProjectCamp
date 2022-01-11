using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMessageService
    {
        List<Message> GetAll();
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);

        Message GetById(int id);
    }
}
