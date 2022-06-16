using FDAPIChallenge.Models;

namespace FDAPIChallenge.Interfaces
{
    public interface IAircraftTaskRepository
    {
        //AircraftTasks GetAircraftTasks(int aircraftID);
        Aircraft GetAircraftTaskByItemNumber(int itemNumber);
        
        bool AircraftTaskExists(int Id);
        bool CreateAircraftTasks(AircraftTasks aircraftTasks);
        bool Save();
        
        
    }
}
