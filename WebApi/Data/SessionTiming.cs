using System;
using System.Collections.Generic;

namespace WebApi.Data
{
    public partial class SessionTiming
    {
        public SessionTiming()
        {
            TrainingSessions = new HashSet<TrainingSession>();
        }

        public int Id { get; set; }
        public DateTime? Start { get; set; }
        public DateTime? End { get; set; }

        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
