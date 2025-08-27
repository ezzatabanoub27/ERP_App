using NewApp.LanguagesType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;

namespace NewApp.Languages
{
    public class Language :AuditedAggregateRoot<Guid>,IMultiTenant
    {
        public Language(Guid id,string title , FontType font ,CultureName culture,bool isDefault ):base(id)
        {
            Title=title;
            Font =font;
            Culture = culture;
            IsDefault=IsDefault;



        }
        public Language()
        {

        }


        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public FontType Font  {  get; set; }
        [Required]
        
        public CultureName Culture { get; set; }
        [Required]
        public bool IsDefault { get; set; }

        public Guid? TenantId { get; set; }
    }
}
