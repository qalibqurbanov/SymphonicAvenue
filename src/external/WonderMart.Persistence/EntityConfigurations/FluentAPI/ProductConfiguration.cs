using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using WonderMart.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WonderMart.Persistence.EntityConfigurations.FluentAPI
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(property => property.Title).HasMaxLength(256);

            #region Seeding
            Faker randomData = new Faker("az");
            builder.HasData(new Product[]
            {
                new Product() { Title = randomData.Commerce.ProductName(), Description = randomData.Commerce.ProductDescription(), BrandId = 2, Discount = randomData.Random.Decimal(0, 20), Price = randomData.Finance.Amount(10.0m, 1000.0m) },
                new Product() { Title = randomData.Commerce.ProductName(), Description = randomData.Commerce.ProductDescription(), BrandId = 5, Discount = randomData.Random.Decimal(0, 20), Price = randomData.Finance.Amount(10.0m, 1000.0m) },
                new Product() { Title = randomData.Commerce.ProductName(), Description = randomData.Commerce.ProductDescription(), BrandId = 4, Discount = randomData.Random.Decimal(0, 20), Price = randomData.Finance.Amount(10.0m, 1000.0m) },
                new Product() { Title = randomData.Commerce.ProductName(), Description = randomData.Commerce.ProductDescription(), BrandId = 1, Discount = randomData.Random.Decimal(0, 20), Price = randomData.Finance.Amount(10.0m, 1000.0m) },
                new Product() { Title = randomData.Commerce.ProductName(), Description = randomData.Commerce.ProductDescription(), BrandId = 3, Discount = randomData.Random.Decimal(0, 20), Price = randomData.Finance.Amount(10.0m, 1000.0m) }
            });
            #endregion Seeding
        }
    }
}