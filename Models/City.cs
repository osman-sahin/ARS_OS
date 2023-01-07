using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection.Emit;

namespace ARS_OS.Models
{
    [Table("City")]
    public class City
    {
        [Key]
        public Guid Id { get; set; }
        public string Name { get; set; }
        //public double CoordinateX { get; set; }
        //public double CoordinateY { get; set; }
        public virtual ICollection<TripPlan> TripPlansFrom { get; set; }
        public virtual ICollection<TripPlan> TripPlansTo { get; set; }
        ////public virtual List<TripPlan>  { get; set; }
        ///
        public class CityConfiguration : IEntityTypeConfiguration<City>
        {
            public void Configure(EntityTypeBuilder<City> builder)
            {
                builder.HasKey(t => t.Id);
                builder.HasMany(g => g.TripPlansFrom)
                    .WithOne(s => s.FromCity)
                    .HasForeignKey(s => s.FromCityId).OnDelete(DeleteBehavior.NoAction);
                builder.HasMany(g => g.TripPlansTo)
                    .WithOne(s => s.ToCity)
                    .HasForeignKey(s => s.ToCityId).OnDelete(DeleteBehavior.NoAction);
                builder.Property(t => t.Name)
                    .HasColumnType("nvarchar")
                    .HasMaxLength(256)
                    .IsRequired();

                for (int i = 0; i < 200; i++)
                {
                    builder.HasData(new City { Id = Guid.NewGuid(), Name = $"City-{i}" });
                }
            }
        }
    }
}
