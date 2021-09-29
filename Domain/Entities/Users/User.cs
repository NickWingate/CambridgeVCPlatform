using System.Collections.Generic;

namespace Domain.Entities.Users
{
	public class User
	{
		public string Name { get; set; }
		public List<string> Roles { get; set; }
	}
}