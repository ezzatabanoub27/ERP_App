using NewApp.LanguagesType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NewApp.Languages
{
    public class LanguageDto:EntityDto<Guid>
    {

        public string Title { get; set; }
        public FontType Font { get; set; }
        public CultureName Culture { get; set; }
        public bool IsDefault { get; set; }



    }
}
