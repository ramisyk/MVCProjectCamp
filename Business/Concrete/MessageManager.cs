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
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Add(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAll()
        {
            return _messageDal.GetAll();
        }

        public List<Message> GetAllInbox()
        {
            return _messageDal.GetAll(x => x.ReceiverMail == "admin@admin.com");
        }

        public List<Message> GetAllSendbox()
        {
            return _messageDal.GetAll(x => x.SenderMail == "admin@admin.com");
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public void Update(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
