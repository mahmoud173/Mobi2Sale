using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblOffers
    {
        public TblOffers()
        {
            TblItems = new HashSet<TblItems>();
            TblOfferTarget = new HashSet<TblOfferTarget>();
        }

        public Guid PkOffersId { get; set; }
        public string Name { get; set; }
        public decimal OfferPctg { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsActive { get; set; }
        public bool? ReadOnly { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public int Target { get; set; }

        public ICollection<TblItems> TblItems { get; set; }
        public ICollection<TblOfferTarget> TblOfferTarget { get; set; }
    }
}
