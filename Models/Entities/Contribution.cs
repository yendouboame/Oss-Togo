using SolidarityFund.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Models.Entities
{
    [Table("COTISATIONS")]
    public class Contribution : BaseModel
    {
        public int PriestId { get; set; }
        [Display(Name = "Nom et prénom(s) du prêtre")]
        public virtual Priest Priest { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        [Display(Name = "Montant de la cotisation")]
        public decimal Amount { get; set; }

        [Display(Name = "Période de cotisation")]
        public DateTime Date => new DateTime(Year, Month, 1);
    }
}
