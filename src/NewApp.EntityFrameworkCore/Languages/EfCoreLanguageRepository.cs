using Microsoft.EntityFrameworkCore;
using NewApp.EntityFrameworkCore;
using NewApp.LanguagesType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;

namespace NewApp.Languages
{
    public class EfCoreLanguageRepository
        : EfCoreRepository<NewAppDbContext, Language, Guid>, ILangaugeRepository
    {
        public EfCoreLanguageRepository(IDbContextProvider<NewAppDbContext> dbContextProvider)
            : base(dbContextProvider)
        {
        }

        public async Task<List<Language>> GetListAsync(
            string? filterText = null,
            string? title = null,
            FontType? font = null,
            CultureName? culture = null,
            bool? isDefault = null,
            string? sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableAsync();

            query = ApplyFilter(query, filterText, title, font, culture, isDefault);

            if (!string.IsNullOrWhiteSpace(sorting))
            {
                    query = query.OrderBy(x=>x.Title);  ////sorting throw ArgumentNullExption
            }
            else
            {
                query = query.OrderBy(x => x.Title);
            }

            return await query
                .Skip(skipCount)
                .Take(maxResultCount)
                .ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string? filterText = null,
            string? title = null,
            FontType? font = null,
            CultureName? culture = null,
            bool? isDefault = null,
            CancellationToken cancellationToken = default)
        {
            var query = await GetQueryableAsync();
            query = ApplyFilter(query, filterText, title, font, culture, isDefault);

            return await query.LongCountAsync(cancellationToken);
        }

        private static IQueryable<Language> ApplyFilter(
            IQueryable<Language> query,
            string? filterText,
            string? title,
            FontType? font,
            CultureName? culture,
            bool? isDefault)
        {
            if (!string.IsNullOrWhiteSpace(filterText))
            {
                query = query.Where(x => x.Title.Contains(filterText));
            }

            if (!string.IsNullOrWhiteSpace(title))
            {
                query = query.Where(x => x.Title.Contains(title));
            }

            if (font.HasValue)
            {
                query = query.Where(x => x.Font == font.Value);
            }

            if (culture.HasValue)
            {
                query = query.Where(x => x.Culture == culture.Value);
            }

            if (isDefault.HasValue)
            {
                query = query.Where(x => x.IsDefault == isDefault.Value);
            }

            return query;
        }
    }
}
