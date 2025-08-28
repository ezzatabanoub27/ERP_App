using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace NewApp.SEO
{
    public interface ISEOSettingRepository
    {


        Task<List<SEOSetting>> GetListAsync(string? filter = null, int? skipCount = 0,
            int? maxResultCount = int.MaxValue, string? sorting = null, string? metaTitle = null,
            string? metaKeyWords = null, string? metaDescription = null, bool? metaIndex = null,
            bool? metaFollow =null, int? metaPriority=0,CancellationToken cancellationToken=default);

        Task<long> GetCountAsync(string? filter = null,
              string? metaTitle = null,
            string? metaKeyWords = null, string? metaDescription = null, bool? metaIndex = null,
            bool? metaFollow = null, int? metaPriority = 0, CancellationToken cancellationToken = default);

    }
}
