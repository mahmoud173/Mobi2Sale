using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class LkpDistricts
    {
        public LkpDistricts()
        {
            TblClient = new HashSet<TblClient>();
            TblEmployees = new HashSet<TblEmployees>();
        }

        public int PkDistrictsId { get; set; }
        public int GovernorateId { get; set; }
        public string Name { get; set; }

        public LkpGovernorates Governorate { get; set; }
        public ICollection<TblClient> TblClient { get; set; }
        public ICollection<TblEmployees> TblEmployees { get; set; }
    }
}
