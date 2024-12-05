using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using busCompany.CORE.IService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.SERVICE.Service
{
    public class PublicInquiriesService : IPublicInquiriesService
    {
        readonly IPublicInquiriesRepository _publicInquiriesRepository;
        public PublicInquiriesService(IPublicInquiriesRepository publicInquiriesRepository)
        {
            _publicInquiriesRepository = publicInquiriesRepository;
        }
        public bool Add(PublicInquiries publicInquiry)
        {
            if (GetPublicInquiry(publicInquiry.Id) != null)
                return false;
            return _publicInquiriesRepository.Add(publicInquiry);
        }

        public bool DeleteOne(int id)
        {
            return _publicInquiriesRepository.DeletePublicInquiry(id);
        }

        public List<PublicInquiries> GetAll()
        {
            return _publicInquiriesRepository.GetPublicInquiries();
        }

        public PublicInquiries GetPublicInquiry(int id)
        {
            return _publicInquiriesRepository.GetByIdPublicInquiry(id);
        }

        public bool Update(int id, PublicInquiries publicInquiries)
        {
         
            if (  GetAll().Count == 0)
                return false;
            if (_publicInquiriesRepository.indexOf(id) == -1) return false;
            return _publicInquiriesRepository.Update(id,publicInquiries);
        }
    }
}
