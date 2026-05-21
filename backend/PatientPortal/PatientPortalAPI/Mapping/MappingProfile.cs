using AutoMapper;
using PatientPortalAPI.DTOs;
using PatientPortalAPI.Models;

namespace PatientPortalAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Patient, PatientDto>().ReverseMap();
            // Additional mappings can be added here if DTOs exist for other entities
        }
    }
}
