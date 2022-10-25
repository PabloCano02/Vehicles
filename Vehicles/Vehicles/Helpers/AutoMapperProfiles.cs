using AutoMapper;
using Vehicles.DTOs;
using Vehicles.Entities;

namespace Vehicles.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<Brand, BrandDTO>().ReverseMap(); 
            CreateMap<BrandCreationDTO, Brand>();

            CreateMap<DocumentType, DocumentTypeDTO>().ReverseMap();
            CreateMap<DocumentTypeCreationDTO, DocumentType>();

            CreateMap<Procedure, ProcedureDTO>().ReverseMap();
            CreateMap<ProcedureCreationDTO, Procedure>();

            CreateMap<VehicleType, VehicleTypeDTO>().ReverseMap();
            CreateMap<VehicleTypeCreationDTO, VehicleType>();
        }
    }
}
