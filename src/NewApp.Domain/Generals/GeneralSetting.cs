using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace NewApp.Generals
{
    public class GeneralSetting:AuditedAggregateRoot<Guid>,IMultiTenant
    {

        public GeneralSetting(Guid id,string pageTitle , string slug , string content , DateTime publishDate,bool hideFromMenue):base(id)
        {
            PageTitle = pageTitle;
            Slug = slug;    
            Content= content;
            PublishDate = publishDate;
            HideFromMenue = hideFromMenue;
        }

        public GeneralSetting()
        {
            
        }
        public string PageTitle { get; set; }

        public string Slug { get; set; }

        public string Content { get; set; }

        public DateTime PublishDate { get; set; }

        public bool HideFromMenue { get; set; }

        public Guid? TenantId { get; set; }

    }
}
