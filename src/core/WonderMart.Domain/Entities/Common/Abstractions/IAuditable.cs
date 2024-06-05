using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WonderMart.Domain.Entities.Common.Abstractions
{
    public interface IAuditable
    {
        public DateTime? CreatedDate { get; set; }
        public Guid? CreatedBy { get; set; }

        public DateTime? UpdatedDate { get; set; }
        public Guid? UpdatedBy { get; set; }
    }
}