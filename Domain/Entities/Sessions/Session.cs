namespace Domain.Entities.Sessions
{
	public abstract class Session
	{
		public string Name { get; set; }
		public Squad Squad { get; set; }
		public SessionTiming Timing { get; set; }
		public Address Address { get; set; }
		public string Description { get; set; }
	}
}