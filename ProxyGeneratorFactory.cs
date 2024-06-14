using Castle.DynamicProxy;

namespace ExceptionWrapper
{
    public static class ProxyGeneratorFactory
    {
        private static readonly ProxyGenerator _generator = new ProxyGenerator();

        public static T CreateProxy<T>(IInterceptor interceptor) where T : class, new()
        {
            return _generator.CreateClassProxy<T>(interceptor);
        }
    }
}
