using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewApp.Generals;
using NewApp.SEOs;
using System.Threading.Tasks;

namespace NewApp.Web.Pages.Generals
{
    public class CreateModel : NewAppPageModel
    {
        private readonly IGeneralSettingAppService _generalSetting;

        private readonly ISeoSettingAppService _seoSetting;

        public CreateModel(IGeneralSettingAppService generalSetting ,ISeoSettingAppService seoSetting)
        {
            _generalSetting = generalSetting;
            _seoSetting = seoSetting;
        }

        [BindProperty]
        public CreateGeneralSettingDto GeneralSetting { get; set; }

        public CreateSEOSettingDto SeoSetting { get; set; }

        public void OnGet()
        {
            GeneralSetting = new CreateGeneralSettingDto();
            SeoSetting = new CreateSEOSettingDto();
        }

        public async Task<IActionResult> OnPostCreateGeneralAsync(CreateGeneralSettingDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _generalSetting.CreateGeneralSettingAsync(input);

            return new JsonResult(new { success = true });
        }

        public async Task<IActionResult> OnPostCreateSeoAsync(CreateSEOSettingDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);


            }
            await _seoSetting.CreateAsync(input);
            return new JsonResult(new {success=true});

        }
    }
}
