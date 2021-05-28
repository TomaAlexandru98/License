using System;
using System.Collections.Generic;
using System.Text;
using License.Models.Models;
using Microsoft.EntityFrameworkCore;

namespace License.DataAccess
{
    public class LicenseDbContext : DbContext
    {
        public LicenseDbContext(DbContextOptions<LicenseDbContext> options) : base(options)
        {

        }

        public DbSet<UserModel> Users { get; set; }

        public DbSet<CategoryModel> Categories { get; set; }

        public DbSet<SubcategoryModel> Subcategories { get; set; }

        public DbSet<ServiceModel> Services { get; set; }
    }
}
