using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DapperApi.Models;

public partial class DapperApiContext : DbContext
{
    public DapperApiContext()
    {
    }

    public DapperApiContext(DbContextOptions<DapperApiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DapperApiTable> DapperApiTables { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<DapperApiTable>(entity =>
        {
            entity.HasKey(e => e.EmpId);

            entity.ToTable("DapperApiTable");

            entity.Property(e => e.Address)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(150)
                .IsUnicode(false);
            entity.Property(e => e.EmpName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
