using AutoMapper;
using Calendar.DataAccess.Entities;
using FamilyCalendar.Calendar.Core.Models;

namespace FamilyCalendar.Mapping
{
    public class DataBaseMappings : Profile
    {
        public DataBaseMappings()
        {
            CreateMap<UserEntity, User>();
        }
    }
}
