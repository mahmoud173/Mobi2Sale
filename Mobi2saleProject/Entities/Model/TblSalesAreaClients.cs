using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSalesAreaClients
    {
        public Guid PkSalesAreaClientId { get; set; }
        public Guid FkSalesAreaClientsSalesAreasSalesAreaId { get; set; }
        public Guid FkSalesAreaClientsClientsClientId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public TblClient FkSalesAreaClientsClientsClient { get; set; }
        public TblSalesArea FkSalesAreaClientsSalesAreasSalesArea { get; set; }
    }
}
