using System;
using Domain.Entities.Sessions;
using Domain.Exceptions;
using FluentAssertions;
using Xunit;

namespace Domain.UnitTests.Entities.Sessions
{
	public class SessionTimingTests
	{
		[Fact]
		public void Duration_ShouldBeAccurate_ValidStartEnd()
		{
			// Arrange
			var timing = new SessionTiming();

			// Act
			timing.Start = new DateTime(2021, 12, 20, 13, 0, 0);
			timing.End = new DateTime(2021, 12, 20, 15, 30, 0);
			var duration = timing.Duration;

			// Assert	
			duration.CompareTo(new TimeSpan(2, 30, 0)).Should().Be(0);
		}

		[Fact]
		public void Duration_ShouldThrowException_EndBeforeStart()
		{
			// Arrange
			var timing = new SessionTiming();

			// Act
			timing.Start = new DateTime(2021, 12, 20, 13, 0, 0);

			var func = new Func<DateTime>(() 
				=> timing.End = new DateTime(2021, 12, 20, 12, 30, 0));
			// Assert
			func.Should().Throw<InvalidSessionDuration>();
		}
		
		[Fact]
		public void Duration_ShouldThrowException_StartBeforeEnd()
		{
			// Arrange
			var timing = new SessionTiming();

			// Act
			timing.End = new DateTime(2021, 12, 20, 13, 0, 0);

			var func = new Func<DateTime>(() 
				=> timing.Start = new DateTime(2021, 12, 20, 14, 30, 0));
			// Assert
			func.Should().Throw<InvalidSessionDuration>();
		}
	}
}