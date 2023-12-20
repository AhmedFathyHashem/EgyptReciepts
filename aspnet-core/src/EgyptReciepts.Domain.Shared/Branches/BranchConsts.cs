namespace EgyptReciepts.Branches
{
    public static class BranchConsts
    {
        private const string DefaultSorting = "{0}Title asc";

        public static string GetDefaultSorting(bool withEntityName)
        {
            return string.Format(DefaultSorting, withEntityName ? "Branch." : string.Empty);
        }

        public const int TitleMaxLength = 200;
        public const int MangerNameMaxLength = 250;
    }
}