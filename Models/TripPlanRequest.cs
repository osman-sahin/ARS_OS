using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace ARS_OS.Models
{
    [Table("TripPlanRequest")]
    public class TripPlanRequest : BaseModel
    {
        public Guid TripId { get; set; }
        public short NumberOfSeats { get; set; }
        public virtual TripPlan TripPlan { get; set; }
    }

    public class TripPlanRequestConfiguration : IEntityTypeConfiguration<TripPlanRequest>
    {
        public void Configure(EntityTypeBuilder<TripPlanRequest> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.NumberOfSeats)
                    .HasColumnType("smallint")
                    .IsRequired();
        }
    }
}
