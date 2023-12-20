using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace EgyptReciepts.Branches
{
    public class BranchCreateDto
    {
        [Required]
        [StringLength(BranchConsts.TitleMaxLength)]
        public string Title { get; set; }
        [Required]
        [StringLength(BranchConsts.MangerNameMaxLength)]
        public string MangerName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}