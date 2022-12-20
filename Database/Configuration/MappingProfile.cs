using AutoMapper;
using Database.Data.Entities;
using Database.Models;

namespace Database.Configuration
{
    public class MappingProfile : Profile
    {
        public MappingProfile() 
        {
            CreateMap<BudgetDto, Budget>();
        }
    }
}
