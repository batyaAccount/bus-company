using busCompany.Core.Entity;
using busCompany.CORE.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace busCompany.DATA.Repository
{
    public class PublicInquiriesRepository:IPublicInquiriesRepository
    {
        readonly DataContext _context;
        public PublicInquiriesRepository(DataContext context)
        {
            _context = context;
        }
        public List<PublicInquiries> GetPublicInquiries() { return _context.PublicInquiries; }
        public PublicInquiries GetByIdPublicInquiry(int id)
        {

            return _context.PublicInquiries.Find(z => z.Id == id);

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
            PublicInquiries publicInquiry1 = _context.PublicInquiries.Find(b => b.Id == id);
            if (publicInquiry1 == null)
                return false;
            DeletePublicInquiry(id);
            publicInquiry1.Id = id;
            publicInquiry1.Driver = publicInquiry.Driver;
            publicInquiry1.Date = publicInquiry.Date;
            publicInquiry1.Description = publicInquiry.Description;
            publicInquiry1.CaredBy = publicInquiry.CaredBy;
            publicInquiry1.Cared = publicInquiry.Cared;
            publicInquiry1.ComplainerName = publicInquiry.ComplainerName;
            publicInquiry1.PhoneNumber = publicInquiry.PhoneNumber;
            if (Add(publicInquiry1))
                return true;
            return false;
        }
        public bool DeletePublicInquiry(int id)
        {
            List<PublicInquiries> l = _context.PublicInquiries;

            PublicInquiries publicToDelete = l.FirstOrDefault(e => e.Id == id);

            if (publicToDelete != null)
            {
                _context.PublicInquiries.Remove(publicToDelete);
                _context.SaveChanges();
                return true;
            }

            return false;

        }
    }
}
