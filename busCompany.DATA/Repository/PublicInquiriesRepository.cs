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
    public class PublicInquiriesRepository :Repository<PublicInquiries>, IPublicInquiriesRepository
    {
        readonly DataContext _context;
        public PublicInquiriesRepository(DataContext context):base(context)
        {
            _context = context;
        }
        public override IEnumerable<PublicInquiries> Get() { return _dbSet.Include(p=>p.Driver); }
        public bool Update(int id, PublicInquiries publicInquiry)
        {

            PublicInquiries publicInquiry1 = GetById(id);

            publicInquiry1.ComplainerName = publicInquiry.ComplainerName;
            publicInquiry1.Driver = publicInquiry.Driver;
            publicInquiry1.Cared = publicInquiry.Cared;
            publicInquiry1.CaredBy = publicInquiry.CaredBy;
            publicInquiry1.Date = publicInquiry.Date;
            publicInquiry1.Description = publicInquiry.Description;
            publicInquiry1.PhoneNumber = publicInquiry.PhoneNumber;
            return true;
        }
        public int indexOf(int id)
        {
            return Get().ToList().FindIndex(b => b.Id == id);
        }
    }
}
