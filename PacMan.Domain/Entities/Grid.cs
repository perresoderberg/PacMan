using PacMan.Domain.Enums;
using PacMan.Domain.ValueObjects;

namespace PacMan.Domain.Entities;
public class Grid
{
    private readonly Tile[,] _tiles;

    public int Width { get; }
    public int Height { get; }

    public Grid(int width, int height, Tile[,] tiles)
    {
        if (tiles.GetLength(0) != width || tiles.GetLength(1) != height)
            throw new ArgumentException("Invalid grid dimensions");

        Width = width;
        Height = height;
        _tiles = tiles;
    }

    public Tile GetTile(Position pos)
    {
        var wrapped = Wrap(pos);
        return _tiles[wrapped.X, wrapped.Y];
    }

    public bool IsWall(Position pos) => GetTile(pos).Type == TileType.Wall;

    public Grid EatDot(Position pos)
    {
        var wrapped = Wrap(pos);

        if (_tiles[wrapped.X, wrapped.Y].Type != TileType.Dot)
            return this;

        var newTiles = (Tile[,])_tiles.Clone();

        newTiles[wrapped.X, wrapped.Y] = new Tile(TileType.Empty);

        return new Grid(Width, Height, newTiles);
    }

    public bool HasDots()
    {
        foreach (var tile in _tiles)
        {
            if (tile.Type == TileType.Dot)
                return true;
        }

        return false;
    }

    public Position Wrap(Position pos)
    {
        int x = (pos.X + Width) % Width;
        int y = (pos.Y + Height) % Height;

        return new Position(x, y);
    }

    public static Grid CreateEmpty(int width, int height)
    {
        var tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                tiles[x, y] = new Tile(TileType.Empty);

        return new Grid(width, height, tiles);
    }

    public static Grid CreateWithDots(int width, int height)
    {
        var tiles = new Tile[width, height];

        for (int x = 0; x < width; x++)
            for (int y = 0; y < height; y++)
                tiles[x, y] = new Tile(TileType.Dot);

        return new Grid(width, height, tiles);
    }
    public IEnumerable<Position> GetAllPositionsOfType(TileType type)
    {
        for (int x = 0; x < Width; x++)
        {
            for (int y = 0; y < Height; y++)
            {
                if (_tiles[x, y].Type == type)
                {
                    yield return new Position(x, y);
                }
            }
        }
    }
}