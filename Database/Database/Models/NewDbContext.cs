using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Database.Models;

public partial class NewDbContext : DbContext
{
    public NewDbContext(DbContextOptions<NewDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC07872EFD7F");

            entity.ToTable("Department");

            entity.Property(e => e.DeptName).HasMaxLength(100);
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Manager).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
