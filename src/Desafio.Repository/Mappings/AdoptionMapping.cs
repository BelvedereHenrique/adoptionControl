//using Desafio.Contracts;
//using System.Data.Entity.ModelConfiguration;

//namespace Desafio.Repository.Mappings
//{
//    internal class AdoptionMapping : EntityTypeConfiguration<AdoptionContract>
//    {
//        public AdoptionMapping()
//        {
//            ToTable("Adoption");
//            HasKey(x => x.ID);
//            Property(x => x.ID).HasColumnName("ID");
//            Property(x => x.Date).HasColumnName("Date");

//            HasRequired(x => x.Adopters).WithMany().HasForeignKey(x=>x.ID);

//        }
//    }
//}