namespace WebApi.Models.SessionTimings
{
    public class SessionTimingReadOnlyDto
    {
        public int Id { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
