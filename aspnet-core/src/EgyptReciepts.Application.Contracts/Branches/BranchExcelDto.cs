using System;

namespace EgyptReciepts.Branches
{
    public class BranchExcelDto
    {
        public string Title { get; set; }
        public string MangerName { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
    }
}