using Microsoft.AspNetCore.Mvc;
using NewApp.Languages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace NewApp.Controllers.Language
{
    [Route("api/app/language")]

    [ApiController]
    public class LanguagesControler : AbpController, ILanguageAppService
    {
        private readonly ILanguageAppService _service;
        public LanguagesControler(ILanguageAppService srvice)
        {
            _service = srvice;
        }

        [HttpPost]
        public Task<LanguageDto> createLanguageAsync(CreateLanguageDto languageDto)
        {
            return _service.createLanguageAsync(languageDto);
        }
        [HttpDelete("{languageId}")]
        public async Task DeleteLanguageAsync(Guid languageId)
        {

            await _service.DeleteLanguageAsync(languageId);
        }
        [HttpGet]
        public Task<PagedResultDto<LanguageDto>> GetAllLanguagesAsync(LanguageInput input)
        {
            return _service.GetAllLanguagesAsync(input);
        }

        [HttpPut("{languageId}")]
        public Task updateLanguageAsync(Guid languageId, CreateLanguageDto input)
        {

            return _service.updateLanguageAsync(languageId, input);
        }
    }
}
