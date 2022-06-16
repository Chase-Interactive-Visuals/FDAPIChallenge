namespace FDAPIChallenge.Dto
{
    public class AircraftTaskDto
    {
        public int ItemNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime LogDate { get; set; }
        public int? LogHours { get; set; } = null;
        public int? IntervalMonths { get; set; } = null;
        public int? IntervalHours { get; set; } = null;
        public DateTime? NextDue { get; set; } = null;
    }
}
