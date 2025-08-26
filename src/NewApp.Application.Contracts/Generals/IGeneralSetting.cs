using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NewApp.Generals
{
    public interface IGeneralSetting:IApplicationService
    {

        Task <GeneralSettingDto> CreateGeneralSettingAsync(CreateGeneralSettingDto dto);
        Task<PagedResultDto<GeneralSettingDto>> GetAllGeneralSettingsAsync(PagedAndSortedResultRequestDto input);

        Task DeleteGeneralSettingAsync(Guid id);
        Task<GeneralSettingDto> UpdateGeneralSettingAsync(CreateGeneralSettingDto input , Guid id);

        Task<GeneralSettingDto> GetGeneralSettingAsync(Guid id);


    }
}
