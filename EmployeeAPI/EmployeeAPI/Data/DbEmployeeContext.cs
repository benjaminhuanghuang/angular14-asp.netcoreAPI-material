using System;
using System.Collections.Generic;
using EmployeeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAPI.Data;

public partial class DbEmployeeContext : DbContext
{
    public DbEmployeeContext()
    {
    }

    public DbEmployeeContext(DbContextOptions<DbEmployeeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Departme__3214EC0779565B37");

            entity.ToTable("Department");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC070BD7D45D");

            entity.ToTable("Employee");

            entity.Property(e => e.FullName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HireDate).HasColumnType("datetime");
            entity.Property(e => e.Salary).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdDepartmentNavigation).WithMany(p => p.Employees)
                .HasForeignKey(d => d.IdDepartment)
                .HasConstraintName("FK__Employee__IdDepa__38996AB5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
