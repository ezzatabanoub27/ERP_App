using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NewApp.SEOs
{
    public class SEOSettingInput:PagedAndSortedResultRequestDto
    {


        public string? MetaTitle { get; set; }

        public string? MetaKeyWords { get; set; }

        public string? MetaDescription { get; set; }

        public bool? MetaIndex { get; set; }
        public bool? MetaFollow { get; set; }
        public int? MetaPriority { get; set; }

    }
}
