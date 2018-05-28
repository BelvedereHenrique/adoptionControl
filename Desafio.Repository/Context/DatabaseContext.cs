using Desafio.Contracts;
using System.Data.Entity;
using Desafio.Repository.Mappings;

namespace Desafio.Repository.Context
{
    class DatabaseContext: DbContext
    {
        public DbSet<AnimalContract> Animals { get; set; }
        public DbSet<AdopterContract> Adopters { get; set; }

        public DatabaseContext() :base("DefaultConnection"){}

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(Mapper.Adopter);
            modelBuilder.Configurations.Add(Mapper.Animal);
        }

        public static DatabaseContext GetInstance()
        {
            return new DatabaseContext();
        }
        
    }
}
