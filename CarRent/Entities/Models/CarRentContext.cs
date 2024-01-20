using Microsoft.EntityFrameworkCore;

namespace CarRent.Models;

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

    public virtual DbSet<Brend> Brends { get; set; }

    public virtual DbSet<BrendModel> BrendModels { get; set; }

    public virtual DbSet<Car> Cars { get; set; }

    public virtual DbSet<CarImage> CarImages { get; set; }

    public virtual DbSet<CarStatus> CarStatuses { get; set; }

    public virtual DbSet<Class> Classes { get; set; }

    public virtual DbSet<Model> Models { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-OE4PBCI\\SQLEXPRESS;Database=CarRent;Trusted_connection=True;Encrypt=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A6D9634965");

            entity.ToTable("Account");

            entity.Property(e => e.Login).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(50);
        });

        modelBuilder.Entity<Brend>(entity =>
        {
            entity.HasKey(e => e.BrendId).HasName("PK__Brend__915DEEDC1ECCA3C9");

            entity.ToTable("Brend");

            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<BrendModel>(entity =>
        {
            entity.HasKey(e => e.BrendModelId).HasName("PK__BrendMod__E20FB2501D0E9D8D");

            entity.ToTable("BrendModel");

            entity.HasOne(d => d.Brend).WithMany(p => p.BrendModels)
                .HasForeignKey(d => d.BrendId)
                .HasConstraintName("FK__BrendMode__Brend__3E52440B");

            entity.HasOne(d => d.Class).WithMany(p => p.BrendModels)
                .HasForeignKey(d => d.ClassId)
                .HasConstraintName("FK__BrendMode__Class__403A8C7D");

            entity.HasOne(d => d.Model).WithMany(p => p.BrendModels)
                .HasForeignKey(d => d.ModelId)
                .HasConstraintName("FK__BrendMode__Model__3F466844");
        });

        modelBuilder.Entity<Car>(entity =>
        {
            entity.HasKey(e => e.CarId).HasName("PK__Car__68A0342EBB364AA6");

            entity.ToTable("Car");

            entity.Property(e => e.Color).HasMaxLength(10);

            entity.HasOne(d => d.BrendModel).WithMany(p => p.Cars)
                .HasForeignKey(d => d.BrendModelId)
                .HasConstraintName("FK__Car__BrendModelI__4316F928");

            entity.HasOne(d => d.CarStatus).WithMany(p => p.Cars)
                .HasForeignKey(d => d.CarStatusId)
                .HasConstraintName("FK__Car__CarStatusId__440B1D61");
        });

        modelBuilder.Entity<CarImage>(entity =>
        {
            entity.HasKey(e => e.CarImageId).HasName("PK__CarImage__614BE6AFB210917E");

            entity.ToTable("CarImage");

            entity.HasOne(d => d.Car).WithMany(p => p.CarImages)
                .HasForeignKey(d => d.CarId)
                .HasConstraintName("FK__CarImage__CarId__46E78A0C");
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

        modelBuilder.Entity<Model>(entity =>
        {
            entity.HasKey(e => e.ModelId).HasName("PK__Model__E8D7A12CB81CE412");

            entity.ToTable("Model");

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

            entity.ToTable("User");

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
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__User__UserId__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
