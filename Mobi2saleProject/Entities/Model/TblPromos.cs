using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblPromos
    {
        public TblPromos()
        {
            TblPromoTargets = new HashSet<TblPromoTargets>();
        }

        public Guid PkPromosId { get; set; }
        public string Name { get; set; }
        public decimal OfferPctg { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsActive { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? AllClients { get; set; }

        public ICollection<TblPromoTargets> TblPromoTargets { get; set; }
    }
}
