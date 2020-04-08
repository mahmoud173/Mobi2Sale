using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblAdditionVouchers
    {
        public TblAdditionVouchers()
        {
            TblAdditionVoucherDetails = new HashSet<TblAdditionVoucherDetails>();
        }

        public Guid PkAdditionVouchersId { get; set; }
        public Guid FkStoresAdditionVoucherStoresId { get; set; }
        public Guid FkEmployeesAdditionVoucherEmployeeId { get; set; }
        public Guid FkSuppliersAdditionVoucherSuppliersId { get; set; }
        public DateTime Date { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string SerialNo { get; set; }

        public TblEmployees FkEmployeesAdditionVoucherEmployee { get; set; }
        public TblSubDepartments FkStoresAdditionVoucherStores { get; set; }
        public TblSuppliers FkSuppliersAdditionVoucherSuppliers { get; set; }
        public ICollection<TblAdditionVoucherDetails> TblAdditionVoucherDetails { get; set; }
    }
}
