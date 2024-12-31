using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Fooddeliverywebsite.Models;

public partial class DbFooddeliveryContext : DbContext
{
    public DbFooddeliveryContext()
    {
    }

    public DbFooddeliveryContext(DbContextOptions<DbFooddeliveryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Deliverypartner> Deliverypartners { get; set; }

    public virtual DbSet<Login> Logins { get; set; }

    public virtual DbSet<MasterRestaurant> MasterRestaurants { get; set; }

    public virtual DbSet<Mastercuisine> Mastercuisines { get; set; }

    public virtual DbSet<Masteruser> Masterusers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Registeruser> Registerusers { get; set; }

    public virtual DbSet<Restaurant> Restaurants { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=AMI_BAJPAI\\SQLEXPRESS;Database=db_fooddelivery;Trusted_Connection=True; TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Deliverypartner>(entity =>
        {
            entity.HasKey(e => e.Deliverypartnerid).HasName("PK__Delivery__03BB12A77C81AA12");

            entity.ToTable("Deliverypartner");

            entity.Property(e => e.Deliverypartnerid).ValueGeneratedNever();
            entity.Property(e => e.Deliverypartnername)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Itemdelivered)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Remark)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Revenueofday).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Typeofrevenue)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Login>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("login");

            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("password");
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("username");
        });

        modelBuilder.Entity<MasterRestaurant>(entity =>
        {
            entity.HasKey(e => e.Restaurantid);

            entity.ToTable("masterRestaurant");

            entity.Property(e => e.Restaurantid).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Closingtime).HasColumnName("closingtime");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Emailaddress)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("emailaddress");
            entity.Property(e => e.Operatingtime).HasComputedColumnSql("(datediff(minute,[Openingtime],[closingtime])/(60))", false);
            entity.Property(e => e.Restaurantname)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Mastercuisine>(entity =>
        {
            entity.HasKey(e => e.Cuisineid).HasName("PK__mastercu__0CF320D21EF45A02");

            entity.ToTable("mastercuisine");

            entity.Property(e => e.Cuisineid)
                .ValueGeneratedNever()
                .HasColumnName("cuisineid");
            entity.Property(e => e.Cuisinename)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("cuisinename");
        });

        modelBuilder.Entity<Masteruser>(entity =>
        {
            entity.HasKey(e => e.Userid).HasName("PK__masterus__1797D02490D255C2");

            entity.ToTable("masteruser");

            entity.Property(e => e.Userid).ValueGeneratedNever();
            entity.Property(e => e.DefaultAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Usertype)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Menuid).HasName("PK__Menu__C987F6A8098AAA54");

            entity.ToTable("Menu");

            entity.Property(e => e.Menuid).ValueGeneratedNever();
            entity.Property(e => e.Cuisineid).HasColumnName("cuisineid");
            entity.Property(e => e.Itemcategory)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("itemcategory");
            entity.Property(e => e.Itemname)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("itemname");
            entity.Property(e => e.Itemprice)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("itemprice");

            entity.HasOne(d => d.Cuisine).WithMany(p => p.Menus)
                .HasForeignKey(d => d.Cuisineid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Menu__cuisineid__6B24EA82");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__order__C3905BCF2CA2FA10");

            entity.ToTable("order");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.Deliverypartnername)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany(p => p.Orders)
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__order__userid__60A75C0F");
        });

        modelBuilder.Entity<Registeruser>(entity =>
        {
            entity.HasKey(e => e.PhoneNo);

            entity.ToTable("Registeruser");

            entity.Property(e => e.PhoneNo)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Address)
                .HasMaxLength(10)
                .IsFixedLength();
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        modelBuilder.Entity<Restaurant>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("restaurant");

            entity.Property(e => e.Activeoffers)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Bestselleritems)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Itemprice).HasColumnName("itemprice");
            entity.Property(e => e.Itemrating)
                .HasColumnType("decimal(3, 2)")
                .HasColumnName("itemrating");
            entity.Property(e => e.Itemsinstock)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Ordereditem)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Revenuetype)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("revenuetype");
            entity.Property(e => e.Totalrevenue).HasColumnName("totalrevenue");
            entity.Property(e => e.Userid).HasColumnName("userid");

            entity.HasOne(d => d.User).WithMany()
                .HasForeignKey(d => d.Userid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__restauran__useri__4AB81AF0");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Password);

            entity.ToTable("user");

            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DefaultAddress)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Location)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Preferences)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
