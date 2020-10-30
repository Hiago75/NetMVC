using Microsoft.EntityFrameworkCore;
using NetMVC.Data;
using NetMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetMVC.Services
{
    public class DepartmentService
    {
        private readonly NetMVCContext _context;

        public DepartmentService(NetMVCContext context)
        {
            _context = context;
        }

        public async Task<List<Department>> FindAllAsync()
        {
            return await _context.Department.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
