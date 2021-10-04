using System;
using Domain.Exceptions;

namespace Domain.Entities.Sessions
{
	public class SessionTiming
	{
		private DateTime _start;
		public DateTime Start
		{
			get => _start;
			set
			{
				if (End != default && value > End)
				{
					throw new InvalidSessionDuration(this);
				}

				_start = value;
			}
		}

		private DateTime _end;
		public DateTime End
		{
			get => _end;
			set
			{
				if (Start != default &&value < Start)
				{
					throw new InvalidSessionDuration(this);
				}

				_end = value;
			}
		}

		public TimeSpan Duration => End - Start;
	}
}