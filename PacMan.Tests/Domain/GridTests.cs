using FluentAssertions;
using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.ValueObjects;
using Xunit;

public class GridTests
{
    [Fact]
    public void Wrap_ShouldWrapNegativePosition()
    {
        var grid = Grid.CreateWithDots(5, 5);

        var result = grid.Wrap(new Position(-1, 2));

        result.Should().Be(new Position(4, 2));
    }

    [Fact]
    public void EatDot_ShouldRemoveDot()
    {
        var grid = Grid.CreateWithDots(5, 5);

        var updated = grid.EatDot(new Position(1, 1));

        updated.GetTile(new Position(1, 1)).Type.Should().Be(TileType.Empty);
    }

    [Fact]
    public void HasDots_ShouldReturnFalse_WhenNoDots()
    {
        var grid = Grid.CreateEmpty(3, 3);

        grid.HasDots().Should().BeFalse();
    }
}