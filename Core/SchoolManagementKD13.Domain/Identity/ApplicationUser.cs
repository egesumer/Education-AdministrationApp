using Microsoft.AspNetCore.Identity;
using SchoolManagementKD13.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManagementKD13.Domain.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ApplicationUserRole ApplicationUserRole { get; set; }
    }
}
