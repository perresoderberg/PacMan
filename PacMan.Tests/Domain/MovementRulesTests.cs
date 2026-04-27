using FluentAssertions;
using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.Rules;
using PacMan.Domain.ValueObjects;
using Xunit;

public class MovementRulesTests
{
    private readonly MovementRules _rules = new();

    [Fact]
    public void Move_Right_ShouldIncreaseX()
    {
        var grid = Grid.CreateWithDots(5, 5);
        var pacman = new Pacman(new Position(1, 1), Direction.Right);

        var (updated, _) = _rules.Move(pacman, grid, Direction.Right);

        updated.Position.Should().Be(new Position(2, 1));
    }

    [Fact]
    public void Move_Up_ShouldDecreaseY()
    {
        var grid = Grid.CreateWithDots(5, 5);
        var pacman = new Pacman(new Position(2, 2), Direction.Up);

        var (updated, _) = _rules.Move(pacman, grid, Direction.Up);

        updated.Position.Should().Be(new Position(2, 1));
    }

    [Fact]
    public void Move_ShouldWrapAroundGrid()
    {
        var grid = Grid.CreateWithDots(5, 5);
        var pacman = new Pacman(new Position(4, 2), Direction.Right);

        var (updated, _) = _rules.Move(pacman, grid, Direction.Right);

        updated.Position.Should().Be(new Position(0, 2));
    }

    [Fact]
    public void Move_ShouldEatDot()
    {
        var grid = Grid.CreateWithDots(5, 5);
        var pacman = new Pacman(new Position(1, 1), Direction.Right);

        var (_, updatedGrid) = _rules.Move(pacman, grid, Direction.Right);

        updatedGrid.GetTile(new Position(2, 1)).Type.Should().Be(TileType.Empty);
    }
}