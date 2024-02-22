using AutoMapper;
using Oasis.ToDoAPP.API.DTOs;
using Oasis.ToDoAPP.API.Entities;

namespace API.Helpers
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<ToDo, ToDoDto>();
            CreateMap<ToDoDto, ToDo>();
            CreateMap<RegisterDto, AppUser>();
        }
    }
}
