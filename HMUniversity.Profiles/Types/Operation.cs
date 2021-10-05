namespace HMUniversity.Profiles.Types
{
    public class Operation
    {
        public OperationType Type { get; set; }
        public string[] Source { get; set; }
        public string Target { get; set; }
    }
}