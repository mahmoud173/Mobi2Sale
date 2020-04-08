using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblPromoTargets
    {
        public Guid PkPromoTargetsId { get; set; }
        public Guid FkPromosPromoTargetsPromoId { get; set; }
        public Guid ClientId { get; set; }

        public TblClient Client { get; set; }
        public TblPromos FkPromosPromoTargetsPromo { get; set; }
    }
}
