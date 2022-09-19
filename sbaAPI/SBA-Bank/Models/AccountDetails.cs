using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_Bank.Models
{
    public class AccountDetails
    {
        [Key]
        public long AccountNo { get; set; }

        public string BankBranch { get; set; }

        public decimal Balance { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public UserProfile User { get; set; }
    }
}
