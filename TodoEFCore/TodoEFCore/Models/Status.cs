using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace TodoEFCore.Models;

public partial class Status
{
    [Key]
    public int StatusId { get; set; }

    [StringLength(50)]
    public string? StatusName { get; set; }

    //[InverseProperty("AccountStatusNavigation")]
    //public virtual ICollection<Account> Accounts { get; set; } = new List<Account>();
}
