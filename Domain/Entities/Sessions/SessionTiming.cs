using System;

namespace Domain.Entities.Sessions
{
	public class SessionTiming
	{
		public DateTime Start { get; set; }
		public DateTime End { get; set; }

		public TimeSpan Duration => Start - End;
	}
}