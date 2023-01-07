using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Emit;

namespace ARS_OS.Models
{
    [Table("TripPlan")]
    public class TripPlan : BaseModel
    {
        public Guid FromCityId { get; set; }
        public Guid ToCityId { get; set; }
        public DateTime DatePlanned { get; set; }
        public string Description { get; set; } = string.Empty;
        public short NumberOfSeats { get; set; }
        public bool Published { get; set; }
        public virtual City FromCity { get; set; }
        public virtual City ToCity { get; set; }
        public virtual ICollection<TripPlanRequest> TripPlanRequests { get; set; }

    }

    public class TripPlanConfiguration : IEntityTypeConfiguration<TripPlan>
    {
        public void Configure(EntityTypeBuilder<TripPlan> builder)
        {
            builder.HasKey(t => t.Id);
            builder.HasMany(g => g.TripPlanRequests)
                    .WithOne(s => s.TripPlan)
                    .HasForeignKey(s => s.TripId).OnDelete(DeleteBehavior.NoAction);
            builder.Property(t => t.DatePlanned)
                    .HasColumnType("datetime2")
                    .IsRequired();
            builder.Property(t => t.Description)
                    .IsRequired().HasMaxLength(255);
            builder.Property(t => t.NumberOfSeats)
                    .HasColumnType("smallint")
                    .IsRequired();
            builder.Property(t => t.Published)
                    .HasColumnType("bit")
                    .IsRequired();
        }
    }
}
