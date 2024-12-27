using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Nafaqa.Core.Entities;

namespace Nafaqa.DataAccess.Persistence.Configurations;

public class PetitionConfiguration : IEntityTypeConfiguration<Petition>
{
    public void Configure(EntityTypeBuilder<Petition> builder)
    {
        builder.ToTable("Petitions");
        
        builder.HasKey(x => x.Id);

        builder.Property(x => x.Letter)
            .HasMaxLength(500);
    }
}