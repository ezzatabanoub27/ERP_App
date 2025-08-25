using AutoMapper;
using JetBrains.Annotations;
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
        private readonly IMapper _mapper;

        public LanguageAppService (IRepository<Language,Guid> languageRepository,IMapper mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public async Task<LanguageDto> createLanguageAsync(CreateLanguageDto languageDto)
        {
            var languages = _mapper.Map<CreateLanguageDto,Language>(languageDto);

            var createdLanguage = await _languageRepository.InsertAsync(languages);


            return _mapper.Map<Language,LanguageDto>(languages);

        }
        [RemoteService]


        public async Task DeleteLanguageAsync(Guid languageId)
        {

            await _languageRepository.DeleteAsync(languageId);
        }
        [RemoteService]
        public async Task<PagedResultDto<LanguageDto>> GetAllLanguagesAsync(PagedAndSortedResultRequestDto input)
        {
            var totalCount = await _languageRepository.CountAsync();
            var items = await _languageRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount,input.Sorting);

            var result = _mapper.Map<List<Language>,List<LanguageDto>>(items);

            return new PagedResultDto<LanguageDto>(totalCount, result);




        }


        public Task updateLanguageAsync(Guid languageId, CreateLanguageDto input)
        {
            throw new NotImplementedException();
        }
    }
}
