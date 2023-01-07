namespace ARS_OS.Models.InputModels
{
    public record TripPlanPublishInput
    {
        public Guid Id { get; set; }
        public bool Published { get; set; }
    }
}
