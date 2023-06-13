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

        [Display(Name = "Date de cotisation")]
        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        [Display(Name = "Montant de la cotisation")]
        public double Ammount { get; set; }
    }
}
