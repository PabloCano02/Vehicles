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

            CreateMap<Detail, DetailDTO>().ReverseMap();
            CreateMap<DetailCreationDTO, Detail>();

            CreateMap<DocumentType, DocumentTypeDTO>().ReverseMap();
            CreateMap<DocumentTypeCreationDTO, DocumentType>();

            CreateMap<History, HistoryDTO>().ReverseMap();
            CreateMap<HistoryCreationDTO, History>();

            CreateMap<Procedure, ProcedureDTO>().ReverseMap();
            CreateMap<ProcedureCreationDTO, Procedure>();

            CreateMap<Vehicle, VehicleDTO>().ReverseMap();
            CreateMap<VehicleCreationDTO, Vehicle>();

            CreateMap<VehiclePhoto, VehiclePhotoDTO>().ReverseMap();
            CreateMap<VehiclePhotoCreationDTO, VehiclePhoto>();

            CreateMap<VehicleType, VehicleTypeDTO>().ReverseMap();
            CreateMap<VehicleTypeCreationDTO, VehicleType>();
        }
    }
}
