using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.Languages
{
    public class LanguagesAutoMapperProfile :Profile
    {

        public LanguagesAutoMapperProfile() 
        { 

            CreateMap<Language,LanguageDto>();
            CreateMap<CreateLanguageDto, Language>();
            CreateMap<LanguageDto, Language>();
                
        
        
        } 
    }
}
