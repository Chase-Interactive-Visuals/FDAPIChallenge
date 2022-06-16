using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FDAPIChallenge.Models
{
    [System.Serializable]
    public class AircraftTask
    {
        public int ItemNumber { get; set; }
        public string Description { get; set; } = string.Empty;
        public DateTime LogDate { get; set; }
        public int? LogHours { get; set; } = null;
        public int? IntervalMonths { get; set; } = null;
        public int? IntervalHours { get; set; } = null;
        public DateTime? NextDue { get; set; } = null;
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
    }
    
    [System.Serializable]
    public class AircraftTasks
    {
        [JsonIgnore]
        [Key]
        public int Id { get; set; }
        public List<AircraftTask>? AricraftTaskSet { get; set; }
    }
}
