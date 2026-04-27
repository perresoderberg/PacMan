using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.Rules;

namespace PacMan.Application;

public class GameEngine : IGameEngine
{
    private readonly IMovementRules _rules;

    public GameEngine(IMovementRules rules)
    {
        _rules = rules;
    }

    public Game Tick(Game current, Direction? input)
    {
        return current.Tick(_rules, input);
    }
}