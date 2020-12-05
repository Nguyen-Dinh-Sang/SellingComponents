using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace WebApplication.Models
{
    public partial class SellingComponentsDBContext : DbContext
    {
        public SellingComponentsDBContext()
        {
        }

        public SellingComponentsDBContext(DbContextOptions<SellingComponentsDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Catalog> Catalogs { get; set; }
        public virtual DbSet<Classify> Classifies { get; set; }
        public virtual DbSet<Combo> Combos { get; set; }
        public virtual DbSet<ComboDetail> ComboDetails { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrdersDetail> OrdersDetails { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<UserInformation> UserInformations { get; set; }
        public virtual DbSet<Warehouse> Warehouses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=SellingComponentsDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalog>(entity =>
            {
                entity.ToTable("Catalog");

                entity.Property(e => e.CatalogDetails)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.CatalogName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Classify>(entity =>
            {
                entity.ToTable("Classify");

                entity.Property(e => e.ClassifyDetail)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ClassifyName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Combo>(entity =>
            {
                entity.ToTable("Combo");

                entity.Property(e => e.ComboDetails)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.ComboName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(14, 1)");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(14, 1)");

                entity.HasOne(d => d.IdCatalogNavigation)
                    .WithMany(p => p.Combos)
                    .HasForeignKey(d => d.IdCatalog)
                    .HasConstraintName("Combo_Catalog");
            });

            modelBuilder.Entity<ComboDetail>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdComboNavigation)
                    .WithMany(p => p.ComboDetailsNavigation)
                    .HasForeignKey(d => d.IdCombo)
                    .HasConstraintName("ComboDetails_Combo");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.ComboDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("ComboDetails_Product");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DeliveryAddress)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.TotalCost).HasColumnType("decimal(14, 1)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.IdUser)
                    .HasConstraintName("Orders_UserInformation");
            });

            modelBuilder.Entity<OrdersDetail>(entity =>
            {
                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Price).HasColumnType("decimal(13, 1)");

                entity.HasOne(d => d.IdComboNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.IdCombo)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("OrdersDetails_Combo");

                entity.HasOne(d => d.IdOrdersNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.IdOrders)
                    .HasConstraintName("OrdersDetails_Orders");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.OrdersDetails)
                    .HasForeignKey(d => d.IdProduct)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("OrdersDetails_Product");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail)
                    .IsRequired()
                    .HasMaxLength(1000);

                entity.Property(e => e.Price).HasColumnType("decimal(13, 1)");

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.IdClassifyNavigation)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.IdClassify)
                    .HasConstraintName("Product_Classify");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Role1)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("Role");
            });

            modelBuilder.Entity<UserInformation>(entity =>
            {
                entity.ToTable("UserInformation");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Brithday).HasColumnType("date");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FullName)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.JoinDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Sex).HasMaxLength(100);

                entity.Property(e => e.UserName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdRoleNavigation)
                    .WithMany(p => p.UserInformations)
                    .HasForeignKey(d => d.IdRole)
                    .HasConstraintName("UserInformation_Role");
            });

            modelBuilder.Entity<Warehouse>(entity =>
            {
                entity.ToTable("Warehouse");

                entity.Property(e => e.InputDate)
                    .HasColumnType("date")
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdProductNavigation)
                    .WithMany(p => p.Warehouses)
                    .HasForeignKey(d => d.IdProduct)
                    .HasConstraintName("Warehouse_Product");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
