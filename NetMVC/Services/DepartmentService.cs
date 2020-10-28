using NetMVC.Data;
using NetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NetMVC.Services
{
    public class DepartmentService
    {
        private readonly NetMVCContext _context;

        public DepartmentService(NetMVCContext context)
        {
            _context = context;
        }

        public List<Department> FindAll()
        {
            return _context.Department.OrderBy(x => x.Name).ToList();
        }
    }
}
