using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;

namespace NewApp.SEO
{
    public class SEOManager :DomainService
    {
        private readonly IRepository<SEOSetting,Guid> _settingRepository;
        public SEOManager(IRepository<SEOSetting,Guid> settingRepository)
        {
            _settingRepository = settingRepository;
        }

        public async Task<SEOSetting>CreateAsync(string metaTitle, string metaKeyWords, string metaDescription, bool metaIndex, bool metaFollow, int metaPriority)
        {

            var seoSetting = new SEOSetting(GuidGenerator.Create(), metaTitle, metaKeyWords, metaDescription, metaIndex, metaFollow, metaPriority);
            return await _settingRepository.InsertAsync(seoSetting);

        }



        public async Task<SEOSetting> UpdateAsync(SEOSetting seoSetting)
        {
            return await _settingRepository.UpdateAsync(seoSetting);
        }


    }
}
