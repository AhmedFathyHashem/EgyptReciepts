using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Volo.Abp;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Application.Dtos;
using EgyptReciepts.Branches;
using Volo.Abp.Content;
using EgyptReciepts.Shared;

namespace EgyptReciepts.Controllers.Branches
{
    [RemoteService]
    [Area("app")]
    [ControllerName("Branch")]
    [Route("api/app/branches")]

    public class BranchController : AbpController, IBranchesAppService
    {
        private readonly IBranchesAppService _branchesAppService;

        public BranchController(IBranchesAppService branchesAppService)
        {
            _branchesAppService = branchesAppService;
        }

        [HttpGet]
        public virtual Task<PagedResultDto<BranchDto>> GetListAsync(GetBranchesInput input)
        {
            return _branchesAppService.GetListAsync(input);
        }

        [HttpGet]
        [Route("{id}")]
        public virtual Task<BranchDto> GetAsync(int id)
        {
            return _branchesAppService.GetAsync(id);
        }

        [HttpPost]
        public virtual Task<BranchDto> CreateAsync(BranchCreateDto input)
        {
            return _branchesAppService.CreateAsync(input);
        }

        [HttpPut]
        [Route("{id}")]
        public virtual Task<BranchDto> UpdateAsync(int id, BranchUpdateDto input)
        {
            return _branchesAppService.UpdateAsync(id, input);
        }

        [HttpDelete]
        [Route("{id}")]
        public virtual Task DeleteAsync(int id)
        {
            return _branchesAppService.DeleteAsync(id);
        }

        [HttpGet]
        [Route("as-excel-file")]
        public virtual Task<IRemoteStreamContent> GetListAsExcelFileAsync(BranchExcelDownloadDto input)
        {
            return _branchesAppService.GetListAsExcelFileAsync(input);
        }

        [HttpGet]
        [Route("download-token")]
        public Task<DownloadTokenResultDto> GetDownloadTokenAsync()
        {
            return _branchesAppService.GetDownloadTokenAsync();
        }
    }
}