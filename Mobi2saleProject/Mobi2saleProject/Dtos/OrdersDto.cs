using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class OrdersDto
    {
        public Guid OrderId { get; set; }


        public Guid ClientId { get; set; }

        public DateTime Order_Date { get; set; }

        public bool Order_IsOrder { get; set; }

        [Required]
        public decimal TotalCost { get; set; }

        [Required]
        public decimal TotalAmount { get; set; }

        public bool OnDelivery { get; set; }

        public bool Order_IsPaid { get; set; }

        public bool IsCancelled { get; set; }

        public bool IsDeleted { get; set; }

        public string CreatedBy { get; set; }

        public DateTime CraetedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

        public int OrderNo { get; set; }

        public virtual List<OrderDetails> OrderDetails { get; set; }

    }

    public class OrderDetails
    {

        public Guid OrderDetailId { get; set; }

        public Guid fk_OrderId_Id { get; set; }

        [Required]
        public Guid fk_Items_Id { get; set; }

        [Required]
        public int Quantity { get; set; }


        public string CreatedBy { get; set; }

        public DateTime CraetedAt { get; set; }

        public string ModifiedBy { get; set; }

        public DateTime ModifiedAt { get; set; }

    }
}
