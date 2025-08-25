using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace NewApp.Generals
{
    public class GeneralSetting:AuditedAggregateRoot<Guid>
    {

        public string PageTitle { get; set; }

        public string Slug { get; set; }


        public DateTime PublishDate { get; set; }

        public bool HideFromMenue { get; set; }




    }
}
