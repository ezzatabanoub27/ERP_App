using Microsoft.EntityFrameworkCore;
using NewApp.EntityFrameworkCore;
using NewApp.SEO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
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

        public async Task<long> GetCountAsync(string? filter = null, string? metaTitle = null, string? metaKeyWords = null, string? metaDescription = null, bool? metaIndex = null, bool? metaFollow = null, int? metaPriority = 0, CancellationToken cancellationToken = default)
        {
            var dbSet = await GetDbSetAsync();

            var query = ApplyFilter(dbSet, filter, metaTitle, metaKeyWords, metaDescription, metaIndex, metaFollow, metaPriority);

            return await query.LongCountAsync(cancellationToken);
        }        

        

      public async Task<List<SEOSetting>> GetListAsync(
            string? filter = null,int? skipCount = 0,int? maxResultCount = int.MaxValue,string? sorting = null, string? metaTitle = null,string? metaKeyWords = null,string? metaDescription = null,
            bool? metaIndex = null,
            bool? metaFollow = null,
            int? metaPriority = 0,
            CancellationToken cancellationToken = default)
        { 
        
            var dbSet = await GetDbSetAsync();

            var query = ApplyFilter(dbSet, filter, metaTitle, metaKeyWords, metaDescription, metaIndex, metaFollow, metaPriority);

            if (!string.IsNullOrWhiteSpace(sorting))
            {
                query = query.OrderBy(sorting);
            }
            else
            {
                query = query.OrderBy(x => x.MetaTitle);
            }

            return await query
                .Skip(skipCount ?? 0)
                .Take(maxResultCount ?? int.MaxValue)
                .ToListAsync(cancellationToken);

        }

        
        


        protected virtual IQueryable<SEOSetting> ApplyFilter(IQueryable<SEOSetting> query,string? filter,string? metaTitle,string? metaKeyWords,string? metaDescription,bool? metaIndex,bool? metaFollow,int? metaPriority)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                query = query.Where(x =>
                    x.MetaTitle.Contains(filter) ||
                    x.MetaDescription.Contains(filter) ||
                    x.MetaKeyWords.Contains(filter));
            }

            if (!string.IsNullOrWhiteSpace(metaTitle))
            {
                query = query.Where(x => x.MetaTitle.Contains(metaTitle));
            }

            if (!string.IsNullOrWhiteSpace(metaKeyWords))
            {
                query = query.Where(x => x.MetaKeyWords.Contains(metaKeyWords));
            }

            if (!string.IsNullOrWhiteSpace(metaDescription))
            {
                query = query.Where(x => x.MetaDescription.Contains(metaDescription));
            }

            if (metaIndex.HasValue)
            {
                query = query.Where(x => x.MetaIndex == metaIndex.Value);
            }

            if (metaFollow.HasValue)
            {
                query = query.Where(x => x.MetaFollow == metaFollow.Value);
            }

            if (metaPriority.HasValue && metaPriority.Value > 0)
            {
                query = query.Where(x => x.MetaPriority == metaPriority.Value);
            }

            return query;
        }


    }
}
