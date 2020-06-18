using Model.Entities;
using System.Data.Entity.ModelConfiguration;

namespace DataAccess.DatabaseConfig
{
    public class PictureConfigurations : EntityTypeConfiguration<Picture>
    {
        public PictureConfigurations()
        {
            this.Property(s => s.FileName)
                .IsRequired()
                .HasMaxLength(50);

            this.Property(s => s.FileName)
                .IsConcurrencyToken();

            // Configure a one-to-one relationship between Student & StudentAddress
            //this.HasOptional(s => s.FileName) // Mark Student.Address property optional (nullable)
                //.WithRequired(ad => ad.Student); // Mark StudentAddress.Student property as required (NotNull).
        }
    }
}