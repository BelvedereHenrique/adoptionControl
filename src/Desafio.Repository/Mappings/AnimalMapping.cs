﻿using Desafio.Contracts;
using System.Data.Entity.ModelConfiguration;

namespace Desafio.Repository.Mappings
{
    public class AnimalMapping : EntityTypeConfiguration<AnimalContract>
    {
        public AnimalMapping()
        {
            ToTable("Animals");
            HasKey(x => x.ID);
            Property(x => x.ID).HasColumnName("ID");

            Property(x => x.Name).HasColumnName("Name").IsRequired();
            Property(x => x.AnimalType).HasColumnName("AnimalType").IsRequired();
            Property(x => x.Age).HasColumnName("Age");
            Property(x => x.Weight).HasColumnName("Weight");

            HasOptional(x => x.Adopter).WithMany(x => x.Animals).HasForeignKey(x => x.AdoptedBy);
        }
    }
}
