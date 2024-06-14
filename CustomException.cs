using Castle.DynamicProxy;

namespace ExceptionWrapper;

public class CustomException : Exception
{
    public CustomException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}

public class CustomExceptionInterceptor : IInterceptor
{
    public void Intercept(IInvocation invocation)
    {
        try
        {
            invocation.Proceed(); // Proceed with the original method call
        }
        catch (Exception ex)
        {
            var targetType = invocation.InvocationTarget.GetType();
            var propertyInfo = targetType.GetProperty(nameof(IMyService1.ServiceName));
            string? serviceName = "Undefined";
            if (propertyInfo != null)
            {
                serviceName = propertyInfo.GetValue(invocation.InvocationTarget)?.ToString();
            }
            throw new CustomException($"An error occurred while executing the method. ServiceName {serviceName}", ex);
        }
    }
}
