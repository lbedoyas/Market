using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Market.Models
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }

        [Display(Name = "Nombre Proveedor")]
        [Required(ErrorMessage ="Por favor ingresar el campo de {0}")]
        public string name { get; set; }
        
        [Display(Name ="Contacto Nombre")]
        public string ContactFirstName { get; set; }

        [Display(Name = "Contacto Apellido")]
        public string ContactLastName { get; set; }

        [Display(Name = "Telefono")]
        [DataType(DataType.PhoneNumber)]
        public string  Phone { get; set; }

        [Display(Name ="Direccion")]
        public string Address { get; set; }

        [Display(Name = "E-Mail")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public virtual ICollection<SupplierProduct> supplierProducts { get; set; }

    }
}