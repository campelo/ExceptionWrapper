namespace ExceptionWrapper
{
    public class MyService1 : IMyService1
    {
        public string ServiceName => "Service Name";

        public virtual void DoOtherWork()
        {
            throw new NullReferenceException("Null reference encountered!");

        }

        public virtual void DoWork(string value)
        {
            throw new InvalidOperationException($"Something went wrong! {value}");
        }
    }
}
