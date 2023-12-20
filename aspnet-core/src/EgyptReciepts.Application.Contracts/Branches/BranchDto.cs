using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Domain.Entities;

namespace EgyptReciepts.Branches
{
    public class BranchDto : FullAuditedEntityDto<int>, IHasConcurrencyStamp
    {
        public string Title { get; set; }
        public string MangerName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}