using ARS_OS.Models;
using ARS_OS.Models.InputModels;
using ARS_OS.Models.OutputModels;
using AutoMapper;

namespace ARS_OS.AutoMapProfiles
{
    public class TripPlanAutoMapProfile : Profile
    {
        public TripPlanAutoMapProfile()
        {
            CreateMap<TripPlanInput, TripPlan>();
            CreateMap<TripPlan, TripPlanOutput>();
            CreateMap<TripPlanRequestInput, TripPlanRequest>();
        }
    }
}
