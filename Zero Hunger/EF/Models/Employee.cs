using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Zero_Hunger.EF.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Name { get; set; }

        [Required]
        [StringLength(11)]
        public string Phone { get; set; }

        public virtual ICollection<CollectDetail> CollectDetails { get; set; }
        public Employee()
        {
            CollectDetails = new List<CollectDetail>();
        }
    }
}