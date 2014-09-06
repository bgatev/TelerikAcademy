namespace WolfRaider.Common.Config
{
    public static class ExceptionMessage
    {
        public const string InsertFailedFormat = "INSERT {0}: {1} cannot be created.";
        public const string UpdateFailedFormat = "UPDATE {0}: {1} cannot be updated.";
        public const string DeleteFailedFormat = "DELETE {0}: {1} cannot be deleted.";
        public const string SelectFailedFormat = "SELECT {0}: {1} cannot be selected.";

        public const string ParameterCannotBeNull = "{0} cannot be null";
    }
}
