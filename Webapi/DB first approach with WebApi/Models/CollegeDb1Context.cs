using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DB_first_approach_with_WebApi.Models;

public partial class CollegeDb1Context : DbContext
{
    public CollegeDb1Context()
    {
    }

    public CollegeDb1Context(DbContextOptions<CollegeDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        // Connection string is now configured in Program.cs using dependency injection
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07C8B0B014");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
