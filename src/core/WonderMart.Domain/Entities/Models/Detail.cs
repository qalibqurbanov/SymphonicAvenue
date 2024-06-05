using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WonderMart.Domain.Entities.Common.Concretes;

namespace WonderMart.Domain.Entities.Models
{
    /// <summary>
    /// Kateqoriyanin detallarini temsil edir.
    /// </summary>
    public class Detail : EntityBase
    {
        public Detail()
        {
            
        }

        public Detail(string title, string description, int categoryId)
        {
            this.Title = title;
            this.Description = description;
            this.CategoryId = categoryId;
        }

        #region vars
        public required string Title { get; set; }
        public required string Description { get; set; }

        public required int CategoryId { get; set; }
        public Category Category { get; set; }
        #endregion vars
    }
}