namespace Domain.Entities.Sessions
{
	public class Match : Session
	{
		public bool IsHomeGame { get; set; }

		public bool IsAwayGame
		{
			get => !IsHomeGame;
			set => IsHomeGame = !value;
		}

		public string OpponentTeam { get; set; }
		public Squad SquadPlaying { get; set; }
	}
}