namespace Domain.Entities.Sessions
{
	public abstract class Session
	{
		public Squad Squad { get; set; }
		public SessionTiming Timing { get; set; }
		public Address Location { get; set; }
		public string Description { get; set; }
	}
}