using AppMetrics.DAL.Entities;
using AppMetrics.Infrastructure.Contracts;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppMetrics.Application.Mapping.Profiles
{
    public class OrderMappingProfile : Profile
    {
        public OrderMappingProfile()
        {
            CreateMap<Order, OrderResponse>();
        }
    }
}
