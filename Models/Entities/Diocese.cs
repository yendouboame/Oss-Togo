using SolidarityFund.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Models.Entities
{
    [Table("DIOCESES")]
    public class Diocese : BaseModel
    {
        [Display(Name = "Nom du diocèse")]
        public string Name { get; set; }

        [Display(Name = "Nombre de prêtres")]
        public int NumberOfPriests { get { return Priests.Count; } }

        public virtual ICollection<Priest> Priests { get; set; }
    }
}
