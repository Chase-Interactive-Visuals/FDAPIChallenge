using FDAPIChallenge.Data;
using FDAPIChallenge.Interfaces;
using FDAPIChallenge.Models;

namespace FDAPIChallenge.Repository
{
    public class AircraftRepository : IAircraftRepository
    {
        private readonly DataContext _context;

        public AircraftRepository(DataContext context)
        {
            _context = context;
        }

        public bool AircraftExist(int aircraftID)
        {
            return _context.Aircrafts.Any(a => a.AircraftId == aircraftID);
        }

        public bool CreateAircraft(Aircraft aircraft)
        {
            _context.Add(aircraft);
            return Save();
        }

        public Aircraft GetAircraftById(int id)
        {
            return _context.Aircrafts.Where(a => a.AircraftId == id).FirstOrDefault();
        }

        public ICollection<Aircraft> GetAircrafts()
        {
            return _context.Aircrafts.OrderBy(a => a.AircraftId).ToList();
        }


        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
 
    }
}
