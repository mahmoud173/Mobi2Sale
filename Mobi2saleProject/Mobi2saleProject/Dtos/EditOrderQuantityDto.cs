using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class EditOrderQuantityDto
    {
        public Guid orderDetailId { get; set; }

        public Guid orderId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalAmount { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public bool Order_IsOrder { get; set; }

    }
}
