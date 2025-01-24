using System;
using System.Collections.Generic;

namespace Bankcard.Models
{
    public partial class UserAccount
    {
        public int UserId { get; set; }
        public string Account { get; set; }
        public string Password { get; set; }
    }
}
