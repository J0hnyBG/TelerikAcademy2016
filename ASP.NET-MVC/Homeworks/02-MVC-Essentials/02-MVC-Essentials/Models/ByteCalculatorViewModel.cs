using System.Collections.Concurrent;
using System.Collections.Generic;

namespace _02_MVC_Essentials.Models
{
    public class ByteCalculatorViewModel
    {
        public ByteCalculatorViewModel()
        {
            this.Results = new Dictionary<string, string>();
        }

        public IDictionary<string, string> Results { get; set; }
    }
}