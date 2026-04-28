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

        if (grid.IsWall(wrapped))
        {
            return (pacman.WithDirection(direction), grid);
        }

        var updatedGrid = grid.EatDot(wrapped);

        var updatedPacman = pacman
            .WithPosition(wrapped)
            .WithDirection(direction);

        return (updatedPacman, updatedGrid);
    }

    private static Position GetNextPosition(Position position, Direction direction) =>
        direction switch
        {
            Direction.Up => new Position(position.X, position.Y - 1),
            Direction.Down => new Position(position.X, position.Y + 1),
            Direction.Left => new Position(position.X - 1, position.Y),
            Direction.Right => new Position(position.X + 1, position.Y),
            _ => position
        };
}