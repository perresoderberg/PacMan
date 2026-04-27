using PacMan.Domain.Enums;
using PacMan.Domain.ValueObjects;

namespace PacMan.Domain.Entities;

public record Pacman(Position Position, Direction Direction)
{
    public Pacman WithPosition(Position position) => this with { Position = position };

    public Pacman WithDirection(Direction direction) => this with { Direction = direction };
}