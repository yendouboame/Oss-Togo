using SolidarityFund.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Models.Entities
{
    [Table("ALLOCATIONS")]
    public class Pension : BaseModel
    {
        public int PriestId { get; set; }
        [Display(Name = "Nom et prénom(s) du prêtre")]
        public virtual Priest Priest { get; set; }
        public int Month { get; set; }
        public int Year { get; set; }

        [Display(Name = "Montant de l'allocation")]
        public decimal Amount { get; set; }

        [Display(Name = "Période du paiement de l'allocation")]
        public DateTime Date => new DateTime(Year, Month, 1);
    }
}
