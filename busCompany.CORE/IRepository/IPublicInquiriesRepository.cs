using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IRepository
{
    public interface IPublicInquiriesRepository
    {
        public IEnumerable<PublicInquiries> Get();
        public int indexOf(int id);
        public PublicInquiries GetById(int id);
        public PublicInquiries Add(PublicInquiries publicInquiry);
        public bool Update(int id, PublicInquiries publicInquiry);
        public void Delete(int id);
    }
}
