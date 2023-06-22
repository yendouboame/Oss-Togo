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

        [Display(Name = "Date de l'allocation")]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Display(Name = "Montant de l'allocation")]
        public double Amount { get; set; }
    }
}
