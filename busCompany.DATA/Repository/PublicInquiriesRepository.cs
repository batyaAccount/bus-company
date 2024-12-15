using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class PublicInquiriesRepository : IPublicInquiriesRepository
    {
        readonly DataContext _context;
        public PublicInquiriesRepository(DataContext context)
        {
            _context = context;
        }
        public IEnumerable<PublicInquiries> GetPublicInquiries() { return _context.PublicInquiries.Include(p=>p.Driver); }
        public PublicInquiries GetByIdPublicInquiry(int id)
        {

            return _context.PublicInquiries.ToList().Find(z => z.Id == id);

        }
        public bool Add(PublicInquiries publicInquiry)
        {

            try
            {
                _context.PublicInquiries.Add(publicInquiry);
                _context.SaveChanges();

                return true;
            }
            catch
            {
                return false;

            }

        }
        public bool Update(int id, PublicInquiries publicInquiry)
        {

            //The validate checking was done in the service
            PublicInquiries publicInquiry1 = _context.PublicInquiries.ToList().Find(b => b.Id == id);

            _ = publicInquiry.ComplainerName != null && publicInquiry.ComplainerName != publicInquiry1.ComplainerName ?
            publicInquiry1.ComplainerName = publicInquiry.ComplainerName : publicInquiry1.ComplainerName = publicInquiry1.ComplainerName;

            _ = publicInquiry.DriverId != 0 && publicInquiry.DriverId != publicInquiry1.DriverId ?
            publicInquiry1.Driver = publicInquiry.Driver : publicInquiry1.Driver = publicInquiry1.Driver;

            _ = publicInquiry.Cared != publicInquiry1.Cared ?
              publicInquiry1.Cared = publicInquiry.Cared : publicInquiry1.Cared = publicInquiry1.Cared;

            _ = publicInquiry.CaredBy != publicInquiry1.CaredBy && publicInquiry.CaredBy !=0?
              publicInquiry1.CaredBy = publicInquiry.CaredBy : publicInquiry1.CaredBy = publicInquiry1.CaredBy;

            _ = publicInquiry.Date != publicInquiry1.Date && publicInquiry.Date != DateTime.MinValue ?
              publicInquiry1.Date = publicInquiry.Date : publicInquiry1.Date = publicInquiry1.Date;

            _ = publicInquiry.Description != publicInquiry1.Description && publicInquiry.Description !=null?
              publicInquiry1.Description = publicInquiry.Description : publicInquiry1.Description = publicInquiry1.Description;

            _ = publicInquiry.PhoneNumber != publicInquiry1.PhoneNumber && publicInquiry.PhoneNumber != null ?
              publicInquiry1.PhoneNumber = publicInquiry.PhoneNumber : publicInquiry1.PhoneNumber = publicInquiry1.PhoneNumber;
            _context.SaveChanges();
            return true;
        }
        public bool DeletePublicInquiry(int id)
        {
            List<PublicInquiries> l = _context.PublicInquiries.ToList();

            PublicInquiries publicToDelete = l.FirstOrDefault(e => e.Id == id);

            if (publicToDelete != null)
            {
                _context.PublicInquiries.Remove(publicToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
        public int indexOf(int id)
        {
            return _context.PublicInquiries.ToList().FindIndex(b => b.Id == id);
        }
    }
}
