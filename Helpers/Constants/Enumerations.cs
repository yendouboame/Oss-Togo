using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Helpers.Constants
{
    public class Enumerations
    {
        public enum PriestAgeInterval { LessThanSeventy, Seventy, MoreThanSeventy }

        public enum GroupBy { Priest, Diocese }

        public enum Roles { SuperAdmin, Admin, Manager, Basic }

        public enum Modules { Settings, Users, Roles, Dioceses, Priests, Contributions, Pensions, Reports }
    }
}
