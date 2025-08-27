using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace NewApp.SEO
{
    public class SEOSetting :AuditedAggregateRoot<Guid>,IMultiTenant
    {
        public SEOSetting()
        {
            
        }

        public SEOSetting(Guid id,string metaTitle ,string metaKeyWords,string metaDescription,bool metaIndex,bool metaFollow,int metaPriority  ):base(id)
        {

            this.MetaTitle = metaTitle;
            this.MetaKeyWords = metaKeyWords;
            this.MetaDescription = metaDescription;
            this.MetaIndex = metaIndex;
            this.MetaFollow = metaFollow;
            this.MetaPriority = metaPriority;

            
        }

        public string MetaTitle { get; set; }

        public string MetaKeyWords { get; set; }

        public string MetaDescription { get; set; }

        public bool MetaIndex {  get; set; }
        public bool MetaFollow {  get; set; }
        public int MetaPriority { get; set; }

        public Guid? TenantId { get; set; }
    }
}
