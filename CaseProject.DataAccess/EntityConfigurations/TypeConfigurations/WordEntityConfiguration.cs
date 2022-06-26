using CaseProject.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CaseProject.DataAccess.EntityConfigurations.TypeConfigurations
{
    public class WordEntityConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
            builder.ToTable("Words", "case");

            builder.HasKey(p => p.Value)
                   .HasName("PK_CaseProject_Words");

            builder.Property(p => p.Value)
                   .IsRequired()
                   .HasColumnType("uniqueidentifier")
                   .HasDefaultValueSql("newsequentialid()");

            //Bir sınır belirtilmediği için HasMaxLength insiyatif alınarak yapıldı. Değiştirilmesi istendiğinde bu kısım değiştirebilir.
            builder.Property(p => p.Text)
                   .IsRequired()
                   .HasColumnType("nvarchar(max)")
                   //.HasMaxLength(100)
                   ;
        }
    }
}
