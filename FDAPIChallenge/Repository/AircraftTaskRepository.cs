using FDAPIChallenge.Data;
using FDAPIChallenge.Interfaces;
using FDAPIChallenge.Models;

namespace FDAPIChallenge.Repository
{
    public class AircraftTaskRepository : IAircraftTaskRepository
    {

        private readonly DataContext _context;

        public AircraftTaskRepository(DataContext context)
        {
            _context = context;
        }

        
        public bool AircraftTaskExists(int aircraftID)
        {
            return _context.AircraftTasks.Any(at => at.Id == aircraftID);
        }

        public bool CreateAircraftTasks(AircraftTasks aircraftTasks)
        {
            _context.Add(aircraftTasks);
            return Save();
        }

        public Aircraft GetAircraftTaskByItemNumber(int itemNumber)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
