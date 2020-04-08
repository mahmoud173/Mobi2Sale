using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSuppliers
    {
        public TblSuppliers()
        {
            TblAdditionVouchers = new HashSet<TblAdditionVouchers>();
            TblSupplierAccounts = new HashSet<TblSupplierAccounts>();
        }

        public Guid PkSuppliersId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public string TaxRecordNumber { get; set; }
        public string TradeRecordNumber { get; set; }
        public string TaxRecordUrl { get; set; }
        public string TradeRecordUrl { get; set; }
        public int FkCountrySupplierCountryId { get; set; }
        public string Address { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public LkpCountries FkCountrySupplierCountry { get; set; }
        public ICollection<TblAdditionVouchers> TblAdditionVouchers { get; set; }
        public ICollection<TblSupplierAccounts> TblSupplierAccounts { get; set; }
    }
}
