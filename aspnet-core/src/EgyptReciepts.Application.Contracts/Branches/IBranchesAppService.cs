using System;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Content;
using EgyptReciepts.Shared;

namespace EgyptReciepts.Branches
{
    public interface IBranchesAppService : IApplicationService
    {
        Task<PagedResultDto<BranchDto>> GetListAsync(GetBranchesInput input);

        Task<BranchDto> GetAsync(int id);

        Task DeleteAsync(int id);

        Task<BranchDto> CreateAsync(BranchCreateDto input);

        Task<BranchDto> UpdateAsync(int id, BranchUpdateDto input);

        Task<IRemoteStreamContent> GetListAsExcelFileAsync(BranchExcelDownloadDto input);

        Task<DownloadTokenResultDto> GetDownloadTokenAsync();
    }
}