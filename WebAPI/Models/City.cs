using System;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Models
{
    public class City : BaseEnity
    {

        public string Name { get; set; }
        [Required]
        public string Country {get; set;}
    }
}
