using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblIndoorInvoiceDetails
    {
        public Guid PkIndoorInvoiceDetailsId { get; set; }
        public Guid FkIndoorInvoiceHeaderIndoorInvoiceDetailsHeaderId { get; set; }
        public Guid FkItemsAdditionVoucherDetailsItemsId { get; set; }
        public int Quantity { get; set; }
        public string Barcode { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal CostPrice { get; set; }

        public TblIndoorInvoiceHeader FkIndoorInvoiceHeaderIndoorInvoiceDetailsHeader { get; set; }
        public TblItems FkItemsAdditionVoucherDetailsItems { get; set; }
    }
}
