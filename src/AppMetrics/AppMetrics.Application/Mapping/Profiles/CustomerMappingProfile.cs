using AppMetrics.DAL.Entities;
using AppMetrics.Infrastructure.Contracts;
using AutoMapper;

namespace AppMetrics.Application.Mapping.Profiles
{
    public class CustomerMappingProfile : Profile
    {
        public CustomerMappingProfile()
        {
            CreateMap<Customer, CustomerResponse>();
        }
    }
}
