using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSupplierAccounts
    {
        public Guid PkSupplierAccountsId { get; set; }
        public Guid FkSuppliersSupplierAccountsSuppliersId { get; set; }
        public Guid TransactionId { get; set; }
        public DateTime Date { get; set; }
        public decimal Debit { get; set; }
        public decimal Credit { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }

        public TblSuppliers FkSuppliersSupplierAccountsSuppliers { get; set; }
    }
}
