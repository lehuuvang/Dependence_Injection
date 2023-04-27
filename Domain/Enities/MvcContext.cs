using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enities
{
    public class MvcContext: DbContext
    {
        public MvcContext()
        {

        }
        public MvcContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Student> Students { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string solutiondir = Directory.GetParent(
                Directory.GetCurrentDirectory()).Parent.FullName;
                IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(solutiondir + "\\Demo_DI\\Demo_DI")
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("AppDb"));
            }
        }
    }
}
