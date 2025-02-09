using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TodoEFCore.Models;

public partial class Account
{
    [Key]
    public int AccountId { get; set; }

    [StringLength(50)]
    public string AccountName { get; set; } = null!;

    [StringLength(50)]
    public string? AccountMail { get; set; }

    public int AccountStatus { get; set; }
    
    //[ForeignKey("AccountStatus")]
    //[InverseProperty("Accounts")]
    //public virtual Status AccountStatusNavigation { get; set; } = null!;
    
}
