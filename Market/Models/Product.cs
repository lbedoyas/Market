using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Product
    {
        [Key]


        public int ProductID { get; set; }

        
        [Display(Name = "Descripcion")]
        [Required(ErrorMessage ="Por favor ingresar el campo {0}")]
        public string Description { get; set; }

        [Display(Name = "Precio")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}" , ApplyFormatInEditMode = false)]
        [Required(ErrorMessage ="Por favor ingresar el valor en el campo {0}")]
        public decimal Price { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString ="{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [Required]
        [Display(Name ="Ultima Compra")]
        public DateTime LastBuy { get; set; }

        // Ayuda para poner decimales en los campos
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}" ,ApplyFormatInEditMode = false)]
        public float Stock { get; set; }

        [Display(Name = "Observaciones")]
        [DataType(DataType.MultilineText)]
        public string Remarks { get; set; }

        public virtual ICollection<SupplierProduct> SupplierProducts  { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}