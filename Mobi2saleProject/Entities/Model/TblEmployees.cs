using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblEmployees
    {
        public TblEmployees()
        {
            TblAdditionVouchers = new HashSet<TblAdditionVouchers>();
            TblIndoorInvoiceHeader = new HashSet<TblIndoorInvoiceHeader>();
        }

        public Guid PkEmployeesId { get; set; }
        public string IdentityId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBrith { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string VisaNumber { get; set; }
        public string VisaImage { get; set; }
        public int FkDistrictEmployeesDistrictId { get; set; }
        public string Street { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid DepartmentId { get; set; }
        public Guid? SubDepartmentId { get; set; }

        public TblDepartments Department { get; set; }
        public LkpDistricts FkDistrictEmployeesDistrict { get; set; }
        public TblSubDepartments SubDepartment { get; set; }
        public TblSalesmen TblSalesmen { get; set; }
        public ICollection<TblAdditionVouchers> TblAdditionVouchers { get; set; }
        public ICollection<TblIndoorInvoiceHeader> TblIndoorInvoiceHeader { get; set; }
    }
}
