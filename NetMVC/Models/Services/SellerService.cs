using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NetMVC.Data;

namespace NetMVC.Models.Services
{
    public class SellerService
    {
        private readonly NetMVCContext _context;

        public SellerService(NetMVCContext context)
        {
            _context = context;
        }

        public List<Seller> FindAll()
        {
            return _context.Seller.ToList();
        }

        public void Insert(Seller obj)
        {
            _context.Add(obj);
            _context.SaveChanges();
        }
    }
}
