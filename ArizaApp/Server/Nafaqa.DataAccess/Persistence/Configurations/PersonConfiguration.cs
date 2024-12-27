using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nafaqa.Core.Entities;

namespace Nafaqa.DataAccess.Persistence.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder.ToTable("Persons");
        builder.HasKey(x => x.Id);

        builder.HasKey(i => i.Id);

        builder.Property(i => i.FullName)
            .IsRequired()
            .HasMaxLength(50);
        
        builder.Property(i=>i.PassportSeria)
            .IsRequired()
            .HasMaxLength(10);
        
        builder.Property(i=>i.PassportNumber)
            .IsRequired();
    }
}