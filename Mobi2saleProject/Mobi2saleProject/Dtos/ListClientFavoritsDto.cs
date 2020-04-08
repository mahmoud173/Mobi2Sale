using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class ListClientFavoritsDto
    {
        public Guid pk_Favorites_Id { get; set; }

        public Guid ClientId { get; set; }

        public Guid pk_Items_Id { get; set; }

        public string Description { get; set; }

        public string Name { get; set; }

        public decimal WholesalePrice { get; set; }

        public string Color { get; set; }

        public string CoverImageUrl { get; set; }

        public bool IsFavorite { get; set; }

        public string InitialQuantity { get; set; }

        public decimal SupplyPrice { get; set; }

        public string MainImageUrl { get; set; }



    }
}
