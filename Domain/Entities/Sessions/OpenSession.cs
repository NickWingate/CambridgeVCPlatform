using System.Collections.Generic;
using Domain.Entities.Users;

namespace Domain.Entities.Sessions
{
	public class OpenSession : Session
	{
		public bool IsTryoutSession { get; set; }
		public decimal Price { get; set; }
		public int PlayerCapacity { get; set; }
		public List<User> Players { get; set; }
	}
}