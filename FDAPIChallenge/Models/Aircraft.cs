using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace FDAPIChallenge.Models
{
    public class Aircraft
    {
        [Key]
        public int AircraftId { get; set; }
        [JsonIgnore]
        public double DailyHours { get; set; }
        [JsonIgnore]
        public double CurrentHours { get; set; }
        //public ICollection<AircraftTask>? AircraftTasks { get; set; }
        public AircraftTasks? AircraftTasks { get; set; }
    }
}
