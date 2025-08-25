using AutoMapper;
using NewApp.Languages;

namespace NewApp;

public class NewAppApplicationAutoMapperProfile : Profile
{
    public NewAppApplicationAutoMapperProfile()
    {

        CreateMap<Language, LanguageDto>().ReverseMap();
        CreateMap<CreateLanguageDto, Language>();
        CreateMap<LanguageDto, Language>();
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
