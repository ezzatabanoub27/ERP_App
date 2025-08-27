using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using NewApp.Languages;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;

namespace NewApp.Web.Pages.Languages
{
    public class IndexModel : PageModel
    {
        private readonly ILanguageAppService _lnguageAppService;

        public IndexModel(ILanguageAppService lnguageAppService)
        {
            _lnguageAppService = lnguageAppService;
        }

        public IReadOnlyList<LanguageDto> Languages { get; set; }

        public async Task OnGetAsync()
        {
            var result = await _lnguageAppService.GetAllLanguagesAsync(new LanguageInput
            {
                MaxResultCount = 1000
            });

            Languages = result.Items;
        }

        [IgnoreAntiforgeryToken]
        public async Task<IActionResult> OnPostCreateLanguageAsync([FromBody] CreateLanguageDto input)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await _lnguageAppService.createLanguageAsync(input);
            return new JsonResult(created);
        }
    }
}
