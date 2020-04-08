using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblStocks
    {
        public Guid PkStocksId { get; set; }
        public Guid FkItemsStocksItemId { get; set; }
        public int QtyPerStore { get; set; }
        public Guid StoreId { get; set; }

        public TblItems FkItemsStocksItem { get; set; }
    }
}
