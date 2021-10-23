using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebAppECommerce.Models
{
    public class User

    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string Email { get; set; }
        [StringLength(100)]
        public string Password { get; set; }
        public DateTime? CreatDat { get; set; } = DateTime.Now;
    }
}
