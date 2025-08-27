using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NewApp.SEOs
{
    public interface ISeoSettingAppService:IApplicationService
    {

        Task<SEOSettingDto> CreateAsync(CreateSEOSettingDto input);
        Task<SEOSettingDto> UpdateAsync(CreateSEOSettingDto input , Guid id);
        Task DeleteAsync(Guid id);
        Task<SEOSettingDto> GetAsync(Guid id);
        Task<PagedResultDto<SEOSettingDto>> GetAllAsync(SEOSettingInput input);
        

    }
}
