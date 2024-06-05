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
    /// Brendi temsil edir.
    /// </summary>
    public class Brand : EntityBase
    {
        public Brand()
        {
            
        }

        public Brand(string name)
        {
            this.Name = name;
        }

        #region vars
        public required string Name { get; set; }
        #endregion vars
    }
}