using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class ViewOrderDetailsDto
    {

        public Guid OrderDetailId { get; set; }

        public Guid fk_Items_Id { get; set; }

        public int Quantity { get; set; }

        public string Name { get; set; }

        public string CoverImageUrl { get; set; }

        public decimal WholesalePrice { get; set; }

    }
}
