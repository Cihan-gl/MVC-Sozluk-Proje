using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GetListInbox(string p);
        List<Message> GetListSendbox(string p);
        Message GetByID(int id);
        void MesageAdd(Message message);
        void MesageDelete(Message message);
        void MesageUpdate(Message message);
    }
}
