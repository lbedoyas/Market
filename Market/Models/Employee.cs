using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class Employee
    {
        [Key]

        public int EmployeeID { get; set; }

        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "Ingrese por favor el {0}")]
        [StringLength(30 , ErrorMessage = "El campo {0} Debe tener mas de {1} y menos de {2} Caracteres", MinimumLength = 3)]
        public string FirstName { get; set; }

        [Display(Name = "Apellido")]
        [Required(ErrorMessage = "Ingrese por favor el {0}")]
        [StringLength(30, ErrorMessage = "El campo {0} Debe tener mas de {1} y menos de {2} Caracteres", MinimumLength = 3)]
        public string LastName { get; set; }

        [Display(Name = "Salario")]
        [Required(ErrorMessage = "Ingrese por favor el {0}")]
        [DisplayFormat(DataFormatString = "{0:C2}" , ApplyFormatInEditMode = false)] 
        public decimal Salary { get; set; }

        [Display(Name = "Bonus %")]
        [DisplayFormat(DataFormatString = "{0:P2}", ApplyFormatInEditMode = false)]
        public float BonusPercent { get; set; }

        [Display(Name = "Fecha de Nacimiento")]
        [Required(ErrorMessage = "Ingrese por favor la {0}")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Display(Name = "Hora de Entrada")]
        [DisplayFormat(DataFormatString = "{0:hh:mm}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }

        [Required(ErrorMessage = "Ingrese por favor el {0}")]
        [DataType(DataType.EmailAddress)]
        public string EMail { get; set; }

        [DataType(DataType.Url)]
        public string URL { get; set; }

        [Required(ErrorMessage = "Ingrese por favor el {0}")]
        public int DocumentTypeID { get; set; }

        public virtual DocumentType DocumentType { get; set; }

    }
}