using System;
using Domain.Entities.Sessions;

namespace Domain.Exceptions
{
	public class InvalidSessionDuration : Exception
	{
		public InvalidSessionDuration(SessionTiming timing)
			: base($"Session cannot have a negative duration" +
			       $"Session start: {timing.Start}" +
			       $"Session end: {timing.End}" +
			       $"Session Duration: {timing.Duration}")
		{
			
		}
	}
}