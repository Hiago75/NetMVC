using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using NetMVC.Models;

namespace NetMVC.Data
{
    public class NetMVCContext : DbContext
    {
        public NetMVCContext (DbContextOptions<NetMVCContext> options)
            : base(options)
        {
        }

        public DbSet<NetMVC.Models.Department> Department { get; set; }
    }
}
