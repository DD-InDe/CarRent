using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CarRent.Entities.Models;

public partial class CarRentContext : DbContext
{
    public CarRentContext()
    {
    }

    public CarRentContext(DbContextOptions<CarRentContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Brand> Brands { get; set; }

    public virtual DbSet<BrandModel> BrandModels { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarStatus> CarStatuses { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<DriverLicense> DriverLicenses { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Passport> Passports { get; set; }

    public virtual DbSet<Request> Requests { get; set; }

    public virtual DbSet<RequestStatus> RequestStatuses { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=LEGION\\DEERSERVER;Database=CarRent;Trusted_Connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A6D9634965");

            entity.ToTable("Account");

            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Brand>(entity =>
        {
            entity.HasKey(e => e.BrandId).HasName("PK__Brend__915DEEDC1ECCA3C9");

            entity.ToTable("Brand");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<BrandModel>(entity =>
        {
            entity.HasKey(e => e.BrandModelId).HasName("PK__BrendMod__E20FB2501D0E9D8D");

            entity.ToTable("BrandModel");

            entity.HasOne(d => d.Brand).WithMany(p => p.BrandModels)
                .HasForeignKey(d => d.BrandId)
                .HasConstraintName("FK__BrendMode__Brend__3E52440B");

            entity.HasOne(d => d.Class).WithMany(p => p.BrandModels)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__BrendMode__Class__403A8C7D");

            entity.HasOne(d => d.Model).WithMany(p => p.BrandModels)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK__BrendMode__Model__3F466844");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Car__68A0342EBB364AA6");

            entity.ToTable("Car");

            entity.Property(e => e.CarVin).HasMaxLength(17);
            entity.Property(e => e.Color).HasMaxLength(10);

            entity.HasOne(d => d.BrandModel).WithMany(p => p.Cars)
                .HasForeignKey(d => d.BrandModelId)
                .HasConstraintName("FK__Car__BrendModelI__4316F928");

            entity.HasOne(d => d.CarStatus).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarStatusId)
                .HasConstraintName("FK__Car__CarStatusId__440B1D61");
        });

        modelBuilder.Entity<CarStatus>(entity =>
        {
            entity.HasKey(e => e.CarStatusId).HasName("PK__CarStatu__4A328CC6CD1EBD28");

            entity.ToTable("CarStatus");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Class>(entity =>
        {
            entity.HasKey(e => e.ClassId).HasName("PK__Class__CB1927C0CEC23D29");

            entity.ToTable("Class");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Client__3214EC0721256D43");

            entity.ToTable("Client");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Client)
                .HasForeignKey<Client>(d => d.Id)
                .HasConstraintName("FK_Client_User");
        });

        modelBuilder.Entity<DriverLicense>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__DriverLi__3214EC07A016B089");

            entity.ToTable("DriverLicense");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DataOfIssue).HasColumnType("datetime");
            entity.Property(e => e.ExpirationData).HasColumnType("datetime");
            entity.Property(e => e.Number).HasMaxLength(10);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.DriverLicense)
                .HasForeignKey<DriverLicense>(d => d.Id)
                .HasConstraintName("FK_DriverLicense_Client");
        });

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PK__Model__E8D7A12CB81CE412");

            entity.ToTable("Model");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Passport>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Passport__3214EC076B0ADC59");

            entity.ToTable("Passport");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.IssueDate).HasColumnType("datetime");
            entity.Property(e => e.PassN).HasMaxLength(6);
            entity.Property(e => e.PassS).HasMaxLength(4);

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Passport)
                .HasForeignKey<Passport>(d => d.Id)
                .HasConstraintName("FK_Passport_User");
        });

        modelBuilder.Entity<Request>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Request__3214EC07469BF16E");

            entity.ToTable("Request");

            entity.Property(e => e.EndDate).HasColumnType("date");
            entity.Property(e => e.StartDate).HasColumnType("date");

            entity.HasOne(d => d.Car).WithMany(p => p.Requests)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__Request__CarId__5EBF139D");

            entity.HasOne(d => d.Client).WithMany(p => p.Requests)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK__Request__ClientI__60A75C0F");

            entity.HasOne(d => d.RequestStatus).WithMany(p => p.Requests)
                .HasForeignKey(d => d.RequestStatusId)
                .HasConstraintName("FK__Request__Request__5FB337D6");
        });

        modelBuilder.Entity<RequestStatus>(entity =>
        {
            entity.HasKey(e => e.RequestStatusId).HasName("PK__RequestS__7094B79B2B37ACB9");

            entity.ToTable("RequestStatus");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1AE9137C86");

            entity.ToTable("Role");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CD0105716");

            entity.ToTable("User", tb => tb.HasTrigger("create_rows_after_user_insert"));

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MiddleName).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(20);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__User__RoleId__286302EC");

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserId)
                .HasConstraintName("FK__User__UserId__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
