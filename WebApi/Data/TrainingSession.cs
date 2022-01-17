using System;
using System.Collections.Generic;

namespace WebApi.Data
{
    public partial class TrainingSession
    {
        public int Id { get; set; }
        public decimal? Price { get; set; }
        public bool? IsTryoutSession { get; set; }
        public int? Capacity { get; set; }
        public string? Name { get; set; }
        public int? SessionTimingId { get; set; }
        public int? AddressId { get; set; }
        public int? SquadId { get; set; }
        public string? Description { get; set; }

        public virtual Address? Address { get; set; }
        public virtual SessionTiming? SessionTiming { get; set; }
        public virtual Squad? Squad { get; set; }
    }
}
