using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using GameShop.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace GameShop.Persistence.EntityConfigurations.FluentAPI
{
    internal class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(property => property.Name).HasMaxLength(30);

            #region Seeding
            Faker randomData = new Faker("az");
            builder.HasData(new Category[]
            {
                // Esas kateqoriyalar:
                new Category() { Id = 1, Name = "Electronics", Priority = 1, ParentId = 0 },
                new Category() { Id = 2, Name = "Clothing",    Priority = 2, ParentId = 0 },
                new Category() { Id = 3, Name = "Transport",   Priority = 3, ParentId = 0 },

                // Esas kateqoriyanin('Electronics') alt kateqoriyalari:
                new Category() { Id = 4, Name = "Computers",     Priority = 1, ParentId = 1 },
                new Category() { Id = 5, Name = "Mobile phones", Priority = 2, ParentId = 1 },

                // Esas kateqoriyanin('Clothing') alt kateqoriyalari:
                new Category() { Id = 6, Name = "Jacket", Priority = 1, ParentId = 2 },
                new Category() { Id = 7, Name = "Shirt",  Priority = 2, ParentId = 2 },
                new Category() { Id = 8, Name = "Socks",  Priority = 3, ParentId = 2 },
                new Category() { Id = 9, Name = "Pants",  Priority = 4, ParentId = 2 },

                // Esas kateqoriyanin('Transport') alt kateqoriyalari:
                new Category() { Id = 10, Name = "Cars",        Priority = 1, ParentId = 3},
                new Category() { Id = 11, Name = "Ships",       Priority = 2, ParentId = 3},
                new Category() { Id = 12, Name = "Motorcycles", Priority = 3, ParentId = 3},
            });
            #endregion Seeding
        }
    }
}