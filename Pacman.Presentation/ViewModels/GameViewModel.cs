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
        var grid = CreateMaze();

        var pacman = CreatePacman(grid);

        return new Game(pacman, grid);
    }
    private Pacman CreatePacman(Grid grid)
    {
        var random = new Random();

        var validPositions = grid
            .GetAllPositionsOfType(TileType.Dot)
            .ToList();

        var position = validPositions[random.Next(validPositions.Count)];

        return new Pacman(position, Direction.Right);
    }
    private Grid CreateMaze()
    {
        var layout = new[]
        {
        "####################",
        "#........##........#",
        "#.####.#.##.#.####.#",
        "#o####.#.##.#.####o#",
        "#..................#",
        "#.####.##  ##.####.#",
        "#......##  ##......#",
        "######.##  ##.######",
        "      .######.      ",
        "######.######.######",
        "#........##........#",
        "#.####.#.##.#.####.#",
        "#o..##.#.##.#.##..o#",
        "###.##.######.##.###",
        "#......##  ##......#",
        "#.##########.#######",
        "#..................#",
        "####################"
    };

        int height = layout.Length;
        int width = layout[0].Length;

        var tiles = new Tile[width, height];

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {
                char c = layout[y][x];

                tiles[x, y] = c switch
                {
                    '#' => new Tile(TileType.Wall),
                    ' ' => new Tile(TileType.Empty),
                    _ => new Tile(TileType.Dot)
                };
            }
        }

        return new Grid(width, height, tiles);
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