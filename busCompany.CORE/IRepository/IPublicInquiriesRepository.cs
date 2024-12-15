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
        public IEnumerable<PublicInquiries> GetPublicInquiries();
        public int indexOf(int id);

        public PublicInquiries GetByIdPublicInquiry(int id);
        public bool Add(PublicInquiries publicInquiry);
        public bool Update(int id, PublicInquiries publicInquiry);
        public bool DeletePublicInquiry(int id);
    }
}
