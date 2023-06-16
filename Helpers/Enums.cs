using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Helpers
{
    public class Enums
    {
        public enum PriestAgeInterval { LessThanSeventy, Seventy, MoreThanSeventy }

        public enum GroupBy { Priest, Diocese }

        public enum Roles { SuperAdmin, Manager }
    }
}
