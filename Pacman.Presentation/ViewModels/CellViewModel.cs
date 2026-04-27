using PacMan.Domain.Entities;
using PacMan.Domain.Enums;
using PacMan.Domain.ValueObjects;
using PacMan.Presentation.ViewModels;

public class CellViewModel : ViewModelBase
{
    private Tile _tile;
    private bool _hasPacman;
    private Direction _direction;

    public int X { get; }
    public int Y { get; }

    public bool HasDot => _tile.Type == TileType.Dot;
    public bool IsWall => _tile.Type == TileType.Wall;
    public bool HasPacman => _hasPacman;

    public double Rotation => _direction switch
    {
        Direction.Right => 0,
        Direction.Down => 90,
        Direction.Left => 180,
        Direction.Up => 270,
        _ => 0
    };

    public CellViewModel(Position pos, Tile tile)
    {
        X = pos.X;
        Y = pos.Y;
        _tile = tile;
    }

    public void Update(Tile tile, bool hasPacman, Direction direction)
    {
        if (_hasPacman)
            ;

        _tile = tile;
        _hasPacman = hasPacman;
        _direction = direction;

        OnPropertyChanged(nameof(HasDot));
        OnPropertyChanged(nameof(IsWall));
        OnPropertyChanged(nameof(HasPacman));
        OnPropertyChanged(nameof(Rotation));
    }
}