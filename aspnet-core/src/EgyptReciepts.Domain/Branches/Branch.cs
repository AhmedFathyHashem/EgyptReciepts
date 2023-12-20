using System;
using System.Linq;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp.Domain.Entities;
using Volo.Abp.Domain.Entities.Auditing;
using Volo.Abp.MultiTenancy;
using JetBrains.Annotations;

using Volo.Abp;

namespace EgyptReciepts.Branches
{
    public class Branch : FullAuditedAggregateRoot<int>
    {
        [NotNull]
        public virtual string Title { get; set; }

        [NotNull]
        public virtual string MangerName { get; set; }

        public virtual TimeSpan StartTime { get; set; }

        public virtual TimeSpan EndTime { get; set; }

        public Branch()
        {

        }

        public Branch(string title, string mangerName, TimeSpan startTime, TimeSpan endTime)
        {

            Check.NotNull(title, nameof(title));
            Check.Length(title, nameof(title), BranchConsts.TitleMaxLength, 0);
            Check.NotNull(mangerName, nameof(mangerName));
            Check.Length(mangerName, nameof(mangerName), BranchConsts.MangerNameMaxLength, 0);
            Title = title;
            MangerName = mangerName;
            if (startTime > endTime)
            {
                throw new UserFriendlyException("Start Time must be less than End Time");
            }
            StartTime = startTime;
            EndTime = endTime;
        }

    }
}