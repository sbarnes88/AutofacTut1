using System;
using AutofacTut1.Models;

namespace AutofacTut1.Handlers
{
    public class CustomHandler2 : ICustomHandler2
    {
        private ICustomHandler3 _customHandler3;
        private Config _config;
        public CustomHandler2(ICustomHandler3 customHandler3, Config config)
        {
            Console.WriteLine(".ctor CustomHandler2 called");
            _customHandler3 = customHandler3;
            _config = config;
        }

        public void Execute()
        {
            Console.WriteLine("Call inside CustomHandler2()");
            Console.WriteLine("Calling CustomHandler3()");
            Console.WriteLine(_config.InitializeDate.ToString());
            _customHandler3.Execute();
        }
    }
}
