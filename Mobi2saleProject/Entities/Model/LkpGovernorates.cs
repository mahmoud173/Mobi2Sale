using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class LkpGovernorates
    {
        public LkpGovernorates()
        {
            LkpDistricts = new HashSet<LkpDistricts>();
        }

        public int PkGovernoratesId { get; set; }
        public int CountryId { get; set; }
        public string Name { get; set; }

        public LkpCountries Country { get; set; }
        public ICollection<LkpDistricts> LkpDistricts { get; set; }
    }
}
