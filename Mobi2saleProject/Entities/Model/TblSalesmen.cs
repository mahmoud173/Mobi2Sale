using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSalesmen
    {
        public TblSalesmen()
        {
            TblHandStockValue = new HashSet<TblHandStockValue>();
            TblSalesStock = new HashSet<TblSalesStock>();
            TblVisit = new HashSet<TblVisit>();
        }

        public Guid PkSalesmanId { get; set; }
        public decimal Limit { get; set; }
        public decimal Target { get; set; }
        public DateTime TargetSatrt { get; set; }
        public DateTime TargetEnd { get; set; }
        public Guid FkSalesmenEmployeeId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public decimal BonusBeforeTime { get; set; }
        public decimal Bonus { get; set; }

        public TblEmployees FkSalesmenEmployee { get; set; }
        public TblSalesAreaPersonnel TblSalesAreaPersonnel { get; set; }
        public ICollection<TblHandStockValue> TblHandStockValue { get; set; }
        public ICollection<TblSalesStock> TblSalesStock { get; set; }
        public ICollection<TblVisit> TblVisit { get; set; }
    }
}
