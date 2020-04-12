using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblClient
    {
        public TblClient()
        {
            TblClientAccounts = new HashSet<TblClientAccounts>();
            TblFavorites = new HashSet<TblFavorites>();
            TblOrders = new HashSet<TblOrders>();
            TblPromoTargets = new HashSet<TblPromoTargets>();
            TblVisit = new HashSet<TblVisit>();
        }

        public Guid PkClientId { get; set; }
        public string IdentityId { get; set; }
        public string Name { get; set; }
        public string ManagerName { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Fax { get; set; }
        public string TaxRecordNumber { get; set; }
        public string TradeRecordNumber { get; set; }
        public string TaxRecordUrl { get; set; }
        public string TradeRecordUrl { get; set; }
        public string Address { get; set; }
        public int FkClientsDistrictsDistrictId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public decimal Limit { get; set; }
        public decimal Target { get; set; }
        public DateTime TargetSatrt { get; set; }
        public DateTime TargetEnd { get; set; }
        public decimal BonusBeforeTime { get; set; }
        public decimal Bonus { get; set; }

        public LkpDistricts FkClientsDistrictsDistrict { get; set; }
       /// public AspNetUsers Identity { get; set; }
        public TblSalesAreaClients TblSalesAreaClients { get; set; }
        public ICollection<TblClientAccounts> TblClientAccounts { get; set; }
        public ICollection<TblFavorites> TblFavorites { get; set; }
        public ICollection<TblOrders> TblOrders { get; set; }
        public ICollection<TblPromoTargets> TblPromoTargets { get; set; }
        public ICollection<TblVisit> TblVisit { get; set; }
    }
}
