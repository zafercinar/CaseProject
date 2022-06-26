using CaseProject.Core.Entities;
using CaseProject.DataAccess.EntityConfigurations.DataConfigurations;
using CaseProject.DataAccess.EntityConfigurations.TypeConfigurations;
using Microsoft.EntityFrameworkCore;

namespace CaseProject.DataAccess.Contexts
{
    public class CaseProjectDbContext : DbContext
    {
        public CaseProjectDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Word> Words { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Entity Type Configurations
            builder.ApplyConfiguration(new WordEntityConfiguration());

            //Entity HasData Configurations - Test için kullanıldı ve kapatıldı.
            // builder.ApplyConfiguration(new WordSeedDataConfiguration());
        }
    }
}
