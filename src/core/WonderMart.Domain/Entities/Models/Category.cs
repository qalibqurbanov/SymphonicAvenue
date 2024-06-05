using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderMart.Domain.Entities.Common.Abstractions;
using WonderMart.Domain.Entities.Common.Concretes;

namespace WonderMart.Domain.Entities.Models
{
    /// <summary>
    /// Kateqoriyani temsil edir.
    /// </summary>
    public class Category : EntityBase
    {
        public Category()
        {
            
        }

        public Category(string name, int parentId, int priority)
        {
            this.Name = name;
            this.ParentId = parentId;
            this.Priority = priority;
        }

        #region vars
        public required string Name { get; set; }
        public required int ParentId { get; set; }
        public required int Priority { get; set; }

        public ICollection<Detail> Details { get; set; }

        public ICollection<Product> Products { get; set; }
        #endregion vars
    }
}