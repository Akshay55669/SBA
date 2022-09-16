using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
// Akshay -- 16/09/2022-- AccountDetails table with all props
/// </summary>
namespace SBA_Bank.Models
{
    public class AccountDetails
    {
        [Key]
        public int AccountId { get; set; }

        public long BankBranch { get; set; }

        public decimal Balance { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public UserProfile User { get; set; }
    }    
}
