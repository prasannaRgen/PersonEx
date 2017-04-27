using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PersonEx.Models
{
    public class Person
    {
        public int Id { get; set; }

        [Required]
        [MinLength(4)]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public string ContactNo { get; set; }

        public string Picture { get; set; }
    }
}
