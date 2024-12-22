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
        readonly IRepositoryMamager _publicInquiriesRepository;
        public PublicInquiriesService(IRepositoryMamager publicInquiriesRepository)
        {
            _publicInquiriesRepository = publicInquiriesRepository;
        }
        public bool Add(PublicInquiries publicInquiry)
        {
            if (GetPublicInquiry(publicInquiry.Id) != null)
                return false;
            bool flag = _publicInquiriesRepository.PublicInquiries.Add(publicInquiry);
            if (flag)
                _publicInquiriesRepository.Save();
            return flag;
        }

        public bool DeleteOne(int id)
        {
            bool flag = _publicInquiriesRepository.PublicInquiries.DeletePublicInquiry(id);
            if (flag)
                _publicInquiriesRepository.Save();
            return flag;
        }

        public IEnumerable<PublicInquiries> GetAll()
        {
            return _publicInquiriesRepository.PublicInquiries.GetPublicInquiries();
        }

        public PublicInquiries GetPublicInquiry(int id)
        {
            return _publicInquiriesRepository.PublicInquiries.GetByIdPublicInquiry(id);
        }

        public bool Update(int id, PublicInquiries publicInquiries)
        {

            if (GetAll().Count() == 0)
                return false;
            if (_publicInquiriesRepository.PublicInquiries.indexOf(id) == -1) return false;
            bool flag = _publicInquiriesRepository.PublicInquiries.Update(id, publicInquiries);
            if (flag)
                _publicInquiriesRepository.Save();
            return flag;
        }
    }
}
