using Microsoft.AspNetCore.Mvc;
using NewApp.SEOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;

namespace NewApp.Controllers.SEO
{
    [ApiController]
    [Route("api/app/SEOSetting")]
    public class SEOSettingController : AbpController, ISeoSettingAppService
    {
        private readonly ISeoSettingAppService _service;
        public SEOSettingController(ISeoSettingAppService service)
        {
            _service = service;
        }

        [HttpPost]
        public Task<SEOSettingDto> CreateAsync(CreateSEOSettingDto input)
        {
            return _service.CreateAsync(input);

        }
        [HttpDelete("{id}")]
        public async Task DeleteAsync(Guid id)
        {
            await _service.DeleteAsync(id);
            
        }
        [HttpGet]
        public Task<PagedResultDto<SEOSettingDto>> GetAllAsync(SEOSettingInput input)
        {
            return _service.GetAllAsync(input);
        }
        [HttpGet("{id}")]
        public Task<SEOSettingDto> GetAsync(Guid id)
        {
            return _service.GetAsync(id);
        }
        [HttpPut("{id}")]
        public async Task<SEOSettingDto> UpdateAsync(CreateSEOSettingDto input, Guid id)
        {

            return await _service.UpdateAsync(input, id);
        }
    }
}
