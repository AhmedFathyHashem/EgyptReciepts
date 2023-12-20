using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.Domain.Repositories.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using EgyptReciepts.EntityFrameworkCore;

namespace EgyptReciepts.Branches
{
    public class EfCoreBranchRepository : EfCoreRepository<EgyptRecieptsDbContext, Branch, int>, IBranchRepository
    {
        public EfCoreBranchRepository(IDbContextProvider<EgyptRecieptsDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        public async Task<List<Branch>> GetListAsync(
            string filterText = null,
            string title = null,
            string mangerName = null,
            TimeSpan? startTimeMin = null,
            TimeSpan? startTimeMax = null,
            TimeSpan? endTimeMin = null,
            TimeSpan? endTimeMax = null,
            string sorting = null,
            int maxResultCount = int.MaxValue,
            int skipCount = 0,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetQueryableAsync()), filterText, title, mangerName, startTimeMin, startTimeMax, endTimeMin, endTimeMax);
            query = query.OrderBy(string.IsNullOrWhiteSpace(sorting) ? BranchConsts.GetDefaultSorting(false) : sorting);
            return await query.PageBy(skipCount, maxResultCount).ToListAsync(cancellationToken);
        }

        public async Task<long> GetCountAsync(
            string filterText = null,
            string title = null,
            string mangerName = null,
            TimeSpan? startTimeMin = null,
            TimeSpan? startTimeMax = null,
            TimeSpan? endTimeMin = null,
            TimeSpan? endTimeMax = null,
            CancellationToken cancellationToken = default)
        {
            var query = ApplyFilter((await GetDbSetAsync()), filterText, title, mangerName, startTimeMin, startTimeMax, endTimeMin, endTimeMax);
            return await query.LongCountAsync(GetCancellationToken(cancellationToken));
        }

        protected virtual IQueryable<Branch> ApplyFilter(
            IQueryable<Branch> query,
            string filterText,
            string title = null,
            string mangerName = null,
            TimeSpan? startTimeMin = null,
            TimeSpan? startTimeMax = null,
            TimeSpan? endTimeMin = null,
            TimeSpan? endTimeMax = null)
        {
            return query
                    .WhereIf(!string.IsNullOrWhiteSpace(filterText), e => e.Title.Contains(filterText) || e.MangerName.Contains(filterText))
                    .WhereIf(!string.IsNullOrWhiteSpace(title), e => e.Title.Contains(title))
                    .WhereIf(!string.IsNullOrWhiteSpace(mangerName), e => e.MangerName.Contains(mangerName))
                    .WhereIf(startTimeMin.HasValue, e => e.StartTime >= startTimeMin.Value)
                    .WhereIf(startTimeMax.HasValue, e => e.StartTime <= startTimeMax.Value)
                    .WhereIf(endTimeMin.HasValue, e => e.EndTime >= endTimeMin.Value)
                    .WhereIf(endTimeMax.HasValue, e => e.EndTime <= endTimeMax.Value);
        }
    }
}