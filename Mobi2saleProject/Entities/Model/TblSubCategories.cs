using System;
using System.Collections.Generic;

namespace Entities.Model
{
    public partial class TblSubCategories
    {
        public TblSubCategories()
        {
            TblItems = new HashSet<TblItems>();
        }

        public Guid PkSubCategoriesId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string CreatedBy { get; set; }
        public DateTime CraetedAt { get; set; }
        public bool? IsDeleted { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime ModifiedAt { get; set; }
        public Guid FkCategoriesSubCategoriesCategoryId { get; set; }

        public TblCategories FkCategoriesSubCategoriesCategory { get; set; }
        public ICollection<TblItems> TblItems { get; set; }
    }
}
