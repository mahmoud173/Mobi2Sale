using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblExchangeVoucherDetails
    {
        public Guid PkExchangeVoucherDetailsId { get; set; }
        public Guid FkExchangeVouchersExchangeVoucherDetailsExchangeVouchersId { get; set; }
        public Guid FkItemsExchangeVoucherDetailsItemsId { get; set; }
        public int Quantity { get; set; }
        public string BarCode { get; set; }

        public TblExchangeVouchers FkExchangeVouchersExchangeVoucherDetailsExchangeVouchers { get; set; }
        public TblItems FkItemsExchangeVoucherDetailsItems { get; set; }
    }
}
