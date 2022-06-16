using FDAPIChallenge.Dto;
using FDAPIChallenge.Models;
using AutoMapper;

namespace FDAPIChallenge.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Aircraft, AircraftDto>();
            CreateMap<AircraftTask, AircraftTaskDto>();
            CreateMap<AircraftTasks, AircraftTasksDto>();
        }
    }
}