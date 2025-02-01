using AutoMapper;
using busCompany.Core.Entity;
using busCompany.CORE.DTOs;
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
        readonly IMapper _mapper;
        public PublicInquiriesService(IRepositoryMamager repositoryMamager, IPublicInquiriesRepository publicInquiriesRepository,IMapper mapper)
        {
            _repositoryMamager = repositoryMamager;
            _publicInquiriesRepository = publicInquiriesRepository;
            _mapper = mapper;

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

        public IEnumerable<PublicInquiriesDto> GetAll()
        {
            var publicInquiries= _publicInquiriesRepository.Get().ToList();
            return _mapper.Map<IEnumerable<PublicInquiriesDto>>(publicInquiries);
        }

        public PublicInquiriesDto GetPublicInquiry(int id)
        {
            var publicInquiry = _publicInquiriesRepository.GetById(id);
            return _mapper.Map<PublicInquiriesDto>(publicInquiry);
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
