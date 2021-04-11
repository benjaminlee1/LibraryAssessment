namespace LibraryChallengeCore
{
    public enum CheckedOutResultStatus
    {
        Ok,
        Error
    }

    public class CheckoutResult
    {
        public CheckedOutResultStatus CheckedOutResultStatus { get; set; }
        public string Message { get; set; }
    }
}
