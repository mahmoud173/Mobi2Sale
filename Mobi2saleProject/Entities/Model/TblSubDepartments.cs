using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSubDepartments
    {
        public TblSubDepartments()
        {
            TblAdditionVouchers = new HashSet<TblAdditionVouchers>();
            TblEmployees = new HashSet<TblEmployees>();
            TblExchangeVouchers = new HashSet<TblExchangeVouchers>();
        }

        public Guid PkSubDepartmentsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Guid FkDepartmentsSubDepartmentsDepartmentId { get; set; }
        public string Phone { get; set; }
        public Guid FkEmployeesSubDepartmentsManagerId { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsStore { get; set; }

        public TblDepartments FkDepartmentsSubDepartmentsDepartment { get; set; }
        public ICollection<TblAdditionVouchers> TblAdditionVouchers { get; set; }
        public ICollection<TblEmployees> TblEmployees { get; set; }
        public ICollection<TblExchangeVouchers> TblExchangeVouchers { get; set; }
    }
}
