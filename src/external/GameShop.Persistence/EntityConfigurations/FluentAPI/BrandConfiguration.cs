using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Bogus;
using System.Net.Http.Headers;

namespace GameShop.Persistence.EntityConfigurations.FluentAPI
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            builder.Property(property => property.Name).HasMaxLength(50);

            #region Seeding
            Faker randomData = new Faker("az");
            builder.HasData(new Brand[]
            {
                new Brand() { Id = 1, Name = randomData.Commerce.Department(1) },
                new Brand() { Id = 2, Name = randomData.Commerce.Department(1) },
                new Brand() { Id = 3, Name = randomData.Commerce.Department(1) },
                new Brand() { Id = 4, Name = randomData.Commerce.Department(1) },
                new Brand() { Id = 5, Name = randomData.Commerce.Department(1) }
            });
            #endregion Seeding
        }
    }
}