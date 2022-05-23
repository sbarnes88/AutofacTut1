using System;
using AutofacTut1.Models;

namespace AutofacTut1.Handlers
{
    public class CustomHandler1 : ICustomHandler1
    {
        private Config _config;
        private ICustomHandler2 _customHandler2;
        public CustomHandler1(ICustomHandler2 customHandler2, Config config)
        {
            Console.WriteLine(".ctor CustomHandler1 called");
            _customHandler2 = customHandler2;
            _config = config;
        }

        public void Execute()
        {
            Console.WriteLine("Call inside CustomHandler1()");
            Console.WriteLine("Calling CustomHandler2()");
            Console.WriteLine(_config.InitializeDate.ToString());
            _customHandler2.Execute();
        }
    }
}
