using System;
using System.Collections.Generic;
using Domain.Entities.Sessions;

namespace Domain.Entities.Calendar
{
	public class Day
	{
		public List<Session> Sessions { get; set; }
		public DateOnly Date { get; set; }
	}
}