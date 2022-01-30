using System;
using System.Collections.Generic;

namespace WebApi.Data
{
    public partial class Squad
    {
        public Squad()
        {
            TrainingSessions = new HashSet<TrainingSession>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TrainingSession> TrainingSessions { get; set; }
    }
}
