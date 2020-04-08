using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class FavoritsDto
    {
        public Guid pk_Favorites_Id { get; set; }


        public Guid ClientId { get; set; }

        [Required]
        public Guid ItemID { get; set; }
    }
}
