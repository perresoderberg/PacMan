using PacMan.Domain.Entities;
using PacMan.Domain.Enums;

namespace PacMan.Domain.Rules;

public interface IMovementRules
{
    (Pacman Pacman, Grid Grid) Move(Pacman pacman, Grid grid, Direction? input);
}