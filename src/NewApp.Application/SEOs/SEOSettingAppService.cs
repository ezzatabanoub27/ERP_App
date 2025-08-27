using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using NewApp.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace NewApp.SEOs
{
    [RemoteService]
    public class SEOSettingAppService : ApplicationService, ISeoSettingAppService
    {
        private readonly SEOManager _manager;
        private readonly IRepository<SEOSetting,Guid> _repository;


        public SEOSettingAppService(SEOManager manager , IRepository<SEOSetting,Guid>repository)
        {
            _manager = manager;
            _repository = repository;
            
        }

        public async Task<SEOSettingDto> CreateAsync(CreateSEOSettingDto input)
        {

            var seoSetting = await _manager.CreateAsync(input.MetaTitle,input.MetaDescription,input.MetaKeyWords,input.MetaIndex,input.MetaFollow,input.MetaPriority);

            return ObjectMapper.Map<SEOSetting,SEOSettingDto>(seoSetting);
        }

        public async Task DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);

        }

        public async Task<PagedResultDto<SEOSettingDto>> GetAllAsync([FromQuery]SEOSettingInput input)
        {
            var items = await _repository.GetListAsync(includeDetails: true);
            var totalCount = await _repository.GetCountAsync();

            return new PagedResultDto<SEOSettingDto>(totalCount,ObjectMapper.Map<List<SEOSetting>,List<SEOSettingDto>>(items));
        }

        public async Task<SEOSettingDto> GetAsync(Guid id)
        {

            return ObjectMapper.Map<SEOSetting,SEOSettingDto>(await _repository.GetAsync(id));
        }

        public async Task<SEOSettingDto> UpdateAsync(CreateSEOSettingDto input, Guid id)
        {

            var seo = await _repository.GetAsync(id);

            var UpdatedSeo = await _repository.UpdateAsync(seo);

            return ObjectMapper.Map<SEOSetting, SEOSettingDto>(seo);
            //var seUpdated = await _manager.UpdateAsync(new SEOSetting(input.MetaTitle,input.MetaDescription,input.MetaKeyWords,input.MetaIndex,input.MetaFollow,input.MetaPriority));
        }



    }
}
