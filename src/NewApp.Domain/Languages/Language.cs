using NewApp.LanguagesType;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Entities.Auditing;

namespace NewApp.Languages
{
    public class Language :AuditedAggregateRoot<Guid>
    {

        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        public FontType Font  {  get; set; }
        [Required]
        
        public CultureName Culture { get; set; }
        [Required]
        public bool IsDefault { get; set; }

    }
}
