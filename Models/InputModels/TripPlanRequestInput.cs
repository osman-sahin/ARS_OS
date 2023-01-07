namespace ARS_OS.Models.InputModels
{
    public class TripPlanRequestInput
    {
        public Guid TripId { get; set; }
        public short NumberOfSeats { get; set; }
    }
}
