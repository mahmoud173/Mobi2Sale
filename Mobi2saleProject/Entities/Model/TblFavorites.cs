using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblFavorites
    {
        public Guid PkFavoritesId { get; set; }
        public Guid FkClientId { get; set; }
        public Guid FkItemsId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public TblClient FkClient { get; set; }
        public TblItems FkItems { get; set; }
    }
}
