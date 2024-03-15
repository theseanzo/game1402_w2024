using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Tile
{
    public bool isWalkable;
    public Vector2Int pos;
    public Tile previousTile;
}
public class PathFinder : Singleton<PathFinder>
{
    // Start is called before the first frame update
    private Tile[,] tiles;
    private Queue<Tile> frontier;
    private List<Tile> surroundingTiles;
    public void SetGrid(int[,] grid)
    {
        tiles = new Tile[grid.GetLength(0), grid.GetLength(1)];
        for (int i = 0; i < tiles.GetLength(0); i++)
        {
            for (int j = 0; j < tiles.GetLength(1); j++)
            {
                Tile t = new Tile(); ;
                t.pos = new Vector2Int(i, j);
                //Walkable if not a wall

                //1 = wall, 6 = cone
                t.isWalkable = grid[i, j] != 1;

                tiles[i, j] = t;
            }
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
