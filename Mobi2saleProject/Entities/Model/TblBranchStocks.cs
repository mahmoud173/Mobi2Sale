using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblBranchStocks
    {
        public Guid PkBranchStockId { get; set; }
        public Guid FkBranchBranchStockBranchId { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }
        public bool IsMobile { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public TblBranches FkBranchBranchStockBranch { get; set; }
        public TblItems FkBranchBranchStockBranchNavigation { get; set; }
    }
}
