using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace EgyptReciepts.Branches
{
    public interface IBranchRepository : IRepository<Branch, int>
    {
        Task<List<Branch>> GetListAsync(
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
            CancellationToken cancellationToken = default
        );

        Task<long> GetCountAsync(
            string filterText = null,
            string title = null,
            string mangerName = null,
            TimeSpan? startTimeMin = null,
            TimeSpan? startTimeMax = null,
            TimeSpan? endTimeMin = null,
            TimeSpan? endTimeMax = null,
            CancellationToken cancellationToken = default);
    }
}