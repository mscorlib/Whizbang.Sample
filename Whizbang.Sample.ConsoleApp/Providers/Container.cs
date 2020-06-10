using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Whizbang.Core.Ioc;

namespace Whizbang.Sample.ConsoleApp.Providers
{
    public class Container : IContainer
    {
        IServiceProvider _service;
        public Container(IServiceProvider service)
        {
            _service = service;
        }
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public T Resolve<T>()
        {
            return _service.GetService<T>();
        }

        public IEnumerable<object> ResolveAll<T>()
        {
            return (IEnumerable<object>)_service.GetServices<T>();
        }
    }
}
