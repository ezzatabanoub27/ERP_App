using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace NewApp.Languages
{
    public interface ILanguageAppService:IApplicationService
    {

        Task <PagedResultDto<LanguageDto>> GetAllLanguagesAsync(LanguageInput input);

        Task<LanguageDto> createLanguageAsync (CreateLanguageDto languageDto);

        Task updateLanguageAsync(Guid languageId, CreateLanguageDto input);
        Task DeleteLanguageAsync (Guid languageId);



    }
}
