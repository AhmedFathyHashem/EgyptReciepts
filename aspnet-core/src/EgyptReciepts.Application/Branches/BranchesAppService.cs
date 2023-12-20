using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;
using Volo.Abp;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using EgyptReciepts.Permissions;
using EgyptReciepts.Branches;
using MiniExcelLibs;
using Volo.Abp.Content;
using Volo.Abp.Authorization;
using Volo.Abp.Caching;
using Microsoft.Extensions.Caching.Distributed;
using EgyptReciepts.Shared;

namespace EgyptReciepts.Branches
{
    [RemoteService(IsEnabled = false)]
    [Authorize(EgyptRecieptsPermissions.Branches.Default)]
    public class BranchesAppService : ApplicationService, IBranchesAppService
    {
        private readonly IDistributedCache<BranchExcelDownloadTokenCacheItem, string> _excelDownloadTokenCache;
        private readonly IBranchRepository _branchRepository;
        private readonly BranchManager _branchManager;

        public BranchesAppService(IBranchRepository branchRepository, BranchManager branchManager, IDistributedCache<BranchExcelDownloadTokenCacheItem, string> excelDownloadTokenCache)
        {
            _excelDownloadTokenCache = excelDownloadTokenCache;
            _branchRepository = branchRepository;
            _branchManager = branchManager;
        }

        public virtual async Task<PagedResultDto<BranchDto>> GetListAsync(GetBranchesInput input)
        {
            var totalCount = await _branchRepository.GetCountAsync(input.FilterText, input.Title, input.MangerName, input.StartTimeMin, input.StartTimeMax, input.EndTimeMin, input.EndTimeMax);
            var items = await _branchRepository.GetListAsync(input.FilterText, input.Title, input.MangerName, input.StartTimeMin, input.StartTimeMax, input.EndTimeMin, input.EndTimeMax, input.Sorting, input.MaxResultCount, input.SkipCount);

            return new PagedResultDto<BranchDto>
            {
                TotalCount = totalCount,
                Items = ObjectMapper.Map<List<Branch>, List<BranchDto>>(items)
            };
        }

        public virtual async Task<BranchDto> GetAsync(int id)
        {
            return ObjectMapper.Map<Branch, BranchDto>(await _branchRepository.GetAsync(id));
        }

        [Authorize(EgyptRecieptsPermissions.Branches.Delete)]
        public virtual async Task DeleteAsync(int id)
        {
            await _branchRepository.DeleteAsync(id);
        }

        [Authorize(EgyptRecieptsPermissions.Branches.Create)]
        public virtual async Task<BranchDto> CreateAsync(BranchCreateDto input)
        {

            var branch = await _branchManager.CreateAsync(
            input.Title, input.MangerName, input.StartTime, input.EndTime
            );

            return ObjectMapper.Map<Branch, BranchDto>(branch);
        }

        [Authorize(EgyptRecieptsPermissions.Branches.Edit)]
        public virtual async Task<BranchDto> UpdateAsync(int id, BranchUpdateDto input)
        {

            var branch = await _branchManager.UpdateAsync(
            id,
            input.Title, input.MangerName, input.StartTime, input.EndTime, input.ConcurrencyStamp
            );

            return ObjectMapper.Map<Branch, BranchDto>(branch);
        }

        [AllowAnonymous]
        public virtual async Task<IRemoteStreamContent> GetListAsExcelFileAsync(BranchExcelDownloadDto input)
        {
            var downloadToken = await _excelDownloadTokenCache.GetAsync(input.DownloadToken);
            if (downloadToken == null || input.DownloadToken != downloadToken.Token)
            {
                throw new AbpAuthorizationException("Invalid download token: " + input.DownloadToken);
            }

            var items = await _branchRepository.GetListAsync(input.FilterText, input.Title, input.MangerName, input.StartTimeMin, input.StartTimeMax, input.EndTimeMin, input.EndTimeMax);

            var memoryStream = new MemoryStream();
            await memoryStream.SaveAsAsync(ObjectMapper.Map<List<Branch>, List<BranchExcelDto>>(items));
            memoryStream.Seek(0, SeekOrigin.Begin);

            return new RemoteStreamContent(memoryStream, "Branches.xlsx", "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
        }

        public async Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            var token = Guid.NewGuid().ToString("N");

            await _excelDownloadTokenCache.SetAsync(
                token,
                new BranchExcelDownloadTokenCacheItem { Token = token },
                new DistributedCacheEntryOptions
                {
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromSeconds(30)
                });

            return new DownloadTokenResultDto
            {
                Token = token
            };
        }
    }
}