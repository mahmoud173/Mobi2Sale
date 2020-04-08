using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class OffersDto
    {
        public Guid pk_Offers_Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public decimal OfferPctg { get; set; }

        public string ImageUrl { get; set; }

        public bool IsActive { get; set; }

        public bool ReadOnly { get; set; }

        public int Target { get; set; }
    }
}
