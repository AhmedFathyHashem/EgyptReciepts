using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace EgyptReciepts.Branches
{
    public class BranchDto : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Title { get; set; }
        public string MangerName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}