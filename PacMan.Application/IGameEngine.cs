using PacMan.Domain.Entities;
using PacMan.Domain.Enums;

namespace PacMan.Application;

public interface IGameEngine
{
    Game Tick(Game current, Direction? input);
}