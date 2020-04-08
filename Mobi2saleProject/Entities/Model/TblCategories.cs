using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblCategories
    {
        public TblCategories()
        {
            TblSubCategories = new HashSet<TblSubCategories>();
        }

        public Guid PkCategoriesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }

        public ICollection<TblSubCategories> TblSubCategories { get; set; }
    }
}
