using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblItems
    {
        public TblItems()
        {
            TblAdditionVoucherDetails = new HashSet<TblAdditionVoucherDetails>();
            TblBranchStocks = new HashSet<TblBranchStocks>();
            TblExchangeVoucherDetails = new HashSet<TblExchangeVoucherDetails>();
            TblFavorites = new HashSet<TblFavorites>();
            TblIndoorInvoiceDetails = new HashSet<TblIndoorInvoiceDetails>();
            TblItemTransactionss = new HashSet<TblItemTransactionss>();
            TblOrderDetails = new HashSet<TblOrderDetails>();
            TblSalesStock = new HashSet<TblSalesStock>();
            TblStocks = new HashSet<TblStocks>();
        }

        public Guid PkItemsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal SupplyPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal WholesalePrice { get; set; }
        public string Color { get; set; }
        public string Code { get; set; }
        public int Quantity { get; set; }
        public int SafeLimit { get; set; }
        public string MainImageUrl { get; set; }
        public string CoverImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid FkSubCategoriesItemsSubcategoryId { get; set; }
        public Guid FkOffersItemsOfferId { get; set; }
        public int BookedUp { get; set; }
        public int? Available { get; set; }

        public TblOffers FkOffersItemsOffer { get; set; }
        public TblSubCategories FkSubCategoriesItemsSubcategory { get; set; }
        public ICollection<TblAdditionVoucherDetails> TblAdditionVoucherDetails { get; set; }
        public ICollection<TblBranchStocks> TblBranchStocks { get; set; }
        public ICollection<TblExchangeVoucherDetails> TblExchangeVoucherDetails { get; set; }
        public ICollection<TblFavorites> TblFavorites { get; set; }
        public ICollection<TblIndoorInvoiceDetails> TblIndoorInvoiceDetails { get; set; }
        public ICollection<TblItemTransactionss> TblItemTransactionss { get; set; }
        public ICollection<TblOrderDetails> TblOrderDetails { get; set; }
        public ICollection<TblSalesStock> TblSalesStock { get; set; }
        public ICollection<TblStocks> TblStocks { get; set; }
    }
}
