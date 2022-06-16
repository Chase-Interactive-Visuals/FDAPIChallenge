using AutoMapper;
using FDAPIChallenge.Dto;
using FDAPIChallenge.Interfaces;
using FDAPIChallenge.Models;
using Microsoft.AspNetCore.Mvc;

namespace FDAPIChallenge.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AircraftTaskController : Controller
    {

        private readonly IAircraftTaskRepository _aircraftTaskRepository;
        private readonly IMapper _mapper;

        public AircraftTaskController(IAircraftTaskRepository aircraftTaskRepository, IMapper mapper)
        {
            _aircraftTaskRepository = aircraftTaskRepository;
            _mapper = mapper;
        }

        /*
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Aircraft>))]
        public IActionResult GetAircraftTasks(int aircraftID)
        {
            var aircraftTasks = _mapper.Map<List<AircraftTaskDto>>(_aircraftTaskRepository.GetAircraftTasks(aircraftID));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(aircraftTasks);
        }
        */

    }
}
