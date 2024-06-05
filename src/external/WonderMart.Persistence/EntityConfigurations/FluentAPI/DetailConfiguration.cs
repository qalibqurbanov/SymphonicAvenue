using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bogus;
using WonderMart.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace WonderMart.Persistence.EntityConfigurations.FluentAPI
{
    internal class DetailConfiguration : IEntityTypeConfiguration<Detail>
    {
        public void Configure(EntityTypeBuilder<Detail> builder)
        {
            builder.Property(property => property.Title).HasMaxLength(25);
            builder.Property(property => property.Description).HasMaxLength(50);

            #region Seeding
            Faker randomData = new Faker("az");
            builder.HasData(new Detail[]
            {
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 1 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 2 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 3 },

                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 4 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 5 },

                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 6 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 7 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 8 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 9 },

                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 10 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 11 },
                new Detail() { Title = randomData.Lorem.Sentence(1), Description = randomData.Lorem.Sentence(3), CategoryId = 12 },
            });
            #endregion Seeding
        }
    }
}