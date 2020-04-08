using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSalesArea
    {
        public TblSalesArea()
        {
            TblSalesAreaClients = new HashSet<TblSalesAreaClients>();
            TblSalesAreaPersonnel = new HashSet<TblSalesAreaPersonnel>();
        }

        public Guid PkSalesAreaId { get; set; }
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ICollection<TblSalesAreaClients> TblSalesAreaClients { get; set; }
        public ICollection<TblSalesAreaPersonnel> TblSalesAreaPersonnel { get; set; }
    }
}
