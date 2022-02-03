//using System;
//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Metadata;

//#nullable disable

//namespace WebAPI.Models
//{
//    public partial class Project4Context : DbContext
//    {
//        public Project4Context()
//        {
//            //
//        }

//        public Project4Context(DbContextOptions<Project4Context> options) : base(options){ }

//        public virtual DbSet<Admin> Admins { get; set; }
//        public virtual DbSet<Image> Images { get; set; }
//        public virtual DbSet<Location> Locations { get; set; }
//        public virtual DbSet<Manager> Managers { get; set; }
//        public virtual DbSet<Product> Products { get; set; }
//        public virtual DbSet<Role> Roles { get; set; }
//        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
//        public virtual DbSet<Store> Stores { get; set; }
//        public virtual DbSet<StoreSalesDetail> StoreSalesDetails { get; set; }
//        public virtual DbSet<Target> Targets { get; set; }
//        public virtual DbSet<User> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
////#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.\\CHI;Database=Project4;User=sa;Password=123");
//            }
//        }

//        protected override void OnModelCreating(ModelBuilder modelBuilder)
//        {
//            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

//            modelBuilder.Entity<Admin>(entity =>
//            {
//                entity.ToTable("Admin");

//                entity.Property(e => e.Email)
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.Fullname)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);

//                entity.Property(e => e.Password)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.Phone)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.Username)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Image>(entity =>
//            {
//                entity.ToTable("Image");

//                entity.Property(e => e.Images)
//                    .HasMaxLength(350)
//                    .IsUnicode(false);

//                entity.Property(e => e.ProductId)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Product)
//                    .WithMany(p => p.ImagesNavigation)
//                    .HasForeignKey(d => d.ProductId)
//                    .HasConstraintName("FK_image_product");
//            });

//            modelBuilder.Entity<Location>(entity =>
//            {
//                entity.ToTable("Location");

//                entity.Property(e => e.District)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.Ward)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Manager>(entity =>
//            {
//                entity.ToTable("Manager");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.Property(e => e.Fullname)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Location)
//                    .WithMany(p => p.Managers)
//                    .HasForeignKey(d => d.LocationId)
//                    .HasConstraintName("FK_manager_location");
//            });

//            modelBuilder.Entity<Product>(entity =>
//            {
//                entity.ToTable("Product");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.Property(e => e.Images)
//                    .HasMaxLength(350)
//                    .IsUnicode(false);

//                entity.Property(e => e.Name)
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

//                entity.Property(e => e.Unit)
//                    .HasMaxLength(10)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<Role>(entity =>
//            {
//                entity.ToTable("Role");

//                entity.Property(e => e.Title)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);
//            });

//            modelBuilder.Entity<SalesDetail>(entity =>
//            {
//                entity.ToTable("SalesDetail");

//                entity.Property(e => e.Date).HasColumnType("datetime");

//                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

//                entity.Property(e => e.ProductId)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Product)
//                    .WithMany(p => p.SalesDetails)
//                    .HasForeignKey(d => d.ProductId)
//                    .HasConstraintName("FK_sales_detail_product");

//                entity.HasOne(d => d.Target)
//                    .WithMany(p => p.SalesDetails)
//                    .HasForeignKey(d => d.TargetId)
//                    .HasConstraintName("FK_sales_detail_target");
//            });

//            modelBuilder.Entity<Store>(entity =>
//            {
//                entity.ToTable("Store");

//                entity.Property(e => e.Id)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.Property(e => e.Address)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Email)
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.Name)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);

//                entity.Property(e => e.Phone)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Location)
//                    .WithMany(p => p.Stores)
//                    .HasForeignKey(d => d.LocationId)
//                    .HasConstraintName("FK_store_location");
//            });

//            modelBuilder.Entity<StoreSalesDetail>(entity =>
//            {
//                entity.ToTable("StoreSalesDetail");

//                entity.Property(e => e.Date).HasColumnType("datetime");

//                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

//                entity.Property(e => e.ProductId)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.Property(e => e.StoreId)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Product)
//                    .WithMany(p => p.StoreSalesDetails)
//                    .HasForeignKey(d => d.ProductId)
//                    .HasConstraintName("FK_store_sales_detail_product");

//                entity.HasOne(d => d.SalesDetail)
//                    .WithMany(p => p.StoreSalesDetails)
//                    .HasForeignKey(d => d.SalesDetailId)
//                    .HasConstraintName("FK_store_sales_detail_sales_detail");

//                entity.HasOne(d => d.Store)
//                    .WithMany(p => p.StoreSalesDetails)
//                    .HasForeignKey(d => d.StoreId)
//                    .HasConstraintName("FK_store_sales_detail_store");
//            });

//            modelBuilder.Entity<Target>(entity =>
//            {
//                entity.ToTable("Target");

//                entity.Property(e => e.FromDate).HasColumnType("datetime");

//                entity.Property(e => e.ToDate).HasColumnType("datetime");
//            });

//            modelBuilder.Entity<User>(entity =>
//            {
//                entity.ToTable("User");

//                entity.Property(e => e.Address)
//                    .HasMaxLength(50)
//                    .IsUnicode(false);

//                entity.Property(e => e.Email)
//                    .HasMaxLength(30)
//                    .IsUnicode(false);

//                entity.Property(e => e.Fullname)
//                    .HasMaxLength(40)
//                    .IsUnicode(false);

//                entity.Property(e => e.ManagerId)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.Property(e => e.Password)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.Phone)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.Property(e => e.StoreId)
//                    .HasMaxLength(5)
//                    .IsUnicode(false);

//                entity.Property(e => e.Username)
//                    .HasMaxLength(20)
//                    .IsUnicode(false);

//                entity.HasOne(d => d.Location)
//                    .WithMany(p => p.Users)
//                    .HasForeignKey(d => d.LocationId)
//                    .HasConstraintName("FK_user_location");

//                entity.HasOne(d => d.Manager)
//                    .WithMany(p => p.Users)
//                    .HasForeignKey(d => d.ManagerId)
//                    .HasConstraintName("FK_user_manager");

//                entity.HasOne(d => d.Role)
//                    .WithMany(p => p.Users)
//                    .HasForeignKey(d => d.RoleId)
//                    .HasConstraintName("FK_user_role");

//                entity.HasOne(d => d.Store)
//                    .WithMany(p => p.Users)
//                    .HasForeignKey(d => d.StoreId)
//                    .HasConstraintName("FK_user_store");

//                entity.HasOne(d => d.Target)
//                    .WithMany(p => p.Users)
//                    .HasForeignKey(d => d.TargetId)
//                    .HasConstraintName("FK_user_target1");
//            });

//            OnModelCreatingPartial(modelBuilder);
//        }

//        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
//    }
//}
