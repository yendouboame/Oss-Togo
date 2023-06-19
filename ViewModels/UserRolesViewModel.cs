using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.ViewModels
{
    public class UserRolesViewModel
    {
        public string UserId { get; set; }
        public string UserFullName { get; set; }
        public List<CheckBoxViewModel> Roles { get; set; }
    }
}
