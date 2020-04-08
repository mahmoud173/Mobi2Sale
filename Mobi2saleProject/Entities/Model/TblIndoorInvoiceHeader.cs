using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblIndoorInvoiceHeader
    {
        public TblIndoorInvoiceHeader()
        {
            TblIndoorInvoiceDetails = new HashSet<TblIndoorInvoiceDetails>();
        }

        public Guid Id { get; set; }
        public Guid FkBranchesIndoorSalesInvoiceBranchId { get; set; }
        public Guid FkEmployeesIndoorSalesInvoiceEmployeeId { get; set; }
        public string SerialNo { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public decimal TotalPrice { get; set; }
        public decimal CostPrice { get; set; }

        public TblBranches FkBranchesIndoorSalesInvoiceBranch { get; set; }
        public TblEmployees FkEmployeesIndoorSalesInvoiceEmployee { get; set; }
        public ICollection<TblIndoorInvoiceDetails> TblIndoorInvoiceDetails { get; set; }
    }
}
