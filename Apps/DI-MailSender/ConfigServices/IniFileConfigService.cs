using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConfigServices
{
    public class IniFileConfigService : IConfigService
    {
        public string FilePath { get; set; }
        public string GetValue(string name)
        {
            var kv = File.ReadAllLines(FilePath).Select(s => s.Split('=')).Select(strs => new { Name = strs[0], Value = strs[1] }).SingleOrDefault(kv => kv.Name == name);
            return kv!=null ? kv.Value : null ;
        }
    }
}
