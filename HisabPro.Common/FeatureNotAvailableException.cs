namespace HisabPro.Common
{
    public class FeatureNotAvailableException : Exception
    {
        public int StatusCode { get; } = 501;

        public FeatureNotAvailableException(string message) : base(message) { }
    }
}
