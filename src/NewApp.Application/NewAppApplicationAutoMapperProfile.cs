using AutoMapper;
using NewApp.Generals;
using NewApp.Languages;

namespace NewApp;

public class NewAppApplicationAutoMapperProfile : Profile
{
    public NewAppApplicationAutoMapperProfile()
    {

        CreateMap<Language, LanguageDto>().ReverseMap();
        CreateMap<CreateLanguageDto, Language>();
        CreateMap<LanguageDto, Language>();


        CreateMap<GeneralSetting, GeneralSettingDto>().ReverseMap();
        CreateMap<CreateGeneralSettingDto,GeneralSetting>();
       
        /* You can configure your AutoMapper mapping configuration here.
         * Alternatively, you can split your mapping configurations
         * into multiple profile classes for a better organization. */
    }
}
