using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SBA_Bank.Models
{
    public class AccountInfo
    {
        [Key]
        public long AccountId { get; set; }

        public string Branch { get; set; }

        public int Balance { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual UserProfile UserProfile { get; set; }


    }
}
