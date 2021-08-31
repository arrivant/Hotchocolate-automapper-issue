using System.Linq;
using AutoMapper;
using HC_Automapper_Issue.Domains.Models;

namespace HC_Automapper_Issue.Domains
{
    public class MappingProfiles
    {
        public class AddressMappingProfile : Profile
        {
            public AddressMappingProfile()
            {
                CreateMap<Address, AddressDto>()
                    .ForMember(dto => dto.Id, expression => expression.MapFrom(x => x.Id))
                    .ForMember(dto => dto.UnitId, expression => expression.MapFrom(x => x.UnitId))
                    .ForMember(dto => dto.StreetName, expression => expression.MapFrom(x => x.PostalCode))
                    .ForMember(dto => dto.StreetNumber, expression => expression.MapFrom(x => x.PostalCode))
                    .ForMember(dto => dto.PostalCode, expression => expression.MapFrom(x => x.PostalCode))
                    .ForMember(dto => dto.PostalPlace, expression => expression.MapFrom(x => x.PostalPlace))
                    .ForMember(dto => dto.Guid, expression => expression.MapFrom(x => x.Guid))
                    .ForMember(dto => dto.Unit, expression => expression.MapFrom(x => x.Unit))
                    .MaxDepth(2).ReverseMap();
            }
        }

        public class UnitMappingProfile : Profile
        {
            public UnitMappingProfile()
            {
                CreateMap<Unit, UnitDto>()
                    .ForMember(dto => dto.Id, expression => expression.MapFrom(x => x.Id))
                    .ForMember(dto => dto.Number, expression => expression.MapFrom(x => x.Number))
                    .ForMember(dto => dto.Name, expression => expression.MapFrom(x => x.Name))
                    .ForMember(dto => dto.Description, expression => expression.MapFrom(x => x.Description))
                    .ForMember(dto => dto.Guid, expression => expression.MapFrom(x => x.Guid))
                    .ForMember(dto => dto.Person, expression => expression.MapFrom(x => x.Person))
                    .ForMember(dto => dto.Addresses, expression => expression.MapFrom(x => x.Addresses.Select(e=>e)))
                    .MaxDepth(2).ReverseMap();
            }
        }

        public class PersonMappingProfile : Profile
        {
            public PersonMappingProfile()
            {
                CreateMap<Person, PersonDto>()
                    .ForMember(dto => dto.UnitId, expression => expression.MapFrom(x => x.UnitId))
                    .ForMember(dto => dto.FirstName, expression => expression.MapFrom(x => x.FirstName))
                    .ForMember(dto => dto.LastName, expression => expression.MapFrom(x => x.LastName))
                    .ForMember(dto => dto.BirthDate, expression => expression.MapFrom(x => x.BirthDate))
                    .ForMember(dto => dto.Sex, expression => expression.MapFrom(x => x.Sex))
                    .ForMember(dto => dto.Unit, expression => expression.MapFrom(x => x.Unit))
                    .ForMember(dto => dto.Other, expression => expression.MapFrom(x => x.Other))
                    .MaxDepth(2).ReverseMap();
            }
        }

        public class EmploymentMappingProfile : Profile
        {
            public EmploymentMappingProfile()
            {
                CreateMap<Employment, EmploymentDto>()
                    .ForMember(dto => dto.Id, expression => expression.MapFrom(x => x.Id))
                    .ForMember(dto => dto.EmployeeId, expression => expression.MapFrom(x => x.EmployeeId))
                    .ForMember(dto => dto.PositionId, expression => expression.MapFrom(x => x.PositionId))
                    .ForMember(dto => dto.FromDate, expression => expression.MapFrom(x => x.FromDate))
                    .ForMember(dto => dto.ToDate, expression => expression.MapFrom(x => x.ToDate))
                    .ForMember(dto => dto.Description, expression => expression.MapFrom(x => x.Description))
                    .ForMember(dto => dto.Guid, expression => expression.MapFrom(x => x.Guid))
                    .ForMember(dto => dto.Position, expression => expression.MapFrom(x => x.Position))
                    .MaxDepth(2).ReverseMap();
            }
        }

        public class PositionMappingProfile : Profile
        {
            public PositionMappingProfile()
            {
                CreateMap<Position, PositionDto>()
                    .ForMember(dto => dto.Id, expression => expression.MapFrom(x => x.Id))
                    .ForMember(dto => dto.Number, expression => expression.MapFrom(x => x.Number))
                    .ForMember(dto => dto.Name, expression => expression.MapFrom(x => x.Name))
                    .ForMember(dto => dto.Description, expression => expression.MapFrom(x => x.Description))
                    .ForMember(dto => dto.OtherField, expression => expression.MapFrom(x => x.OtherField))
                    .ForMember(dto => dto.Employments,
                        expression => expression.MapFrom(x => x.Employments.Select(e => e)))
                    .MaxDepth(2).ReverseMap();
            }
        }
    }
}