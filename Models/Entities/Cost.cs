using SolidarityFund.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Models.Entities
{
    [Table("FRAIS")]
    public class Cost : BaseModel
    {
        [Display(Name = "Frais d'allocation")]
        public double Pension { get; set; }
        [Display(Name = "Frais de cotisation")]
        public double Contribution { get; set; }
    }
}
