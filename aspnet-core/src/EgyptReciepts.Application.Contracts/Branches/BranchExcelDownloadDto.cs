using Volo.Abp.Application.Dtos;
using System;

namespace EgyptReciepts.Branches
{
    public class BranchExcelDownloadDto
    {
        public string DownloadToken { get; set; }

        public string? FilterText { get; set; }

        public string? Title { get; set; }
        public string? MangerName { get; set; }
        public DateTime? StartTimeMin { get; set; }
        public DateTime? StartTimeMax { get; set; }
        public DateTime? EndTimeMin { get; set; }
        public DateTime? EndTimeMax { get; set; }

        public BranchExcelDownloadDto()
        {

        }
    }
}