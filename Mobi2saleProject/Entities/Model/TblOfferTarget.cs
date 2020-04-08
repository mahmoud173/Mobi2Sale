using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblOfferTarget
    {
        public Guid PkOfferTargetId { get; set; }
        public Guid FkOfferOfferTargetOffreId { get; set; }
        public Guid TargetId { get; set; }

        public TblOffers FkOfferOfferTargetOffre { get; set; }
    }
}
