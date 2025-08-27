using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewApp.Generals
{
    public class CreateGeneralSettingDto
    {
        [Required]
        public string PageTitle { get; set; }
        [Required]
        public string Slug { get; set; }

        [Required]
        public string Content { get; set; }
        [Required]
        public DateTime PublishDate { get; set; }
        [Required]
        public bool HideFromMenue { get; set; }




    }
}
