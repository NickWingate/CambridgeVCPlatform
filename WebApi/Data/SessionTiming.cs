using System;
using System.Collections.Generic;

namespace WebApi.Data
{
    public partial class SessionTiming
    {
        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }
    }
}
