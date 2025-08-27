using NewApp.EntityFrameworkCore;
using NewApp.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NewApp.SEOs
{
    public class EfCoreSEOSettingRepository : EfCoreRepository<NewAppDbContext, SEOSetting, Guid>, ISEOSettingRepository
    {
        public EfCoreSEOSettingRepository(IDbContextProvider<NewAppDbContext> dbContextProvider) : base(dbContextProvider)
        {


        }

        public Task<long> GetCountAsync(string? filter = null, string? metaTitle = null, string? metaKeyWords = null, string? metaDescription = null, bool? metaIndex = null, bool? metaFollow = null, int? metaPriority = 0, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<List<SEOSetting>> GetSettingAsync(string? filter = null, int? skipCount = 0, int? maxResultCount = int.MaxValue, string? sorting = null, string? metaTitle = null, string? metaKeyWords = null, string? metaDescription = null, bool? metaIndex = null, bool? metaFollow = null, int? metaPriority = 0, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
