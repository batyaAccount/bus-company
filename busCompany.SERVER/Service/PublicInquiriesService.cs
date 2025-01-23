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
        readonly IRepositoryMamager _repositoryMamager;
        readonly IPublicInquiriesRepository _publicInquiriesRepository;
        public PublicInquiriesService(IRepositoryMamager repositoryMamager, IPublicInquiriesRepository publicInquiriesRepository)
        {
            _repositoryMamager = repositoryMamager;
            _publicInquiriesRepository = publicInquiriesRepository;


        }
        public PublicInquiries Add(PublicInquiries publicInquiry)
        {
            if (GetPublicInquiry(publicInquiry.Id) != null)
                return null;
             _publicInquiriesRepository.Add(publicInquiry);
            _repositoryMamager.Save();
            return publicInquiry;
        }

        public bool DeleteOne(int id)
        {
            if(_publicInquiriesRepository.indexOf(id) == -1) 
                return false;
            _publicInquiriesRepository.Delete(id);
            _repositoryMamager.Save();
            return true;
        }

        public IEnumerable<PublicInquiries> GetAll()
        {
            return _publicInquiriesRepository.Get().ToList();
        }

        public PublicInquiries GetPublicInquiry(int id)
        {
            return _publicInquiriesRepository.GetById(id);
        }

        public bool Update(int id, PublicInquiries publicInquiries)
        {

            if (GetAll().Count() == 0)
                return false;
            if (_publicInquiriesRepository.indexOf(id) == -1) return false;
            bool flag = _publicInquiriesRepository.Update(id, publicInquiries);
            if (flag)
                _repositoryMamager.Save();
            return flag;
        }
    }
}
