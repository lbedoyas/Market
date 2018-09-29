using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Models
{
    public class Product
    {
        [Key]


        public int ProductID { get; set; }

        [Required]
        [Display(Name = "Descripcion")]
        public string Description { get; set; }

        [Required]
        public decimal Price { get; set; }


        public DateTime LastBuy { get; set; }


        public float Stock { get; set; }


        public string Remarks { get; set; }
    }
}