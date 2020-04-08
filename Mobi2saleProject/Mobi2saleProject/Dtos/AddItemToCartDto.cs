using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class AddItemToCartDto
    {
        public Guid OrderId { get; set; }

        public Guid ClientId { get; set; }

        public Guid ItemId { get; set; }

        public DateTime Order_Date { get; set; }

        public Guid OrderDetailId { get; set; }

        public int Quantity { get; set; }

        public bool Order_IsOrder { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalAmount { get; set; }

        public bool OnDelivery { get; set; }

        public bool Order_IsPaid { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CraetedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }


    }
}
