using AutoMapper;
using Fisher.Core.Data.Dtos;
using Fisher.Core.Domain;

namespace Fisher.Api.Mapper
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<NoteDto, Note>().ReverseMap();
            CreateMap<NotePackageDetailDto, NotePackage>().ForMember(n => n.Category,
                u => u.MapFrom(n => new Category() {Id = n.CategoryId}));
            CreateMap<NotePackage, NotePackageDto>().ForMember(n => n.Category,
                u => u.MapFrom(n => n.Category.Name));
            CreateMap<FavoriteNotePackage, FavoriteNoteDto>().ForMember(n => n.Category,
                u => u.MapFrom(n => n.Category.Name));
        }
    }
}