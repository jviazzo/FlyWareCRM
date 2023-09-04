using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using SystemEmail.Model;

namespace SystemEmail.DAL.DBContext;

public partial class DbemailContext : DbContext
{
    public DbemailContext()
    {
    }

    public DbemailContext(DbContextOptions<DbemailContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DetailEmail> DetailEmails { get; set; }

    public virtual DbSet<Email> Emails { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<MenuRol> MenuRols { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<SpecialId> SpecialIds { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdCategory).HasName("PK__Category__79D361B6088273EB");

            entity.ToTable("Category");

            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.DateLog)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateLog");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.IdClient).HasName("PK__Client__A6A610D4517B0F24");

            entity.ToTable("Client");

            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.Company)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company");
            entity.Property(e => e.DateLog)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateLog");
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.IdCategory).HasColumnName("idCategory");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.Language)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("language");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.IdCategoryNavigation).WithMany(p => p.Clients)
                .HasForeignKey(d => d.IdCategory)
                .HasConstraintName("FK__Client__idCatego__35BCFE0A");
        });

        modelBuilder.Entity<DetailEmail>(entity =>
        {
            entity.HasKey(e => e.IdDetailEmail).HasName("PK__DetailEm__2DEFDC3F8CF17B3B");

            entity.ToTable("DetailEmail");

            entity.Property(e => e.IdDetailEmail).HasColumnName("idDetailEmail");
            entity.Property(e => e.IdClient).HasColumnName("idClient");
            entity.Property(e => e.IdEmail).HasColumnName("idEmail");

            entity.HasOne(d => d.IdClientNavigation).WithMany(p => p.DetailEmails)
                .HasForeignKey(d => d.IdClient)
                .HasConstraintName("FK__DetailEma__idCli__412EB0B6");

            entity.HasOne(d => d.IdEmailNavigation).WithMany(p => p.DetailEmails)
                .HasForeignKey(d => d.IdEmail)
                .HasConstraintName("FK__DetailEma__idEma__403A8C7D");
        });

        modelBuilder.Entity<Email>(entity =>
        {
            entity.HasKey(e => e.IdEmail).HasName("PK__Email__DF53771015086DA1");

            entity.ToTable("Email");

            entity.Property(e => e.IdEmail).HasColumnName("idEmail");
            entity.Property(e => e.DateLog)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateLog");
            entity.Property(e => e.EmailType)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("emailType");
            entity.Property(e => e.SpecialId)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("specialID");
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.IdMenu).HasName("PK__Menu__C26AF48366AAF4E3");

            entity.ToTable("Menu");

            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.Icon)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("icon");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Url)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("url");
        });

        modelBuilder.Entity<MenuRol>(entity =>
        {
            entity.HasKey(e => e.IdMenulRol).HasName("PK__MenuRol__D5FB5B8B1ED85587");

            entity.ToTable("MenuRol");

            entity.Property(e => e.IdMenulRol).HasColumnName("idMenulRol");
            entity.Property(e => e.IdMenu).HasColumnName("idMenu");
            entity.Property(e => e.IdRol).HasColumnName("idRol");

            entity.HasOne(d => d.IdMenuNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdMenu)
                .HasConstraintName("FK__MenuRol__idMenu__29572725");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.MenuRols)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__MenuRol__idRol__2A4B4B5E");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__Rol__3C872F76EE8B15DB");

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.DateLog)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateLog");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        modelBuilder.Entity<SpecialId>(entity =>
        {
            entity.HasKey(e => e.SpecialId1).HasName("PK__specialI__F2930CD4AA9E0978");

            entity.ToTable("specialId");

            entity.Property(e => e.SpecialId1).HasColumnName("specialId");
            entity.Property(e => e.DateLog)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateLog");
            entity.Property(e => e.LastSpecialId).HasColumnName("lastSpecialId");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.IdUser).HasName("PK__Users__3717C98293FD2E3D");

            entity.Property(e => e.IdUser).HasColumnName("idUser");
            entity.Property(e => e.DateLog)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("dateLog");
            entity.Property(e => e.Email)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("fullName");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IsActive)
                .HasDefaultValueSql("((1))")
                .HasColumnName("isActive");
            entity.Property(e => e.Password)
                .HasMaxLength(40)
                .IsUnicode(false)
                .HasColumnName("password");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__Users__idRol__2D27B809");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
