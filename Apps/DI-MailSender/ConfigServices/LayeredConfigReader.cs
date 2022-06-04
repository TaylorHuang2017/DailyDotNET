using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigServices //中心配置服务器
{
    class LayeredConfigReader : IConfigReader
    {
        private readonly IEnumerable<IConfigService> services;

        public LayeredConfigReader(IEnumerable<IConfigService> services)
        {
            this.services = services;
        }

        public string GetValue(string name)
        {
            string value = null;
            foreach (var service in services)
            {
                string newValue = service.GetValue(name);
                if (newValue != null)
                {
                    value = newValue;
                }
            }
            return value;
        }
    }
}
