using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.CORE.IService
{
    public interface IPublicInquiriesService
    {
        public IEnumerable<PublicInquiriesDto> GetAll();
        public PublicInquiriesDto GetPublicInquiry(int id);
        public PublicInquiries Add(PublicInquiries publicInquiries);
        public bool Update(int id, PublicInquiries publicInquiries);
        public bool DeleteOne(int id);
    }
}
