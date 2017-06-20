using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            // Domain to Dto
           CreateMap<Customer, CustomerDto>();  
            // Dto to Domain
           CreateMap<CustomerDto, Customer>();

            

        }
    }
}