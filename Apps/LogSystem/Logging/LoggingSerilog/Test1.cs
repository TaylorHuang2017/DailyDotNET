using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggingSerilog
{
    class Test1
    {
        private readonly ILogger<Test1> logger;
        public Test1(ILogger<Test1> logger)
        {
            this.logger = logger;
        }

        public void Test()
        {
            logger.LogDebug("start connecting to DB");
            logger.LogWarning("WARN: old conn string");
            logger.LogInformation("connection failed");

            try
            {
                File.ReadAllText("A:/1.txt");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "file read error");                
            }
        }
    }
}
