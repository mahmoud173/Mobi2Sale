using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblHandStockValue
    {
        public Guid PkHandStockValueId { get; set; }
        public Guid FkSalesmanHandStockValueSalesId { get; set; }
        public decimal Amount { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public TblSalesmen FkSalesmanHandStockValueSales { get; set; }
    }
}
