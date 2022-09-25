using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void ContactAdd(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public void ContactDelete(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void ContactUptade(Contact contact)
        {
            _contactDal.Update(contact);
        }

        public Contact GetByID(int id)
        {
            var contactvalue = _contactDal.Get(x=>x.ContactID == id);
            return contactvalue;
        }

        public List<Contact> GetList()
        {
            return _contactDal.List();
        }
    }
}
