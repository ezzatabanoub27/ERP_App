using Microsoft.EntityFrameworkCore;
using NewApp.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NewApp.Generals
{
    public class EfCoreGeneralSettingRepository
        : EfCoreRepository<NewAppDbContext, GeneralSetting, Guid>, IGeneralSettingRepository
    {
        public EfCoreGeneralSettingRepository(IDbContextProvider<NewAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<GeneralSetting>> GetListAsync(
            string? filterText = null,
            string? pageTitle = null,
            string? slug = null,
            string? content = null,
            DateTime? publishDate = null,
            bool? hideFromMenue = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, pageTitle, slug, content, publishDate, hideFromMenue);

            if (!string.IsNullOrWhiteSpace(sorting))
            {
                try
                {
                    query = query.OrderBy(x=>x.PageTitle); 
                }
                catch
                {
                    query = query.OrderBy(x => x.PageTitle); 
                }
            }
            else
            {
                query = query.OrderBy(x => x.PageTitle);
            }

            return await query
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string? filterText = null,
            string? pageTitle = null,
            string? slug = null,
            string? content = null,
            DateTime? publishDate = null,
            bool? hideFromMenue = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableAsync();
            query = ApplyFilter(query, filterText, pageTitle, slug, content, publishDate, hideFromMenue);

            return await query.LongCountAsync(cancellationToken);
        }

        private static IQueryable<GeneralSetting> ApplyFilter(
            IQueryable<GeneralSetting> query,
            string? filterText,
            string? pageTitle,
            string? slug,
            string? content,
            DateTime? publishDate,
            bool? hideFromMenue)
        {
            if (!string.IsNullOrWhiteSpace(filterText))
            {
                query = query.Where(x =>
                    x.PageTitle.Contains(filterText) ||
                    x.Slug.Contains(filterText) ||
                    x.Content.Contains(filterText));
            }

            if (!string.IsNullOrWhiteSpace(pageTitle))
            {
                query = query.Where(x => x.PageTitle.Contains(pageTitle));
            }

            if (!string.IsNullOrWhiteSpace(slug))
            {
                query = query.Where(x => x.Slug.Contains(slug));
            }

            if (!string.IsNullOrWhiteSpace(content))
            {
                query = query.Where(x => x.Content.Contains(content));
            }

            if (publishDate.HasValue)
            {
                query = query.Where(x => x.PublishDate.Date == publishDate.Value.Date);
            }

            if (hideFromMenue.HasValue)
            {
                query = query.Where(x => x.HideFromMenue == hideFromMenue.Value);
            }

            return query;
        }
    }
}
