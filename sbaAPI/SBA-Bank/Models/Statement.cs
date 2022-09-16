using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
// Bhanu -- 16/09/2022 -- Statement table with all props
/// </summary>
namespace SBA_Bank.Models
{
    public class Statement
    {
        [Key]
        public int txnId { get; set; }


        public DateTime Date { get; set; }
        public string description { get; set; }

        public decimal debit { get; set; }

        public decimal credit { get; set; }

        public int AccountId { get; set; }

        [ForeignKey("AccountId")]
        public virtual AccountDetails AccountDetails { get; set; }



    }
}
