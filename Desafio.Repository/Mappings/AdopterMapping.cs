using Desafio.Contracts;
using System.Data.Entity.ModelConfiguration;

namespace Desafio.Repository.Mappings
{
    internal class AdopterMapping : EntityTypeConfiguration<AdopterContract>
    {
        public AdopterMapping()
        {
            ToTable("Adopter");

            HasKey(x => x.ID);
            Property(x => x.ID).HasColumnName("ID");

            Property(x => x.Name).HasColumnName("Name").IsRequired();
            Property(x => x.Email).HasColumnName("Email").IsRequired();
            Property(x => x.AddressLine).HasColumnName("AddressLine").IsRequired();
            Property(x => x.Phone).HasColumnName("Phone").IsRequired();
            Property(x => x.State).HasColumnName("State").IsRequired();
            Property(x => x.CreatedOn).HasColumnName("CreatedOn");
            HasMany(x => x.Animals);

        }
    }
}