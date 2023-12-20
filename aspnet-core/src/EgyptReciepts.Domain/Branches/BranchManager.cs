using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using JetBrains.Annotations;
using Volo.Abp;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.Domain.Services;
using Volo.Abp.Data;

namespace EgyptReciepts.Branches
{
    public class BranchManager : DomainService
    {
        private readonly IBranchRepository _branchRepository;

        public BranchManager(IBranchRepository branchRepository)
        {
            _branchRepository = branchRepository;
        }

        public async Task<Branch> CreateAsync(
        string title, string mangerName, TimeSpan startTime, TimeSpan endTime)
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));
            Check.Length(title, nameof(title), BranchConsts.TitleMaxLength);
            Check.NotNullOrWhiteSpace(mangerName, nameof(mangerName));
            Check.Length(mangerName, nameof(mangerName), BranchConsts.MangerNameMaxLength);
            Check.NotNull(startTime, nameof(startTime));
            Check.NotNull(endTime, nameof(endTime));

            var branch = new Branch(

             title, mangerName, startTime, endTime
             );

            return await _branchRepository.InsertAsync(branch);
        }

        public async Task<Branch> UpdateAsync(
            int id,
            string title, string mangerName, TimeSpan startTime, TimeSpan endTime, [CanBeNull] string concurrencyStamp = null
        )
        {
            Check.NotNullOrWhiteSpace(title, nameof(title));
            Check.Length(title, nameof(title), BranchConsts.TitleMaxLength);
            Check.NotNullOrWhiteSpace(mangerName, nameof(mangerName));
            Check.Length(mangerName, nameof(mangerName), BranchConsts.MangerNameMaxLength);
            Check.NotNull(startTime, nameof(startTime));
            Check.NotNull(endTime, nameof(endTime));

            var branch = await _branchRepository.GetAsync(id);

            branch.Title = title;
            branch.MangerName = mangerName;
            branch.StartTime = startTime;
            branch.EndTime = endTime;

            branch.SetConcurrencyStampIfNotNull(concurrencyStamp);
            return await _branchRepository.UpdateAsync(branch);
        }

    }
}