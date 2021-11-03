using System.ComponentModel.DataAnnotations;
using System;

namespace api.Models
{
    public class Product
    {
        [Required]
        public int Id {get;set;}

        [Required]
        public string Name {get;set;}

        [Required]
        public string Description {get;set;}

        [Required]
        public float Price {get;set;}

        [Required]
        public int Quantity {get;set;}

        [Required]
        public DateTime AquisitionDate {get;set;}
    }
}
