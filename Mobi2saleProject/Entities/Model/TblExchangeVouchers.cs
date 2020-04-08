using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblExchangeVouchers
    {
        public TblExchangeVouchers()
        {
            TblExchangeVoucherDetails = new HashSet<TblExchangeVoucherDetails>();
        }

        public Guid PkExchangeVouchersId { get; set; }
        public int SerialNo { get; set; }
        public Guid FkStoresExchangeVoucherFromStoresId { get; set; }
        public Guid FkToStoresId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsBranch { get; set; }

        public TblSubDepartments FkStoresExchangeVoucherFromStores { get; set; }
        public ICollection<TblExchangeVoucherDetails> TblExchangeVoucherDetails { get; set; }
    }
}
