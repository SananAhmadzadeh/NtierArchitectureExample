using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace NtierArchitecture.DataAccess.Configurations
{
    public class CategoryConfigurations : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(p => p.Name)
             .IsRequired()
             .HasMaxLength(100);

            builder.Property(p => p.Description)
                .HasMaxLength(500);
        }
    }
}
