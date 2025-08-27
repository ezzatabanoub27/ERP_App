using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NewApp.Generals
{
    public class GeneralSettingDto:EntityDto<Guid>
    {
        public string PageTitle { get; set; }
        public string Slug { get; set; }
        public string Content { get; set; }
        public DateTime PublishDate { get; set; }
        public bool HideFromMenue { get; set; }



    }
}
