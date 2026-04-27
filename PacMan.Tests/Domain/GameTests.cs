using FluentAssertions;
using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.Rules;
using PacMan.Domain.ValueObjects;
using Xunit;

public class GameTests
{
    [Fact]
    public void Tick_ShouldMovePacman()
    {
        var rules = new MovementRules();
        var grid = Grid.CreateWithDots(5, 5);
        var game = new Game(new Pacman(new Position(1, 1), Direction.Right), grid);

        var updated = game.Tick(rules, Direction.Right);

        updated.Pacman.Position.Should().Be(new Position(2, 1));
    }
}