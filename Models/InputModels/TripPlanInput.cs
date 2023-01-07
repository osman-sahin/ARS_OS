namespace ARS_OS.Models.InputModels
{
    public record TripPlanInput
    {
        public Guid FromCityId { get; set; }
        public Guid ToCityId { get; set; }
        public DateTime DatePlanned { get; set; }
        public string Description { get; set; } = string.Empty;
        public short NumberOfSeats { get; set; }
    }
}
