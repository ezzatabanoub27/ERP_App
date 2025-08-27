using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using NewApp.Generals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace NewApp.Controllers.GeneralSetting
{
    [Route("api/app/general-setting")]

    [ApiController]
    public class GeneralSettingController : AbpController,IGeneralSettingAppService
    {
        private readonly IGeneralSettingAppService _generalSettingAppService;

        public GeneralSettingController(IGeneralSettingAppService generalSettingAppService)
        {
            _generalSettingAppService = generalSettingAppService;
        }



        [HttpPost]
        public Task<GeneralSettingDto> CreateGeneralSettingAsync(CreateGeneralSettingDto dto)
        {

            return _generalSettingAppService.CreateGeneralSettingAsync(dto);
            
        }

        [HttpDelete("{id}")]
        public async Task DeleteGeneralSettingAsync(Guid id)
        {

            await _generalSettingAppService.DeleteGeneralSettingAsync(id);

        }
        [HttpGet]
        public  Task<PagedResultDto<GeneralSettingDto>> GetAllGeneralSettingsAsync([FromQuery]PagedAndSortedResultRequestDto input)
        {

            return _generalSettingAppService.GetAllGeneralSettingsAsync(input);
        }
        [HttpGet("{id}")] 
        public  Task<GeneralSettingDto> GetGeneralSettingAsync(Guid id)
        {
             return _generalSettingAppService.GetGeneralSettingAsync(id);

        }
        [HttpPut("{id}")]
        public  Task<GeneralSettingDto> UpdateGeneralSettingAsync(CreateGeneralSettingDto input, Guid id)
        {
            return _generalSettingAppService.UpdateGeneralSettingAsync(input, id);
            
        }
    }
}
