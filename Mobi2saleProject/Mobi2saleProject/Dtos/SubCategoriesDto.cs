using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class SubCategoriesDto
    {
        public Guid pk_Subcategories_Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public Guid fk_Categories_subCategories_CategoryId { get; set; }
    }
}
