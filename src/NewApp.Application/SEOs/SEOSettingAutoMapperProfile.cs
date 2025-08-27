using AutoMapper;
using NewApp.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.SEOs
{
    public class SEOSettingAutoMapperProfile :Profile
    {

        public SEOSettingAutoMapperProfile()
        {
            CreateMap<SEOSetting,SEOSettingDto>();  
            CreateMap<CreateSEOSettingDto,SEOSetting>();
            CreateMap<SEOSettingDto, SEOSetting>();
        }
    }
}
