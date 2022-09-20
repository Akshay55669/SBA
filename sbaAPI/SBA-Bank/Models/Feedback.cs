using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_Bank.Models
{
    //Akshay---20/09/2022----Feedback Model created
    public class Feedback
    {

        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Opinions { get; set; }
    }
}
