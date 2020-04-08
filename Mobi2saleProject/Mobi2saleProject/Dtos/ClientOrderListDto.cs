using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class ClientOrderListDto
    {
        public Guid OrderId { get; set; }

        public Guid ClientId { get; set; }

        public DateTime Order_Date { get; set; }

        public int Quantity { get; set; }

        public bool Order_IsOrder { get; set; }

        public decimal TotalCost { get; set; }

        public decimal TotalAmount { get; set; }

        public bool OnDelivery { get; set; }

        public int OrderNo { get; set; }

        public bool Order_IsPaid { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsDeleted { get; set; }

    }
}
