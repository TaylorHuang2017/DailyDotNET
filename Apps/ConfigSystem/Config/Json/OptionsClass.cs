using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Json;
using static Json.Program;

namespace Json
{
    class OptionsClass
    {
        //Dependency Injection 注入IOptions
        private readonly IOptionsSnapshot<Config> optConfig;

        public OptionsClass(IOptionsSnapshot<Config> optConfig)
        {
            this.optConfig = optConfig;
        }

        public void Test()
        {
            Console.WriteLine(optConfig.Value.Age);
            Console.WriteLine("**********************");
            Console.WriteLine(optConfig.Value.Age);
        }
    }
}
