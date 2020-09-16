using Assignment.Contract.Core;
using Assignment.DAL.Core;
using AutoMapper;

namespace Assignment.Api.Core
{
    /// <summary>
    /// 
    /// </summary>
    /// <seealso cref="AutoMapper.Profile" />
    public class MappingProfile : Profile
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MappingProfile"/> class.
        /// </summary>
        public MappingProfile()
        {
            CreateMap<UserDTO, UserEntity>().ReverseMap();
            CreateMap<LabelDTO, LabelEntity>().ReverseMap();
            CreateMap<ToDoItemDTO, ToDoItemEntity>().ReverseMap();
            CreateMap<ToDoListDTO, ToDoListEntity>().ReverseMap();
        }
    }
}
