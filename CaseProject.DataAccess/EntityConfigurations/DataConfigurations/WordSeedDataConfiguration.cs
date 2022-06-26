using CaseProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseProject.DataAccess.EntityConfigurations.DataConfigurations
{
    public class WordSeedDataConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.HasData(new Word { Value = Guid.NewGuid(), Text = "Deneme1içineklenmiştir" });
            builder.HasData(new Word { Value = Guid.NewGuid(), Text = "Deneme2içineklenmiştir" });
            builder.HasData(new Word { Value = Guid.NewGuid(), Text = "Deneme3içineklenmiştir" });
        }
    }
}
