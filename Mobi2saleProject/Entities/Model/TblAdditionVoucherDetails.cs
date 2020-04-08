using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblAdditionVoucherDetails
    {
        public Guid PkAdditionVoucherDetailsId { get; set; }
        public Guid FkAdditionVouchersAdditionVoucherDetailsAdditionVouchersId { get; set; }
        public Guid FkItemsAdditionVoucherDetailsItemsId { get; set; }
        public int Quantity { get; set; }

        public TblAdditionVouchers FkAdditionVouchersAdditionVoucherDetailsAdditionVouchers { get; set; }
        public TblItems FkItemsAdditionVoucherDetailsItems { get; set; }
    }
}
