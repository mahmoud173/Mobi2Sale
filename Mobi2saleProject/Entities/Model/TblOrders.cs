using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblOrders
    {
        public TblOrders()
        {
            TblOrderDetails = new HashSet<TblOrderDetails>();
        }

        public Guid PkOrdersId { get; set; }
        public Guid FkClientsOrdersClientId { get; set; }
        public DateTime OrderDate { get; set; }
        public bool OrderIsOrder { get; set; }
        public decimal TotalCost { get; set; }
        public decimal TotalAmount { get; set; }
        public bool? OnDelivery { get; set; }
        public bool? OrderIsPaid { get; set; }
        public bool? IsCancelled { get; set; }
        public bool? IsDeleted { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int OrderNo { get; set; }
        public string OrderStatus { get; set; }
        public string Notes { get; set; }

        public TblClient FkClientsOrdersClient { get; set; }
        public ICollection<TblOrderDetails> TblOrderDetails { get; set; }
    }
}
