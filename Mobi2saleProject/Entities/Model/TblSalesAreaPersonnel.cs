using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSalesAreaPersonnel
    {
        public Guid PkSalesAreaPersonnelId { get; set; }
        public Guid FkSalesAreaPersonnelSalesAreasSalesAreaId { get; set; }
        public Guid FkSalesAreaPersonnelSalesmenSalesId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public bool IsSupervisor { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public TblSalesArea FkSalesAreaPersonnelSalesAreasSalesArea { get; set; }
        public TblSalesmen FkSalesAreaPersonnelSalesmenSales { get; set; }
    }
}
