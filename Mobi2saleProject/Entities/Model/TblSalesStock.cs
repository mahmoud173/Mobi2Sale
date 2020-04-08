using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSalesStock
    {
        public Guid PkSalesStockId { get; set; }
        public Guid FkItemsSalesStockItemsId { get; set; }
        public Guid FkSalesmanSalesStockSalesId { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }
        public bool IsMobile { get; set; }
        public bool Isclient { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public Guid FkExchangeVouchersSalesStockExchangeVoucherId { get; set; }

        public TblItems FkItemsSalesStockItems { get; set; }
        public TblSalesmen FkSalesmanSalesStockSales { get; set; }
    }
}
