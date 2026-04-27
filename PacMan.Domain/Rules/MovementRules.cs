using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.ValueObjects;

namespace PacMan.Domain.Rules;

public class MovementRules : IMovementRules
{
    public (Pacman Pacman, Grid Grid) Move(Pacman pacman, Grid grid, Direction? input)
    {
        var direction = input ?? pacman.Direction;

        var nextPosition = GetNextPosition(pacman.Position, direction);
        var wrapped = grid.Wrap(nextPosition);

        // Wall check
        if (grid.IsWall(wrapped))
        {
            // Cannot move, but direction may change
            return (pacman.WithDirection(direction), grid);
        }

        // Move + eat dot
        var updatedGrid = grid.EatDot(wrapped);

        var updatedPacman = pacman
            .WithPosition(wrapped)
            .WithDirection(direction);

        return (updatedPacman, updatedGrid);
    }

    private static Position GetNextPosition(Position pos, Direction direction)
    {
        return direction switch
        {
            Direction.Up => new Position(pos.X, pos.Y - 1),
            Direction.Down => new Position(pos.X, pos.Y + 1),
            Direction.Left => new Position(pos.X - 1, pos.Y),
            Direction.Right => new Position(pos.X + 1, pos.Y),
            _ => pos
        };
    }
}