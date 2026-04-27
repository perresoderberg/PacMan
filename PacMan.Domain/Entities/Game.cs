using PacMan.Domain.Enums;
using PacMan.Domain.Rules;

namespace PacMan.Domain.Entities;

public class Game
{
    public Pacman Pacman { get; }
    public Grid Grid { get; }

    public bool IsGameOver => !Grid.HasDots();

    public Game(Pacman pacman, Grid grid)
    {
        Pacman = pacman;
        Grid = grid;
    }

    public Game Tick(IMovementRules rules, Direction? input)
    {
        var (pacman, grid) = rules.Move(Pacman, Grid, input);

        return new Game(pacman, grid);
    }
}