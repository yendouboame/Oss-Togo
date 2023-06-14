using SolidarityFund.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SolidarityFund.Models.Entities
{
    [Table("PRETRES")]
    public class Priest : BaseModel
    {
        [Display(Name = "Photo")]
        public byte[]? Picture { get; set; }

        [Display(Name = "Prénom(s)")]
        public string FirstName { get; set; }

        [Display(Name = "Nom")]
        public string LastName { get; set; }

        [Display(Name = "Date de naissance")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Date d'ordination")]
        [Column(TypeName = "date")]
        public DateTime OrdinationDate { get; set; }

        [Display(Name = "Nom et prénom(s)")]
        public string FullName { get { return $"{LastName} {FirstName}"; } }

        public int DioceseId { get; set; }
        [Display(Name = "Diocèse")]
        public virtual Diocese Diocese { get; set; }

        public virtual ICollection<Contribution> Contributions { get; set; }
    }
}
