using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace AnimalStore.Models
{
    public partial class AnimalStoreContext : DbContext
    {
        public AnimalStoreContext()
        {
        }

        public AnimalStoreContext(DbContextOptions<AnimalStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Animal> Animals { get; set; }
        public virtual DbSet<Client> Clients { get; set; }
        public virtual DbSet<ClientCard> ClientCards { get; set; }
        public virtual DbSet<Holiday> Holidays { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Town> Towns { get; set; }
        public virtual DbSet<TypeOfType> TypeOfTypes { get; set; }
        public virtual DbSet<TypesOfProduct> TypesOfProducts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer(@"Server=.\SQLEXPRESS;Database=AnimalStore;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Cyrillic_General_CI_AS");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.AddressName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TownId).HasColumnName("TownID");

                entity.HasOne(d => d.Town)
                    .WithMany(p => p.Addresses)
                    .HasForeignKey(d => d.TownId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Addresses__TownI__267ABA7A");
            });

            modelBuilder.Entity<Animal>(entity =>
            {
                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.AnimalName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.HasIndex(e => e.PhoneNumber, "UQ__Clients__85FB4E3882EC9B8A")
                    .IsUnique();

                entity.HasIndex(e => e.Email, "UQ__Clients__A9D10534368AC458")
                    .IsUnique();

                entity.Property(e => e.ClientId).HasColumnName("ClientID");

                entity.Property(e => e.AddressId).HasColumnName("AddressID");

                entity.Property(e => e.ClientCardId).HasColumnName("ClientCardID");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.MiddleName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Clients__Address__2E1BDC42");

                entity.HasOne(d => d.ClientCard)
                    .WithMany(p => p.Clients)
                    .HasForeignKey(d => d.ClientCardId)
                    .HasConstraintName("FK__Clients__ClientC__2D27B809");
            });

            modelBuilder.Entity<ClientCard>(entity =>
            {
                entity.HasKey(e => e.CardId)
                    .HasName("PK__ClientCa__55FECD8E3D49B837");

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.Birthday).HasColumnType("date");
            });

            modelBuilder.Entity<Holiday>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.HolidayDate).HasColumnType("date");

                entity.Property(e => e.HolidayName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("OrderID");

                entity.Property(e => e.ClientCardId).HasColumnName("ClientCardID");

                entity.Property(e => e.DateAndTime).HasColumnType("smalldatetime");

                entity.HasOne(d => d.ClientCard)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ClientCardId)
                    .HasConstraintName("FK__Orders__ClientCa__38996AB5");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => new { e.OrderId, e.TypeId })
                    .HasName("PK_OrderID_TypeID");

                entity.Property(e => e.OrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("OrderID");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.TypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderDeta__TypeI__3B75D760");
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.Property(e => e.TownId).HasColumnName("TownID");

                entity.Property(e => e.PostCode)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.TownName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypeOfType>(entity =>
            {
                entity.ToTable("TypeOfType");

                entity.Property(e => e.TypeOfTypeId).HasColumnName("TypeOfTypeID");

                entity.Property(e => e.TypeOfTypeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<TypesOfProduct>(entity =>
            {
                entity.HasKey(e => e.TypeId)
                    .HasName("PK__TypesOfP__516F039563D12784");

                entity.ToTable("TypesOfProduct");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");

                entity.Property(e => e.AnimalId).HasColumnName("AnimalID");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.TypeName)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.TypeOfTypeId).HasColumnName("TypeOfTypeID");

                entity.HasOne(d => d.Animal)
                    .WithMany(p => p.TypesOfProducts)
                    .HasForeignKey(d => d.AnimalId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TypesOfPr__Anima__34C8D9D1");

                entity.HasOne(d => d.TypeOfType)
                    .WithMany(p => p.TypesOfProducts)
                    .HasForeignKey(d => d.TypeOfTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TypesOfPr__TypeO__35BCFE0A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
