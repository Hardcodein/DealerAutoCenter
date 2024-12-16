namespace Database.DealershipCenter.DatabaseContext;

public partial class DealershipCenterDBContext : DbContext
{
    public DealershipCenterDBContext()
    { 
      
    }
    public DealershipCenterDBContext(DbContextOptions<DealershipCenterDBContext> options) : base(options)
    {

    }
    

    public DbSet<BrandsCars> Brands { get; set; }
    public DbSet<ColorsCars> Colors { get; set; }
    public DbSet<ComplectationsCars> Complectations { get; set; }
    public DbSet<ModelCars> Models { get; set; }
    public DbSet<SalesCars> Sales { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<SalesCars>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("sales_cars_pkey");
            entity.ToTable("sales_cars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ColorId).HasColumnName("color_id");
            entity.Property(e => e.ModelId).HasColumnName("model_id");
            entity.Property(e => e.ComplectationId).HasColumnName("complectation_id");
            entity.Property(e => e.Date)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("date");
            entity.Property(e => e.Amount).HasColumnName("amount");
        });

        modelBuilder.Entity<BrandsCars>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("brand_cars_pkey");

            entity.ToTable("brand_cars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(40).HasColumnName("name");

            entity.HasMany(b => b.Models).WithOne(m => m.Brand)
            .HasForeignKey(i => i.BrandId)

            .HasConstraintName("fk_brand_model");

        });

        modelBuilder.Entity<ColorsCars>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("color_cars_pkey");

            entity.ToTable("color_cars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(20).HasColumnName("name");

            entity.HasMany(s => s.Sales).WithOne(s => s.ColorCar)
            .HasForeignKey(i => i.ColorId)
            .HasConstraintName("fk_colorcar_sales");
        });

        modelBuilder.Entity<ComplectationsCars>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("complectation_cars_pkey");

            entity.ToTable("complectation_cars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(20).HasColumnName("name");

            entity.HasMany(s => s.Sales).WithOne(c => c.ComplectationCar)
            .HasForeignKey(i => i.ComplectationId)

            .HasConstraintName("fk_complectationcar_sales");
        });

        modelBuilder.Entity<ModelCars>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("model_cars_pkey");

            entity.ToTable("model_cars");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name).HasMaxLength(20).HasColumnName("name");

           
            entity.HasMany(s => s.Sales).WithOne(m => m.ModelCar)
            .HasForeignKey(i => i.ModelId)
            .HasConstraintName("fk_modelcar_sales");
        });


    }
}
