using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace Zero_Hunger.EF.Models
{
    public class NGO
    {
        public int Id { get; set; }

        [Required]
        [StringLength(20)]
        public string Username { get; set; }

        [Required]
        [StringLength(20)]
        public string Password { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public NGO()
        {
            Employees = new List<Employee>();
        }
    }
}