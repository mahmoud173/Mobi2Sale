using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class ItemDetailsDto
    {
        public Guid pk_Items_Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal SupplyPrice { get; set; }

        public bool IsInOffer { get; set; }

        public decimal RetailPrice { get; set; }

        public decimal WholesalePrice { get; set; }

        public decimal OfferPctg { get; set; }

        public decimal OfferPrice { get; set; }

        public string Color { get; set; }

        public string Code { get; set; }

        public int Quantity { get; set; }

        public int SafeLimit { get; set; }

        public string MainImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public Guid fk_subCategories_Items_SubcategoryId { get; set; }

        public string InitialQuantity { get; set; }
    }
}
