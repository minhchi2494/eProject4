using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Model;

namespace WebAPI.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }

        public DbSet<admin> admins { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<image> images { get; set; }
        public DbSet<location> locations { get; set; }
        public DbSet<manager> managers { get; set; }
        public DbSet<product> products { get; set; }
        public DbSet<report> reports { get; set; }
        public DbSet<role> roles { get; set; }
        public DbSet<sales_detail> sales_details { get; set; }
        public DbSet<store> stores { get; set; }
        public DbSet<store_sales_detail> store_sales_details { get; set; }
        public DbSet<target> targets { get; set; }
    }
}
