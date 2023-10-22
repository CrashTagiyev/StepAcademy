using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using STepAcademyDB.Models;

namespace STepAcademyDB.Context;

public partial class StepAcademyContext : DbContext
{
    public StepAcademyContext()
    {
    }

    public StepAcademyContext(DbContextOptions<StepAcademyContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<Teacher> Teachers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-HFMQLBA\\MSSQLSERVER01;Initial Catalog=StepAcademy;Integrated Security=True;Connect Timeout=30;Encrypt=False;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Group>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Groups__3214EC078EC65C9A");

            entity.Property(e => e.GroupName)
                .HasMaxLength(100)
                .HasColumnName("Group Name");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Student__3214EC07F2F1D201");

            entity.ToTable("Student");

            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .HasColumnName("firstname");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.Lastname).HasMaxLength(20);

            entity.HasOne(d => d.Group).WithMany(p => p.Students)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__Student__Group_I__3C69FB99")
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Teacher>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Teachers__3214EC0772D25C04");

            entity.Property(e => e.Firstname)
                .HasMaxLength(20)
                .HasColumnName("firstname");
            entity.Property(e => e.GroupId).HasColumnName("Group_Id");
            entity.Property(e => e.Lastname).HasMaxLength(20);

            entity.HasOne(d => d.Group).WithMany(p => p.Teachers)
                .HasForeignKey(d => d.GroupId)
                .HasConstraintName("FK__Teachers__Group___398D8EEE")
                .OnDelete(DeleteBehavior.Cascade);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
