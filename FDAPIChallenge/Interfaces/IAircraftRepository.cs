using FDAPIChallenge.Models;

namespace FDAPIChallenge.Interfaces
{
    public interface IAircraftRepository
    {
        ICollection<Aircraft> GetAircrafts();
        Aircraft GetAircraftById(int id);
        bool AircraftExist(int aircraftID);
        bool CreateAircraft(Aircraft aircraft);
        bool Save();
    }
}
