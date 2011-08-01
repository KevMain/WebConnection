namespace CCE.WebConnection.DAL.Llbl
{
    public class Const
    {
        public enum ConstFieldNames
        {
            Created,
            CreatedBy,
            Modified,
            ModifiedBy,
            TimeStamp
        }

        public const string EXC_CONCURRENCY_ERROR = "Unable to {0} because the data has been modified by another user.";
    }
}
