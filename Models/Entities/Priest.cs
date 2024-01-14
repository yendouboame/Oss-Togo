using SolidarityFund.Models.Commons;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static SolidarityFund.Helpers.Constants.Enumerations;

namespace SolidarityFund.Models.Entities
{
    [Table("PRETRES")]
    public class Priest : BaseModel
    {
        [Display(Name = "Nom et prénom(s)")]
        public string FullName { get; set; }

        [Display(Name = "Date de naissance")]
        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Âge")]
        public int Age { get { return CalculateAge(DateOfBirth); } }

        [Display(Name = "Date d'ordination")]
        [Column(TypeName = "date")]
        public DateTime OrdinationDate { get; set; }

        [Display(Name = "Prêtre incardiné")]
        public bool IsIncardinated { get; set; } = false;

        public SuspensionReason? SuspensionReason { get; set; }

        [Display(Name = "Date d'arrêt")]
        [Column(TypeName = "date")]
        public DateTime? SuspensionDate { get; set; }

        public int DioceseId { get; set; }
        [Display(Name = "Diocèse")]
        public virtual Diocese Diocese { get; set; }

        [Display(Name = "Dernier paiement de l'allocation")]
        public DateTime? LastPensionPaymentDate { get; set; }

        public virtual ICollection<Contribution> Contributions { get; set; }
        public virtual ICollection<Pension> Pensions { get; set; }


        private int CalculateAge(DateTime birthDate)
        {
            int age = DateTime.Now.Year - birthDate.Year;

            if (DateTime.Now < birthDate.AddYears(age))
            {
                age--;
            }

            return age;
        }
    }
}
