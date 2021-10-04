using Domain.Entities.Sessions;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Entities.Sessions
{
	public class MatchTests
	{
		[Fact]
		public void IsAwayGame_ShouldBeInverseOfIsHomeGame()
		{
			// Arrange
			var match = new Match();
			
			// Act
			match.IsHomeGame = true;

			// Assert
			match.IsAwayGame.Should().BeFalse();
		}
		
		[Fact]
		public void IsAwayGame_ShouldSetHomeGameInversely()
		{
			// Arrange
			var match = new Match();
			
			// Act
			match.IsAwayGame = true;

			// Assert
			match.IsHomeGame.Should().BeFalse();
		}
	}
}