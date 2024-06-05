using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderMart.Domain.Entities.Common.Concretes;

namespace WonderMart.Domain.Entities.Models
{
    public class Product : EntityBase
    {
        public Product()
        {
            
        }

        public Product(string title, string description, decimal prict, decimal discount, int brandId)
        {
            this.Title = title;
            this.Description = description;
            this.Price = Price;
            this.Discount = discount;
            this.BrandId = brandId;
        }

        #region vars
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required decimal Price { get; set; }
        public required decimal Discount { get; set; }

        public required int BrandId { get; set; }
        public Brand Brand { get; set; }

        public ICollection<Category> Categories { get; set; }
        #endregion vars
    }
}