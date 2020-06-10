using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using Whizbang.Core.Ioc;

namespace Whizbang.Sample.ConsoleApp.Providers
{
    public class ContainerBuilder : IContainerBuilder
    {
        private ServiceCollection sc;

        public ContainerBuilder()
        {
            sc = new ServiceCollection();
        }

        public IContainer Build()
        {
            var sp = sc.BuildServiceProvider();

            return new Container(sp);
        }

        public IContainerBuilder Register<T>() where T : class
        {
            sc.AddTransient<T>();

            return this;
        }

        public IContainerBuilder Register<T>(Scope scope) where T : class
        {
            switch (scope)
            {
                case Scope.Singleton:
                    sc.AddSingleton<T>();
                    break;
                case Scope.Transient:
                    sc.AddTransient<T>();
                    break;
                case Scope.PerExecutionScope:
                    sc.AddScoped<T>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public IContainerBuilder Register<T>(Func<IContainer, T> factory) where T : class
        {
            sc.AddTransient<T>(sc=>factory(new Container(sc)));
            return this;
        }

        public IContainerBuilder Register<T>(Func<IContainer, T> factory, Scope scope) where T : class
        {
            throw new NotImplementedException();
        }

        public IContainerBuilder Register(Type a, Type b)
        {
            sc.AddTransient(a, b);
            return this;
        }

        public IContainerBuilder Register(Type a, Type b, Scope scope)
        {
            switch (scope)
            {
                case Scope.Singleton:
                    sc.AddSingleton(a, b);
                    break;
                case Scope.Transient:
                    sc.AddTransient(a, b);
                    break;
                case Scope.PerExecutionScope:
                    sc.AddScoped(a, b);
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }

        public IContainerBuilder RegisterSingleton<T>(T instance) where T : class
        {
            sc.AddSingleton<T>();
            return this;
        }

        IContainerBuilder IContainerBuilder.Register<TInterface, TImplementation>()
        {
            sc.AddTransient<TInterface, TImplementation>();
            return this;
        }

        IContainerBuilder IContainerBuilder.Register<TInterface, TImplementation>(Scope scope)
        {
            switch (scope)
            {
                case Scope.Singleton:
                    sc.AddSingleton<TInterface, TImplementation>();
                    break;
                case Scope.Transient:
                    sc.AddTransient<TInterface, TImplementation>();
                    break;
                case Scope.PerExecutionScope:
                    sc.AddScoped<TInterface, TImplementation>();
                    break;
                default:
                    throw new ArgumentOutOfRangeException("scope");
            }
            return this;
        }
    }
}
