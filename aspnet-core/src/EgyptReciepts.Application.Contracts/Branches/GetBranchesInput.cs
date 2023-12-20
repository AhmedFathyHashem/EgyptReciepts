using Volo.Abp.Application.Dtos;
using System;

namespace EgyptReciepts.Branches
{
    public class GetBranchesInput : PagedAndSortedResultRequestDto
    {
        public string? FilterText { get; set; }

        public string? Title { get; set; }
        public string? MangerName { get; set; }
        public TimeSpan? StartTimeMin { get; set; }
        public TimeSpan? StartTimeMax { get; set; }
        public TimeSpan? EndTimeMin { get; set; }
        public TimeSpan? EndTimeMax { get; set; }

        public GetBranchesInput()
        {

        }
    }
}