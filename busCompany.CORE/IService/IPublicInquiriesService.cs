using busCompany.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IPublicInquiriesService
    {
        public List<PublicInquiries> GetAll();
        public PublicInquiries GetPublicInquiry(int id);
        public bool Add(PublicInquiries publicInquiries);
        public bool Update(int id, PublicInquiries publicInquiries);
        public bool DeleteOne(int id);
    }
}
