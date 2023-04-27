using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ORDMNG.Models
{
    public partial class ORDMNG_81310Context : DbContext
    {
        public ORDMNG_81310Context()
        {
        }

        public ORDMNG_81310Context(DbContextOptions<ORDMNG_81310Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Cart> Cart { get; set; }
        public virtual DbSet<CartItems> CartItems { get; set; }
        public virtual DbSet<OrderItems> OrderItems { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Payment> Payment { get; set; }
        public virtual DbSet<Products> Products { get; set; }
       
        public virtual DbSet<Shipping> Shipping { get; set; }
        public virtual DbSet<Users> Users { get; set; }

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("server=10.3.117.39;database=ORDMNG_81310;trusted_connection=true;");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cart>(entity =>
            {
                entity.HasOne(d => d.CartItem)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.CartItemId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__CartItemId__01142BA1");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Cart)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Cart__UserId__00200768");
            });

            modelBuilder.Entity<CartItems>(entity =>
            {
                entity.HasKey(e => e.CartItemId);

                entity.Property(e => e.CartItemId).HasColumnName("CartItemID");

                entity.Property(e => e.Pid).HasColumnName("PId");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.CartItems)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__CartItems__PId__7D439ABD");
            });

            modelBuilder.Entity<OrderItems>(entity =>
            {
                entity.HasKey(e => e.Oiid);

                entity.Property(e => e.Oiid).HasColumnName("OIID");

                entity.Property(e => e.Oid).HasColumnName("OId");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.HasOne(d => d.O)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItems__OId__7A672E12");

                entity.HasOne(d => d.P)
                    .WithMany(p => p.OrderItems)
                    .HasForeignKey(d => d.Pid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderItems__PID__797309D9");
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.Property(e => e.Oid).HasColumnName("OId");

                entity.Property(e => e.OrderDate).HasColumnType("datetime");

                entity.Property(e => e.OrderStatus)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Orders__UserId__74AE54BC");
            });

            modelBuilder.Entity<Payment>(entity =>
            {
                entity.HasIndex(e => e.PaymentStatus)
                    .HasName("UQ__Payment__143194FFFC23D77D")
                    .IsUnique();

                entity.HasIndex(e => e.TransactionId)
                    .HasName("UQ__Payment__55433A6AC8960848")
                    .IsUnique();

                entity.Property(e => e.Oid).HasColumnName("OId");

                entity.Property(e => e.PayStamp).HasColumnType("datetime");

                entity.Property(e => e.PaymentStatus)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Paymethod)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShipId).HasColumnName("ShipID");

                entity.Property(e => e.TransactionId).HasMaxLength(100);

                entity.HasOne(d => d.O)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.Oid)
                    .HasConstraintName("FK__Payment__OId__1332DBDC");

                entity.HasOne(d => d.Ship)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.ShipId)
                    .HasConstraintName("FK__Payment__ShipID__14270015");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Payment)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Payment__UserId__151B244E");
            });

            modelBuilder.Entity<Products>(entity =>
            {
                entity.HasKey(e => e.Pid);

                entity.Property(e => e.Pid).HasColumnName("PId");

                entity.Property(e => e.Category).HasMaxLength(50);

                entity.Property(e => e.ProductName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Seller)
                    .IsRequired()
                    .HasMaxLength(50);
            });

           

            modelBuilder.Entity<Shipping>(entity =>
            {
                entity.HasKey(e => e.ShipId);

                entity.Property(e => e.ShipId).HasColumnName("ShipID");

                entity.Property(e => e.ShipStatus)
                    .IsRequired()
                    .HasMaxLength(20);
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.Email).HasMaxLength(70);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(20);

                entity.Property(e => e.UserAddress)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.UserPassword)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(20);
            });
        }
    }
}
