using System;
using System.Reflection;
using Autofac;
using AutofacTut1.Handlers;
using AutofacTut1.Models;

/// <summary>
/// Using Autofac 6.3.0 from Nuget
/// Shows the differences between utilizing Autofac versus not
/// Step through the code to see what's happening. Comments
/// will be provided for additional explanation.
/// </summary>

namespace AutofacTut1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1. Run WITHOUT Autofac.");
            Console.WriteLine("2. Rune WITH Autofac.");

            var key = Console.ReadLine();

            while (!key.StartsWith("1") && !key.StartsWith("2"))
            {
                key = Console.ReadLine();
            }

            if(key.StartsWith("1"))
            {
                var app = new AppWithoutAutofac();
                app.Run();
            }else
            {
                var app = new AppWithAutofac();
                app.Run();
            }
        }
    }

    public class AppWithoutAutofac
    {
        public AppWithoutAutofac()
        {
            Console.WriteLine("Starting app without any dependency injection.");
        }

        public void Run()
        {
            var handler3 = new CustomHandler3(Config.Initialize("test.json"));
            var handler2 = new CustomHandler2(handler3, Config.Initialize("test.json"));
            var handler1 = new CustomHandler1(handler2, Config.Initialize("test.json"));
            handler1.Execute();
        }
    }

    public class AppWithAutofac
    {
        private IContainer _container;
        public AppWithAutofac()
        {
            Console.WriteLine("Starting app using Autofac.");
            //We setup a ContainerBuilder to handle what types and interfaces we
            //need to have initialized. The _container will manage the instances
            //that we need so we can Resolve them.

            var builder = new ContainerBuilder();

            //We make a list of the assembly types we need to have instantiated.
            //If we use external libraries, we can pass those in here too to
            //ensure they get proper instantiation.
            var assemblies = new[]
            {
                Assembly.GetAssembly(typeof(Program))
            };

            //We take the assemblies and tell it to register them as implemented
            //interfaces. There are other items such as register as
            //SingleInstance (or Singleton).
            builder.RegisterAssemblyTypes(assemblies).AsImplementedInterfaces();

            //Here we're going to register the configuration as a SingleInstance
            //so each of the Handlers get the same configuration each time.
            builder.Register(c => Config.Initialize("test.json")).SingleInstance();

            //Here we tell the ContainerBuilder to setup the components. Watch
            //the output to see each console line that logs.
            _container = builder.Build();
        }

        public void Run()
        {
            //Here we resolve the ICustomhandler1 and have it run using the
            //interface's exposed methods.
            var handlerInstance = _container.Resolve<ICustomHandler1>();
            handlerInstance.Execute();
        }
    }
}
