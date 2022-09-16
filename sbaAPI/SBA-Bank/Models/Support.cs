using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
// Akshay -- 16/09/2022-- Support table with all props
/// </summary>
namespace SBA_Bank.Models
{
    public class Support
    {
        [Key]
        public int supportId { get; set; }

        public string Questions { get; set; }
        public string Answers { get; set; }


    }
}
