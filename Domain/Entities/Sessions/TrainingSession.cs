using System.Collections.Generic;
using Domain.Entities.Users;

namespace Domain.Entities.Sessions
{
	public class TrainingSession : Session
	{
		public bool IsTryoutSession { get; set; }
		public decimal Price { get; set; }
		public List<User> Players { get; set; }
		public List<User> Coaches { get; set; }
		public List<User> Volunteers { get; set; }
	}
}