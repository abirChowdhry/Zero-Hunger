using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.EF.Models
{
    public class CollectDetail
    {
        public int Id { get; set; }

        [Required]
        public string RestaurantName { get; set; }

        [Required]
        public string Item { get; set; }

        [Required]
        public string Quantity { get; set; }

        [Required]
        public string Preservation_time { get; set; }

        [Required]
        public string EmployeeName { get; set; }
    }
}