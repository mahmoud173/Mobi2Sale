using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class LkpCountries
    {
        public LkpCountries()
        {
            LkpGovernorates = new HashSet<LkpGovernorates>();
            TblSuppliers = new HashSet<TblSuppliers>();
        }

        public int PkCountriesId { get; set; }
        public string Name { get; set; }

        public ICollection<LkpGovernorates> LkpGovernorates { get; set; }
        public ICollection<TblSuppliers> TblSuppliers { get; set; }
    }
}
