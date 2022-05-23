using System;
using AutofacTut1.Models;

namespace AutofacTut1.Handlers
{
    public class CustomHandler3 : ICustomHandler3
    {
        private Config _config;
        public CustomHandler3(Config config)
        {
            Console.WriteLine(".ctor CustomHandler3 called");
            _config = config;
        }

        public void Execute()
        {
            Console.WriteLine("Call from CustomHandler3()");
            Console.WriteLine(_config.InitializeDate.ToString());

        }
    }
}
