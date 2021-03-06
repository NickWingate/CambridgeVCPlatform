using System;
using System.Collections.Generic;

namespace WebApi.Data
{
    public partial class Address
    {
        public Address()
        {
            TrainingSessions = new HashSet<TrainingSession>();
        }

        public int Id { get; set; }
        public string LineOne { get; set; }
        public string LineTwo { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string PostCode { get; set; }

        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
