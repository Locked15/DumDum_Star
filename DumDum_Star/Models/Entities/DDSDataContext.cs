using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace DumDum_Star.Models.Entities
{
    public partial class DDSDataContext : DbContext
    {
        #region Entities.

        public virtual DbSet<Address> Addresses { get; set; } = null!;
        public virtual DbSet<Admin> Admins { get; set; } = null!;
        public virtual DbSet<Choom> Chooms { get; set; } = null!;
        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Corporation> Corporations { get; set; } = null!;
        public virtual DbSet<CyberWare> CyberWares { get; set; } = null!;
        public virtual DbSet<CyberWareMessage> CyberWareMessages { get; set; } = null!;
        public virtual DbSet<CyberWareTarget> CyberWareTargets { get; set; } = null!;
        public virtual DbSet<CyberWareToOrder> CyberWareToOrders { get; set; } = null!;
        public virtual DbSet<CyberWareType> CyberWareTypes { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        #endregion

        #region Constructors.

        public DDSDataContext()
        {

        }

        public DDSDataContext(DbContextOptions<DDSDataContext> options)
               : base(options)
        {

        }
        #endregion

        #region Functions.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connection = GetConnectionString();
                optionsBuilder.UseMySql(connection, ServerVersion.Parse("8.0.31-mysql"))
                              .UseLazyLoadingProxies();
            }
        }

        private static string GetConnectionString()
        {
            ConfigurationBuilder builder = new();
            builder.AddUserSecrets(assembly: Assembly.GetExecutingAssembly());

            var config = builder.Build();
            return Program.Type switch
            {
                StartType.Docker => config["DB.ConnectionString.Docker"],
                StartType.IIS => config["DB.ConnectionString.IIS"],

                _ => string.Empty,
            };
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<Address>(entity =>
            {
                entity.ToTable("address");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.City)
                    .HasMaxLength(48)
                    .HasColumnName("city")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Region)
                    .HasMaxLength(48)
                    .HasColumnName("region")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Street)
                    .HasMaxLength(48)
                    .HasColumnName("street")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.ToTable("admin");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChoomId).HasColumnName("choom_id");
            });

            modelBuilder.Entity<Choom>(entity =>
            {
                entity.ToTable("choom");

                entity.HasIndex(e => e.Login, "login")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Login)
                    .HasMaxLength(32)
                    .HasColumnName("login")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.MailAddress)
                    .HasMaxLength(64)
                    .HasColumnName("mail_address");

                entity.Property(e => e.Name)
                    .HasMaxLength(16)
                    .HasColumnName("name")
                    .HasDefaultValueSql("'Choom'");

                entity.Property(e => e.Password)
                    .HasMaxLength(48)
                    .HasColumnName("password")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("client");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ChoomId).HasColumnName("choom_id");
            });

            modelBuilder.Entity<Corporation>(entity =>
            {
                entity.ToTable("corporation");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Members).HasColumnName("members");

                entity.Property(e => e.MonetaryValue)
                    .HasPrecision(18, 2)
                    .HasColumnName("monetary_value");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<CyberWare>(entity =>
            {
                entity.ToTable("cyber_ware");

                entity.HasIndex(e => e.ManufacturerId, "manufacturer_limit_idx");

                entity.HasIndex(e => e.TargetId, "target_limit_idx");

                entity.HasIndex(e => e.TypeId, "type_limit_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Custom)
                    .IsRequired()
                    .HasColumnName("custom")
                    .HasDefaultValueSql("'1'");

                entity.Property(e => e.Image)
                    .HasMaxLength(128)
                    .HasColumnName("image");

                entity.Property(e => e.LoadLevel)
                    .HasColumnName("load_level")
                    .HasDefaultValueSql("'0.05'");

                entity.Property(e => e.ManufacturerId).HasColumnName("manufacturer_id");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Price)
                    .HasPrecision(9, 2)
                    .HasColumnName("price");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.TargetId).HasColumnName("target_id");

                entity.Property(e => e.TypeId).HasColumnName("type_id");

                entity.HasOne(d => d.Manufacturer)
                    .WithMany(p => p.CyberWares)
                    .HasForeignKey(d => d.ManufacturerId)
                    .HasConstraintName("manufacturer_limit");

                entity.HasOne(d => d.Target)
                    .WithMany(p => p.CyberWares)
                    .HasForeignKey(d => d.TargetId)
                    .HasConstraintName("target_limit");

                entity.HasOne(d => d.Type)
                    .WithMany(p => p.CyberWares)
                    .HasForeignKey(d => d.TypeId)
                    .HasConstraintName("type_limit");
            });

            modelBuilder.Entity<CyberWareMessage>(entity =>
            {
                entity.ToTable("cyber_ware_message");

                entity.HasIndex(e => e.AuthorId, "author_limit_idx");

                entity.HasIndex(e => e.CyberWareId, "cyber_limit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AuthorId).HasColumnName("author_id");

                entity.Property(e => e.CyberWareId).HasColumnName("cyber_ware_id");

                entity.Property(e => e.Message)
                    .HasMaxLength(128)
                    .HasColumnName("message")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");

                entity.Property(e => e.Rank).HasColumnName("rank");

                entity.HasOne(d => d.Author)
                    .WithMany(p => p.CyberWareMessages)
                    .HasForeignKey(d => d.AuthorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("author_limit");

                entity.HasOne(d => d.CyberWare)
                    .WithMany(p => p.CyberWareMessages)
                    .HasForeignKey(d => d.CyberWareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cyber_limit");
            });

            modelBuilder.Entity<CyberWareTarget>(entity =>
            {
                entity.ToTable("cyber_ware_target");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(64)
                    .HasColumnName("name")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<CyberWareToOrder>(entity =>
            {
                entity.ToTable("cyber_ware_to_order");

                entity.HasIndex(e => e.CyberWareId, "cyber_in_order_limit");

                entity.HasIndex(e => e.OrderId, "order_in_cyber_limit");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.CyberWareId).HasColumnName("cyber_ware_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.HasOne(d => d.CyberWare)
                    .WithMany(p => p.CyberWareToOrders)
                    .HasForeignKey(d => d.CyberWareId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("cyber_in_order_limit");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.CyberWareToOrders)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("order_in_cyber_limit");
            });

            modelBuilder.Entity<CyberWareType>(entity =>
            {
                entity.ToTable("cyber_ware_type");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Type)
                    .HasMaxLength(48)
                    .HasColumnName("type")
                    .UseCollation("utf8mb3_general_ci")
                    .HasCharSet("utf8mb3");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.ToTable("order");

                entity.HasIndex(e => e.AddressId, "address_limit_idx");

                entity.HasIndex(e => e.ChoomId, "choom_limit_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AddressId).HasColumnName("address_id");

                entity.Property(e => e.ChippinTime)
                    .HasColumnType("datetime")
                    .HasColumnName("chippin_time");

                entity.Property(e => e.ChoomId).HasColumnName("choom_id");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.AddressId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("address_limit");

                entity.HasOne(d => d.Choom)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.ChoomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("choom_limit");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
