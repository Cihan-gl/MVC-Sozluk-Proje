﻿using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{


    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public Message GetByID(int id)
        {
            var messagevalues = _messageDal.Get(x => x.MessageID == id);
            return messagevalues;
        }


        public List<Message> GetListInbox(string p)
        {
            return _messageDal.List(x => x.ReceiverMail == p);
        }

        public List<Message> GetListSendbox(string p)
        {
            return _messageDal.List(x => x.SenderMail == p);
        }

        public void MesageAdd(Message message)
        {
            _messageDal.Insert(message);
        }

        public void MesageDelete(Message message)
        {
            _messageDal.Delete(message);
        }

        public void MesageUpdate(Message message)
        {
            _messageDal.Update(message);
        }
    }
}
