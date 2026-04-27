using PacMan.Application;
using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.ValueObjects;
using System.Collections.ObjectModel;
using DomainGrid = PacMan.Domain.Entities.Grid;

namespace PacMan.Presentation.ViewModels;

public class GameViewModel : ViewModelBase
{
    private readonly IGameEngine _engine;
    private Game _game;

    public ObservableCollection<CellViewModel> Cells { get; } = new();

    public int Width => _game.Grid.Width;
    public int Height => _game.Grid.Height;

    public GameViewModel(IGameEngine engine)
    {
        _engine = engine;
        _game = CreateInitialGame();

        InitializeCells();
    }

    private Game CreateInitialGame()
    {
        var grid = DomainGrid.CreateWithDots(20, 20);
        var pacman = new Pacman(new Position(10, 10), Direction.Right);

        return new Game(pacman, grid);
    }

    public void Move(Direction direction)
    {
        _game = _engine.Tick(_game, direction);
        UpdateCells();
    }

    private void InitializeCells()
    {
        Cells.Clear();

        for (int y = 0; y < _game.Grid.Height; y++)
        {
            for (int x = 0; x < _game.Grid.Width; x++)
            {
                var pos = new Position(x, y);
                var tile = _game.Grid.GetTile(pos);

                Cells.Add(new CellViewModel(pos, tile));
            }
        }

        UpdateCells();
    }

    private void UpdateCells()
    {
        int index = 0;

        for (int y = 0; y < _game.Grid.Height; y++)
        {
            for (int x = 0; x < _game.Grid.Width; x++)
            {
                var pos = new Position(x, y);
                var tile = _game.Grid.GetTile(pos);

                var hasPacman = _game.Pacman.Position.Equals(pos);

                Cells[index].Update(
                    tile,
                    hasPacman,
                    _game.Pacman.Direction
                );

                index++;
            }
        }
    }
}