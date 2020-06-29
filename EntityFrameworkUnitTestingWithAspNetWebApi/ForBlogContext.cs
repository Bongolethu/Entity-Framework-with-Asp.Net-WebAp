using System;
using System.IO;
using Azure.Core;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;

namespace EntityFrameworkUnitTestingWithAspNetWebApi
{
    public partial class ForBlogContext : DbContext
    {
        private string _connectionString = "";
        protected readonly IConfiguration _configuration;
        public ForBlogContext(IConfiguration Configuration)
        {
            _configuration = Configuration;
            //_conneString = conf["DefaultConnection"].ToString();
        }
        public ForBlogContext()
        {
            
        }

        //public ForBlogContext(DbContextOptions<ForBlogContext> options)
        //    : base(options)
        //{ 
        //}

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
#if DEBUG 
            var val = _configuration["Prod"];


                     optionsBuilder.UseSqlServer(_configuration["EFUnitTestConnectionStringSecrete"]); 
#else

            optionsBuilder.UseSqlServer(_configuration["ConnectionStrings:DefaultConnection"]);

#endif 
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public DbSet<Person> Person { get; set; }

    }
}
