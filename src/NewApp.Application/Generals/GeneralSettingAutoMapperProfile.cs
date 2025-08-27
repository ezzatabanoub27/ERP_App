using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.Generals
{
    public class GeneralSettingAutoMapperProfile:Profile
    {

        public GeneralSettingAutoMapperProfile()
        {
            CreateMap<GeneralSetting,GeneralSettingDto>().ReverseMap();
            CreateMap<CreateGeneralSettingDto, GeneralSetting>();
        }

    }
}
