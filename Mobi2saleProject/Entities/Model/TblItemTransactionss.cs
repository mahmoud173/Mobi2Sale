using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblItemTransactionss
    {
        public Guid PkItemTransactionId { get; set; }
        public Guid FkItemsStocksItemId { get; set; }
        public Guid VoucherId { get; set; }
        public int SerialNo { get; set; }
        public string TransactionType { get; set; }
        public DateTime TransactionDate { get; set; }
        public int Quantity { get; set; }
        public string From { get; set; }
        public string To { get; set; }

        public TblItems FkItemsStocksItem { get; set; }
    }
}
