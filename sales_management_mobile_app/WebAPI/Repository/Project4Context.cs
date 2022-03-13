using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using WebAPI.Models;

#nullable disable

namespace WebAPI.Repository
{
    public partial class Project4Context : DbContext
    {
        public Project4Context()
        {
            //
        }

        public Project4Context(DbContextOptions<Project4Context> options) : base(options) { }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Image> Images { get; set; }
        public virtual DbSet<Location> Locations { get; set; }
        public virtual DbSet<Manager> Managers { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        internal object SingleOrDefault(Func<object, bool> p)
        {
            throw new NotImplementedException();
        }

        public virtual DbSet<Role> Roles { get; set; }
        public virtual DbSet<SalesDetail> SalesDetails { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<StoreSalesDetail> StoreSalesDetails { get; set; }
        public virtual DbSet<Target> Targets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //DbSet của View
        public DbSet<vTargetUser> vTargetUser { get; set; }
        public object Admin { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=localhost;database=Project4;uid=sa;pwd=sql@123456", options => options.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);


            modelBuilder.Entity("WebAPI.Models.Admin", entity =>
             {
                 entity.ToTable("Admin");

                 entity.Property<int>("Id")
                         .ValueGeneratedOnAdd()
                         .HasColumnType("int")
                         .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                 entity.Property<string>("Username")
                     .HasMaxLength(20)
                     .HasColumnType("varchar");

                 entity.Property<string>("Fullname")
                    .HasMaxLength(40)
                    .HasColumnType("varchar");
                 entity.Property<string>("Email")
                    .HasMaxLength(30)
                    .HasColumnType("varchar");

                 entity.Property<string>("Phone")
                    .HasMaxLength(20)
                    .HasColumnType("varchar");

                 entity.Property<byte[]>("PasswordSalt")
                    .HasColumnType("varbinary(max)");

                 entity.Property<byte[]>("PasswordHash")
                   .HasColumnType("varbinary(max)");


            });

            modelBuilder.Entity<Image>(entity =>
            {
                entity.ToTable("Image");

                entity.Property(e => e.Images)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.ProductId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.ImagesNavigation)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_image_product");
            });

            modelBuilder.Entity<Location>(entity =>
            {
                entity.ToTable("Location");

                entity.Property(e => e.District)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ward)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Fullname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Managers)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_manager_location");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Images)
                    .HasMaxLength(350)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.Unit)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Title)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<SalesDetail>(entity =>
            {
                entity.ToTable("SalesDetail");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_sales_detail_product");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.SalesDetails)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK_sales_detail_target");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

                entity.Property(e => e.Id)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Stores)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_store_location");
            });

            modelBuilder.Entity<StoreSalesDetail>(entity =>
            {
                entity.ToTable("StoreSalesDetail");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Price).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.StoreSalesDetails)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_store_sales_detail_product");

                entity.HasOne(d => d.SalesDetail)
                    .WithMany(p => p.StoreSalesDetails)
                    .HasForeignKey(d => d.SalesDetailId)
                    .HasConstraintName("FK_store_sales_detail_sales_detail");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StoreSalesDetails)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_store_sales_detail_store");
            });

            modelBuilder.Entity<Target>(entity =>
            {
                entity.ToTable("Target");

                entity.Property(e => e.FromDate).HasColumnType("datetime");

                entity.Property(e => e.ToDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
                //
                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                //
                entity.Property(e => e.Email)
                    .HasMaxLength(30)
                    .IsUnicode(false);
                //
                entity.Property(e => e.Fullname)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ManagerId)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                //
                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                //
                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.StoreId)
                    .HasMaxLength(5)
                    .IsUnicode(false);
                //
                entity.Property(e => e.Username)
                    .HasMaxLength(20)
                    .IsUnicode(false);
                //
                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("FK_user_location");
                //
                entity.HasOne(d => d.Manager)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.ManagerId)
                    .HasConstraintName("FK_user_manager");
                //
                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_user_role");
                //
                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_user_store");
                //
                entity.HasOne(d => d.Target)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("FK_user_target1");
            });

            OnModelCreatingPartial(modelBuilder);
            //  modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
