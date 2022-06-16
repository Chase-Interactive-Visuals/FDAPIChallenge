using FDAPIChallenge.Interfaces;
using FDAPIChallenge.Models;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using FDAPIChallenge.Dto;
using System.Text.Json;

namespace FDAPIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftController : Controller
    {
        private readonly IAircraftRepository _aircraftRepository;
        //private readonly IAircraftTaskRepository _aircraftTasksRepository;

        private readonly Mapper _mapper;
        

        public AircraftController(IAircraftRepository aircraftRepository)
        {
            _aircraftRepository = aircraftRepository;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Aircraft>))]
        public IActionResult GetAircrafts()
        {
            var aircrafts = _aircraftRepository.GetAircrafts();
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(aircrafts);
        }
        [HttpGet("/aircraft/{aircraftId}/duelist")]
        [ProducesResponseType(200, Type = typeof(Aircraft))]
        public IActionResult GetAircraft(int aircraftID)
        {
            if (!_aircraftRepository.AircraftExist(aircraftID))
                return NotFound();

            var aircraft = _aircraftRepository.GetAircraftById(aircraftID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(aircraft);
        }

        
        [HttpPost("/aircraft/{aircraftId}/duelist")]
        [ProducesResponseType(200, Type = typeof(Aircraft))]
        [ProducesResponseType(400)]
        public async Task<ActionResult<List<AircraftTasks>>> PostAircraft(int aircraftId, [FromBody] AircraftTasks tasks)
        {
            if (tasks == null)
                return BadRequest(ModelState);

            if (!_aircraftRepository.AircraftExist(aircraftId))
                return NotFound();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            
            AircraftTasks _tasks = new AircraftTasks();
            _tasks = tasks;
            //var myTasks = _aircraftTasksRepository.CreateAircraftTasks(tasks);
            var aircraft = _aircraftRepository.GetAircraftById(aircraftId);
            aircraft.AircraftTasks = _tasks;
            await CalculateNextDueDate(aircraft);

            return Ok(await SortListASC2(_tasks.AricraftTaskSet));
        }

        private async Task<Aircraft> SortListASC(Aircraft aircraft)
        {
            aircraft.AircraftTasks.AricraftTaskSet.OrderByDescending(i => i.NextDue.HasValue)
                .ThenBy(i => i.NextDue)
                .ThenBy(i => i.Description);


            return aircraft;
        }

        private async Task<List<AircraftTask>> SortListASC2(List<AircraftTask> listToSort)
        {
            List<AircraftTask> orderedList = new List<AircraftTask>(listToSort
                .OrderByDescending(i => i.NextDue.HasValue)
                .ThenBy(i => i.NextDue)
                .ThenBy(i => i.Description));

            return orderedList;
        }

        private async Task CalculateNextDueDate(Aircraft aircraft)
        {
            DateTime? IntervalMonthsNextDueDate;
            double? DaysRemainingByHoursInterval;
            DateTime? IntervalHoursNextDueDate;
            DateTime? NextDueDate;
            DateTime today = new DateTime(2018, 06, 19);

            foreach (AircraftTask t in aircraft.AircraftTasks.AricraftTaskSet)
            {
                if (t.IntervalMonths.HasValue && t.LogDate != null)
                {
                    IntervalMonthsNextDueDate = t.LogDate.AddMonths(t.IntervalMonths.Value);
                }
                else
                {
                    IntervalMonthsNextDueDate = null;
                }
                DaysRemainingByHoursInterval = ((t.LogHours + t.IntervalHours) - aircraft.CurrentHours) / aircraft.DailyHours;

                if (DaysRemainingByHoursInterval.HasValue)
                {
                    IntervalHoursNextDueDate = today.Date.AddDays(DaysRemainingByHoursInterval.Value);
                }
                else
                {
                    IntervalHoursNextDueDate = null;
                }


                if (IntervalMonthsNextDueDate.HasValue && IntervalHoursNextDueDate.HasValue)
                {
                    int value = DateTime.Compare(IntervalMonthsNextDueDate.Value, IntervalHoursNextDueDate.Value);
                    if (value > 0)
                    {
                        t.NextDue = IntervalHoursNextDueDate;
                    }
                    else if (value <= 0)
                    {
                        t.NextDue = IntervalMonthsNextDueDate;
                    }
                }
                else if (IntervalMonthsNextDueDate.HasValue && IntervalHoursNextDueDate == null)
                {
                    t.NextDue = IntervalMonthsNextDueDate.Value;
                }
                else if (IntervalMonthsNextDueDate == null && IntervalHoursNextDueDate.HasValue)
                {
                    t.NextDue = IntervalHoursNextDueDate.Value;
                }
                else
                {
                    t.NextDue = null;
                }
            }
            return;
        }

    }
}


