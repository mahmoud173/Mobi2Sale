using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblBranches
    {
        public TblBranches()
        {
            TblBranchStocks = new HashSet<TblBranchStocks>();
            TblIndoorInvoiceHeader = new HashSet<TblIndoorInvoiceHeader>();
        }

        public Guid PkBranchesId { get; set; }
        public string Name { get; set; }
        public Guid FkSalesmenBranchesMgrId { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ICollection<TblBranchStocks> TblBranchStocks { get; set; }
        public ICollection<TblIndoorInvoiceHeader> TblIndoorInvoiceHeader { get; set; }
    }
}
