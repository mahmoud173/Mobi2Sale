using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class CategoriesDto
    {

        public Guid pk_Categories_Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageUrl { get; set; }

        public bool IsDeleted { get; set; }

        public virtual List<SubCategory> SubCategories { get; set; }

    }


    public class SubCategory
    {
        public Guid pk_SubCategories_Id { get; set; }

        public string Name { get; set; }
    }
}
