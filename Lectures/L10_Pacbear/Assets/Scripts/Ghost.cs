using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class Ghost : BaseUnit
{
    // Start is called before the first frame update
    Vector2Int[] directions = new Vector2Int[]
    {
        new Vector2Int(0, 1),
        new Vector2Int(0, -1),
        new Vector2Int(1, 0),
        new Vector2Int(-1, 0)
    };
    private Stack<Vector2Int> path = new Stack<Vector2Int>();
    private SpawnLocation spawnLocation;
    private PacBear bear;
    private bool isReturningToSpawn;
    protected override void Start()
    {
        base.Start();
        spawnLocation = FindObjectOfType<SpawnLocation>();
        bear = FindObjectOfType<PacBear>();
    }
    // Update is called once per frame

    public void OnEnable()
    {
        PacBear.onSpecialModeSwitch += PacBear_onSpecialModeSwitch;
    }
    public void OnDisable()
    {
        PacBear.onSpecialModeSwitch -= PacBear_onSpecialModeSwitch;
    }

    private void PacBear_onSpecialModeSwitch(bool obj)
    {
        GetComponentInChildren<Renderer>().material.SetFloat("_IsGhost", obj ? 1 : 0);
    }
    public void Death()
    {
        isReturningToSpawn = true;
        GoHome();
    }
    void Update()
    {
        if (moveTimer >= 1)
        {
            if (isReturningToSpawn)
            {
                GoHome();
            }
            else
            {
                Wander();//GoToPacBear();
            }
        }
        Move();
    }
    void GoHome()
    {
        this.speed = 10;
        path = PathFinder.instance.GetPath(nextPosInGrid, spawnLocation.posInGrid);
        Vector2Int nextDestination = path.Pop();
        direction = nextDestination - nextPosInGrid;
        //we will finish this once our pathfinder is done.
        if(path.Count == 0)
        {
            isReturningToSpawn = false; //this will turn back on their 
        }
    }
    void GoToPacBear()
    {
        this.speed = 0.5f;
        path = PathFinder.instance.GetPath(nextPosInGrid, bear.posInGrid);
        if(path.Count != 0)
        {
            Vector2Int nextDestination = path.Pop();
            direction = nextDestination - nextPosInGrid;
        }
        //We will finish this code once our pathfinder is done

    }
    void Wander()
    {
        this.speed = .5f;
        List<Vector2Int> options = new List<Vector2Int>();
        foreach (Vector2Int dir in directions)
        {
            //0 = pill and 1 = wall
            //use current position where are are as nextPosInGrid + each direction to determine points around us
            int adjacentObjInGrid = GameManager.instance.grid[nextPosInGrid.x + dir.x, nextPosInGrid.y + dir.y];
            //if object is not a wall, and if direct is not the opposite of current direection (shouldn't go forward to backward)
            if (adjacentObjInGrid != 1 && dir != -direction)
            {
                options.Add(dir);
            }
        }
        if (options.Count == 0)
        {
            direction = -direction;
        }
        else
        {
            direction = options[Random.Range(0, options.Count)];
        }
    }


}
