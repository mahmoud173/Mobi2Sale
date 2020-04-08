using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Mobi2saleProject.Dtos
{
    public class ClientEditProfileDto
    {

        public string Name { get; set; }

        [RegularExpression(@"^\+965[569]\d{7}$", ErrorMessage = "Invalid Mobile1 Number !!")]
        public string Mobile1 { get; set; }

        [RegularExpression(@"^\+965[569]\d{7}$", ErrorMessage = "Invalid Mobile1 Number !!")]
        public string Mobile2 { get; set; }

        public string Phone { get; set; }

        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "E-mail is not valid")]
        public string Email { get; set; }

        public string Fax { get; set; }

        public string ManagerName { get; set; }

    }
}
