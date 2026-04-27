namespace PacMan.Domain.ValueObjects;

public readonly record struct Position(int X, int Y)
{
    public Position Move(int x, int y) => new(X + x, Y + y);
}