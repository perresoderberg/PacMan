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

    public Game With(Pacman pacman, Grid grid)
        => new Game(pacman, grid);
}