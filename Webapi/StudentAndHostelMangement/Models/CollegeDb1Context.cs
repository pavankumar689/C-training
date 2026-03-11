using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace StudentAndHostelMangement.Models;

public partial class CollegeDb1Context : DbContext
{
    public CollegeDb1Context()
    {
    }

    public CollegeDb1Context(DbContextOptions<CollegeDb1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Hostel> Hostels { get; set; }

    public virtual DbSet<Student> Students { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=PAVAN\\SQLEXPRESS;Initial Catalog=CollegeDB1;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Hostel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Hostels__3214EC07E96F839A");

            entity.HasIndex(e => e.StudentId, "UQ__Hostels__32C52B98F963C7BA").IsUnique();

            entity.HasOne(d => d.Student).WithOne(p => p.Hostel)
                .HasForeignKey<Hostel>(d => d.StudentId)
                .HasConstraintName("FK__Hostels__Student__3C69FB99");
        });

        modelBuilder.Entity<Student>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Students__3214EC07D3D6EECD");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B5C9C8C4");

            entity.Property(e => e.Password).HasMaxLength(200);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
