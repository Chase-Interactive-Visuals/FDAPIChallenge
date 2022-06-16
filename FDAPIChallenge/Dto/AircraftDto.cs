using FDAPIChallenge.Models;

namespace FDAPIChallenge.Dto
{
    public class AircraftDto
    {
        public int AircraftId { get; set; }
        public AircraftTasks? AircraftTasks { get; set; }
    }
}
