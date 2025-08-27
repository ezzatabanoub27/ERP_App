using AutoMapper;
using JetBrains.Annotations;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewApp.Languages
{

    [RemoteService]
    public class LanguageAppService : ApplicationService, ILanguageAppService
    {
        private readonly IRepository<Language,Guid> _languageRepository;
        private readonly LanguageManager _languageManager;


        public LanguageAppService (IRepository<Language,Guid> languageRepository,LanguageManager languageManager)
        {
            _languageRepository = languageRepository;
            _languageManager = languageManager;
        }

        public async Task<LanguageDto> createLanguageAsync(CreateLanguageDto languageDto)
        {
            //var languages = ObjectMapper.Map<CreateLanguageDto,Language>(languageDto);

            //var createdLanguage = await _languageRepository.InsertAsync(languages);


            //return ObjectMapper.Map<Language,LanguageDto>(languages);

            var language = await _languageManager.CretaeAsync(languageDto.Title, languageDto.Font, languageDto.Culture, languageDto.IsDefault);
            return ObjectMapper.Map<Language,LanguageDto>(language);

        }
        [RemoteService]


        public async Task DeleteLanguageAsync(Guid languageId)
        {

            await _languageManager.DeleteAsync(languageId);
        }
        [RemoteService]
        public async Task<PagedResultDto<LanguageDto>> GetAllLanguagesAsync([FromQuery]LanguageInput input)
        {
            var totalCount = await _languageRepository.CountAsync();
            var items = await _languageRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);

            var result = ObjectMapper.Map<List<Language>,List<LanguageDto>>(items);

            return new PagedResultDto<LanguageDto>(totalCount, result);




        }


        public Task updateLanguageAsync(Guid languageId, CreateLanguageDto input)
        {
            throw new NotImplementedException();
        }
    }
}
