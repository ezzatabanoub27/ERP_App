using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.SEOs
{
    public class CreateSEOSettingDto
    {
        [Required]
        public string MetaTitle { get; set; }
        [Required]


        public string MetaKeyWords { get; set; }
        [Required]


        public string MetaDescription { get; set; }
        [Required]


        public bool MetaIndex { get; set; }
        [Required]

        public bool MetaFollow { get; set; }
        [Required]

        public int MetaPriority { get; set; }


    }
}
