using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TodoEFCore.Models;

namespace TodoEFCore.Models;

public partial class SampleDBContext : DbContext
{
    private readonly IConfiguration _configuration;


    public SampleDBContext(DbContextOptions<SampleDBContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var connectionString = _configuration.GetConnectionString("SampleDB");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        /*
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasOne(d => d.AccountStatusNavigation).WithMany(p => p.Accounts)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasForeignKey(d => d.AccountStatus)
                .HasConstraintName("FK_Accounts_Statuses");
        });
        */

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

}
