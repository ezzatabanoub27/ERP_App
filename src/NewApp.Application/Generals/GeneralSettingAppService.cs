using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewApp.Generals
{
    public class GeneralSettingAppService : ApplicationService, IGeneralSetting
    {
        private readonly IRepository<GeneralSetting,Guid> _generalSettingRepository;

        private readonly IMapper _mapper;

        public GeneralSettingAppService(IRepository<GeneralSetting,Guid> generalSettingRepository , IMapper mapper)
        {
            _generalSettingRepository = generalSettingRepository;
            _mapper = mapper;
        }


        public async Task<GeneralSettingDto> CreateGeneralSettingAsync(CreateGeneralSettingDto dto)
        {

            var converted = _mapper.Map<CreateGeneralSettingDto ,GeneralSetting>(dto);
            var generalSetting = await _generalSettingRepository.InsertAsync(converted);
            return _mapper.Map<GeneralSetting,GeneralSettingDto>(generalSetting);   

        }

        public async Task DeleteGeneralSettingAsync(Guid id)
        {

            await _generalSettingRepository.DeleteAsync(id);
        }

        public async Task<GeneralSettingDto> GetGeneralSettingAsync(Guid id)
        {

            var generalSetting = await _generalSettingRepository.GetAsync(id);
            return _mapper.Map<GeneralSetting,GeneralSettingDto>(generalSetting);
        }

        public async Task<PagedResultDto<GeneralSettingDto>> GetGeneralSettingListAsync(PagedAndSortedResultRequestDto input)
        {
            var totalCount = await _generalSettingRepository.CountAsync();
            var items = await _generalSettingRepository.GetPagedListAsync(input.MaxResultCount, input.SkipCount, input.Sorting);

            var result = _mapper.Map<List<GeneralSetting>, List<GeneralSettingDto>>(items);

            return new PagedResultDto<GeneralSettingDto>(totalCount, result);
        }

        public async Task<GeneralSettingDto> UpdateGeneralSettingAsync(CreateGeneralSettingDto input, Guid id)
        {

            var item = await _generalSettingRepository.GetAsync(id);

            _mapper.Map(input,item);

            var updated = await _generalSettingRepository.UpdateAsync(item);

            return _mapper.Map<GeneralSetting,GeneralSettingDto>(updated);

        }
    }
}
