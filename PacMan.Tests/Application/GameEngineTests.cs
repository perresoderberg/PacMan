using FluentAssertions;
using PacMan.Application;
using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.Rules;
using PacMan.Domain.ValueObjects;
using Xunit;

public class GameEngineTests
{
    [Fact]
    public void Tick_ShouldDelegateToGame()
    {
        var rules = new MovementRules();
        var engine = new GameEngine(rules);

        var grid = Grid.CreateWithDots(5, 5);
        var game = new Game(new Pacman(new Position(1, 1), Direction.Right), grid);

        var result = engine.Tick(game, Direction.Right);

        result.Pacman.Position.Should().Be(new Position(2, 1));
    }
}