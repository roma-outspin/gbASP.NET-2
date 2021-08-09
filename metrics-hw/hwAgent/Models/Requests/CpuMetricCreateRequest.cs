using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hwAgent.Requests
{
    public class CpuMetricCreateRequest
    {
        public string Time { get; set; }
        public int Value { get; set; }
    }
}
