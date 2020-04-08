using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class ListItemDto
    {
        public Guid pk_Items_Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool IsInOffer { get; set; }

        public decimal WholesalePrice { get; set; }

        public decimal OfferPctg { get; set; }

        public decimal OfferPrice { get; set; }

        public decimal SupplyPrice { get; set; }

        public string Color { get; set; }

        public string CoverImageUrl { get; set; }

        public int Quantity { get; set; }

        public string InitialQuantity { get; set; }

        public bool IsFavorite { get; set; }

    }
}
