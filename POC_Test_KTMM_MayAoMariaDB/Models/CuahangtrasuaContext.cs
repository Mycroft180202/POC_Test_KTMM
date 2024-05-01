using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace POC_Test_KTMM_MayAoMariaDB.Models;

public partial class CuahangtrasuaContext : DbContext
{
    public CuahangtrasuaContext()
    {
    }

    public CuahangtrasuaContext(DbContextOptions<CuahangtrasuaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Orderdetail> Orderdetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productimage> Productimages { get; set; }

    public virtual DbSet<Productuser> Productusers { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Securityquestion> Securityquestions { get; set; }

    public virtual DbSet<Sysdiagram> Sysdiagrams { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Userrole> Userroles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=192.168.116.129;port=3306;database=cuahangtrasua;user=root;password=Abc@1234", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.11.4-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_general_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PRIMARY");

            entity.ToTable("categories");

            entity.Property(e => e.CategoryId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
            entity.Property(e => e.Description).HasMaxLength(500);
        });

        modelBuilder.Entity<Orderdetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PRIMARY");

            entity.ToTable("orderdetails");

            entity.HasIndex(e => e.UserId, "FK_OrderDetails_Users");

            entity.Property(e => e.OrderDetailId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("OrderDetailID");
            entity.Property(e => e.Address).HasMaxLength(50);
            entity.Property(e => e.OrderId)
                .HasColumnType("int(11)")
                .HasColumnName("OrderID");
            entity.Property(e => e.Phone).HasColumnType("int(11)");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.Subtotal).HasPrecision(10, 2);
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Orderdetails)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderDetails_Users");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PRIMARY");

            entity.ToTable("products");

            entity.HasIndex(e => e.CategoryId, "FK__Products__Catego__286302EC");

            entity.Property(e => e.ProductId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.CategoryId)
                .HasColumnType("int(11)")
                .HasColumnName("CategoryID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.ProductName).HasMaxLength(100);
            entity.Property(e => e.StockQuantity).HasColumnType("int(11)");

            entity.HasOne(d => d.Category).WithMany(p => p.Products)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__Products__Catego__286302EC");
        });

        modelBuilder.Entity<Productimage>(entity =>
        {
            entity.HasKey(e => e.ImageId).HasName("PRIMARY");

            entity.ToTable("productimages");

            entity.HasIndex(e => e.ProductId, "FK__ProductIm__Produ__2C3393D0");

            entity.Property(e => e.ImageId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ImageID");
            entity.Property(e => e.Image).HasMaxLength(200);
            entity.Property(e => e.ImageDescription).HasMaxLength(200);
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");

            entity.HasOne(d => d.Product).WithMany(p => p.Productimages)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__ProductIm__Produ__2C3393D0");
        });

        modelBuilder.Entity<Productuser>(entity =>
        {
            entity.HasKey(e => e.ProductUserId).HasName("PRIMARY");

            entity.ToTable("productuser");

            entity.HasIndex(e => e.ProductId, "FK_ProductUser_Products");

            entity.HasIndex(e => e.UserId, "FK_ProductUser_Users");

            entity.Property(e => e.ProductUserId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("ProductUserID");
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.ProductId)
                .HasColumnType("int(11)")
                .HasColumnName("ProductID");
            entity.Property(e => e.Quantity).HasColumnType("int(11)");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Productusers)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK_ProductUser_Products");

            entity.HasOne(d => d.User).WithMany(p => p.Productusers)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_ProductUser_Users");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PRIMARY");

            entity.ToTable("roles");

            entity.Property(e => e.RoleId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(255);
        });

        modelBuilder.Entity<Securityquestion>(entity =>
        {
            entity.HasKey(e => e.QuestionId).HasName("PRIMARY");

            entity.ToTable("securityquestions");

            entity.HasIndex(e => e.UserId, "FK__SecurityQ__UserI__08B54D69");

            entity.Property(e => e.QuestionId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("QuestionID");
            entity.Property(e => e.Answer).HasMaxLength(255);
            entity.Property(e => e.Question).HasMaxLength(255);
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Securityquestions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__SecurityQ__UserI__08B54D69");
        });

        modelBuilder.Entity<Sysdiagram>(entity =>
        {
            entity.HasKey(e => e.DiagramId).HasName("PRIMARY");

            entity.ToTable("sysdiagrams");

            entity.HasIndex(e => new { e.PrincipalId, e.Name }, "UK_principal_name").IsUnique();

            entity.Property(e => e.DiagramId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("diagram_id");
            entity.Property(e => e.Definition).HasColumnName("definition");
            entity.Property(e => e.Name)
                .HasMaxLength(160)
                .HasColumnName("name");
            entity.Property(e => e.PrincipalId)
                .HasColumnType("int(11)")
                .HasColumnName("principal_id");
            entity.Property(e => e.Version)
                .HasColumnType("int(11)")
                .HasColumnName("version");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PRIMARY");

            entity.ToTable("users");

            entity.HasIndex(e => e.Username, "UQ__Users__536C85E40C00E2AB").IsUnique();

            entity.Property(e => e.UserId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.PhoneNumber).HasMaxLength(20);
            entity.Property(e => e.Username).HasMaxLength(50);
        });

        modelBuilder.Entity<Userrole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PRIMARY");

            entity.ToTable("userroles");

            entity.HasIndex(e => e.RoleId, "FK__UserRoles__RoleI__04E4BC85");

            entity.HasIndex(e => e.UserId, "FK__UserRoles__UserI__03F0984C");

            entity.Property(e => e.UserRoleId)
                .ValueGeneratedNever()
                .HasColumnType("int(11)")
                .HasColumnName("UserRoleID");
            entity.Property(e => e.RoleId)
                .HasColumnType("int(11)")
                .HasColumnName("RoleID");
            entity.Property(e => e.UserId)
                .HasColumnType("int(11)")
                .HasColumnName("UserID");

            entity.HasOne(d => d.Role).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__UserRoles__RoleI__04E4BC85");

            entity.HasOne(d => d.User).WithMany(p => p.Userroles)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__UserRoles__UserI__03F0984C");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
