using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblOrderDetails
    {
        public Guid PkOrderDetailsId { get; set; }
        public Guid OrderId { get; set; }
        public int Quantity { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid FkItemsId { get; set; }

        public TblItems FkItems { get; set; }
        public TblOrders Order { get; set; }
    }
}
