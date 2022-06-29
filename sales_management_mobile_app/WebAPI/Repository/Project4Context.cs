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
        public Project4Context(DbContextOptions<Project4Context> options) : base(options) { }

        public  DbSet<Admin> Admins { get; set; }
        //public  DbSet<Image> Images { get; set; }
        //public  DbSet<Location> Locations { get; set; }
        public DbSet<Director> Directors { get; set; }
        public  DbSet<Manager> Managers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public  DbSet<Product> Products { get; set; }
        public  DbSet<Performance> Performances { get; set; }

        //public  DbSet<Role> Roles { get; set; }
        //public  DbSet<SalesDetail> SalesDetails { get; set; }

        
        //public  DbSet<Target> Targets { get; set; }


        //DbSet của View
        //public DbSet<vTargetUserManager> vTargetUserManager { get; set; }
        //public DbSet<vSalesDetailTargetUser> vSalesDetailTargetUser { get; set; }
        public DbSet<vManagerUser> vManagerUser { get; set; }

        public DbSet<vStoreUser> vStoreUser { get; set; }
        public object Admin { get; internal set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server=LAPTOP-6D8AK342\\CHI;database=Project4;uid=sa;pwd=123", options => options.EnableRetryOnFailure());
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

            //modelBuilder.Entity<Image>(entity =>
            //{
            //    entity.ToTable("Image");
            //});

            //modelBuilder.Entity<Location>(entity =>
            //{
            //    entity.ToTable("Location");
            //});
            modelBuilder.Entity<Director>(entity =>
            {
                entity.ToTable("Director");
            });

            modelBuilder.Entity<Manager>(entity =>
            {
                entity.ToTable("Manager");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.ToTable("Store");

            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("Order");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");
            });

            //modelBuilder.Entity<Role>(entity =>
            //{
            //    entity.ToTable("Role");
            //});

            //modelBuilder.Entity<SalesDetail>(entity =>
            //{
            //    entity.ToTable("SalesDetail");
            //});



            //modelBuilder.Entity<Target>(entity =>
            //{
            //    entity.ToTable("Target");
            //});



            modelBuilder.Entity<Performance>(entity =>
            {
                entity.ToTable("Performance");

                entity.Property(e => e.YTD)
                    .HasColumnType("int");
                entity.Property(e => e.UserId)
                    .HasColumnType("int");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
