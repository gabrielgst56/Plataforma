using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace IFSP.Plataforma.Identity.Data
{
    public class ApplicationDbContext : IdentityDbContext, IDesignTimeDbContextFactory<ApplicationDbContext> 
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseNpgsql(
                    new Configuration().GetConnectionString("DefaultConnection")); 

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
