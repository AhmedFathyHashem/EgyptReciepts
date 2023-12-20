using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using Volo.Abp.Domain.Entities;

namespace EgyptReciepts.Branches
{
    public class BranchUpdateDto : IHasConcurrencyStamp
    {
        [Required]
        [StringLength(BranchConsts.TitleMaxLength)]
        public string Title { get; set; }
        [Required]
        [StringLength(BranchConsts.MangerNameMaxLength)]
        public string MangerName { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public string ConcurrencyStamp { get; set; }
    }
}