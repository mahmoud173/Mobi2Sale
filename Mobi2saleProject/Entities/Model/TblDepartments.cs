using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblDepartments
    {
        public TblDepartments()
        {
            TblEmployees = new HashSet<TblEmployees>();
            TblSubDepartments = new HashSet<TblSubDepartments>();
        }

        public Guid PkDepartmentsId { get; set; }
        public string Name { get; set; }
        public Guid FkEmployeesDepartmentsMgrId { get; set; }
        public string Description { get; set; }
        public string Phone { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ICollection<TblEmployees> TblEmployees { get; set; }
        public ICollection<TblSubDepartments> TblSubDepartments { get; set; }
    }
}
