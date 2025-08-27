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
    public class GeneralSettingAppService : ApplicationService, IGeneralSettingAppService
    {
        private readonly IRepository<GeneralSetting,Guid> _generalSettingRepository;
        private readonly IGeneralSettingRepository _generalSettingRepository1;


        public GeneralSettingAppService(IRepository<GeneralSetting,Guid> generalSettingRepository ,IGeneralSettingRepository generalSettingRepository1)
        {
            _generalSettingRepository = generalSettingRepository;
            _generalSettingRepository1 = generalSettingRepository1;
        }


        public async Task<GeneralSettingDto> CreateGeneralSettingAsync(CreateGeneralSettingDto dto)
        {

            var converted = ObjectMapper.Map<CreateGeneralSettingDto ,GeneralSetting>(dto);
            var generalSetting = await _generalSettingRepository.InsertAsync(converted);
            return ObjectMapper.Map<GeneralSetting,GeneralSettingDto>(generalSetting);   

        }

        public async Task DeleteGeneralSettingAsync(Guid id)
        {

            await _generalSettingRepository.DeleteAsync(id);
        }

        public async Task<GeneralSettingDto> GetGeneralSettingAsync(Guid id)
        {

            var generalSetting = await _generalSettingRepository.GetAsync(id);
            return ObjectMapper.Map<GeneralSetting,GeneralSettingDto>(generalSetting);
        }

        public async Task<PagedResultDto<GeneralSettingDto>> GetAllGeneralSettingsAsync(PagedAndSortedResultRequestDto input)
        {
            var totalCount = await _generalSettingRepository.CountAsync();
            var items = await _generalSettingRepository.GetPagedListAsync( input.SkipCount,input.MaxResultCount, input.Sorting);

            var result = ObjectMapper.Map<List<GeneralSetting>, List<GeneralSettingDto>>(items);

            return new PagedResultDto<GeneralSettingDto>(totalCount,result);
        }

        public async Task<GeneralSettingDto> UpdateGeneralSettingAsync(CreateGeneralSettingDto input, Guid id)
        {

            var item = await _generalSettingRepository.GetAsync(id);

            ObjectMapper.Map(input,item);

            var updated = await _generalSettingRepository.UpdateAsync(item);

            return ObjectMapper.Map<GeneralSetting,GeneralSettingDto>(updated);

        }
    }
}
