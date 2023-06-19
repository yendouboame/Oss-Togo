using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Models.Entities
{
    public class User : IdentityUser
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public bool IsActive { get; set; }

        public string FullName { get { return $"{LastName} {FirstName}"; } }
    }
}
