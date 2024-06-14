namespace ExceptionWrapper
{
    public interface IMyService1
    {
        public void DoWork(string value);
        public void DoOtherWork();
        public string ServiceName { get; }
    }
}