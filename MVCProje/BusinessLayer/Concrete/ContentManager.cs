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
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDelete(Content content)
        {
            _contentDal.Delete(content);
        }

        public void ContentUpdate(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetByID(int Id)
        {
            return _contentDal.Get(x => x.ContentID == Id);
        }

        public List<Content> GetList(string p)
        {
            if (p == "")
            {
                return _contentDal.List();
            }

            return _contentDal.List(x => x.ContentValue.Contains(p));


        }

        public List<Content> GetListByID(int Id)
        {
            return _contentDal.List(x => x.HeadingID == Id);
        }

        public List<Content> GetListByWriter(int id)
        {
            return _contentDal.List(x => x.WriterID == id);
        }
    }
}
