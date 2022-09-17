using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
/// <summary>
// Akshay -- 16/09/2022-- LoginModel  with all props
/// </summary>
namespace SBA_Bank.Models
{
    public class LoginModel
    {
        //Bhanu -- 17/09/2022--custom validation done phonenumber used instead of email.
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
