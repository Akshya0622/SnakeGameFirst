using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class recursiveMaze : MonoBehaviour
{
    public int width = 10;
    public int height = 10;
    public GameObject wall;
    public float cellSize = 1f;

    private bool[,] visited;

    void Start()
    {
        generateMaze();
    }

    void generateMaze()
    {
        visited = new bool[width, height];
        CreateMaze(new Vector2Int(0, 0));

    }
    void CreateMaze(Vector2Int currentCell)
    {
        visited[currentCell.x, currentCell.y] = true;
        List<Vector2Int> neighbors = getUnvisitedNeighbors(currentCell);

        while (neighbors.Count > 0)
        {
            int randIndex = Random.Range(0, neighbors.Count);
            Vector2Int nextCell = neighbors[randIndex];
            removeWall(currentCell, nextCell);
            CreateMaze(nextCell);
            neighbors = getUnvisitedNeighbors(currentCell);
        }
    }
    List<Vector2Int> getUnvisitedNeighbors(Vector2Int currentCell)
    {
        List<Vector2Int> neighbors = new List<Vector2Int>();
       if(IsValid(currentCell.x - 2, currentCell.y) && !visited[currentCell.x-1, currentCell.y])
        {
            neighbors.Add(new Vector2Int(currentCell.x - 2, currentCell.y));
        }
        if (IsValid(currentCell.x + 2, currentCell.y) && !visited[currentCell.x + 1, currentCell.y])
        {
            neighbors.Add(new Vector2Int(currentCell.x + 2, currentCell.y));
        }
        if (IsValid(currentCell.x, currentCell.y - 2)&& !visited[currentCell.x, currentCell.y - 1])
        {
            neighbors.Add(new Vector2Int(currentCell.x, currentCell.y - 2));
        }
        if (IsValid(currentCell.x, currentCell.y + 2) && !visited[currentCell.x, currentCell.y + 1])
        {
            neighbors.Add(new Vector2Int(currentCell.x, currentCell.y + 2));
        }

        return neighbors;

    }
    bool IsValid(int x, int y)
    {
        return x >=0 && x < width && y >= 0 && y < height && !visited[x,y];
    }
    void removeWall(Vector2Int currentCell, Vector2Int neighbor)
    {
        Vector3 wallPos = new Vector3((currentCell.x + neighbor.x) * 0.5f * cellSize, (currentCell.y + neighbor.y) * 0.5f * cellSize, 0f);
        Instantiate(wall, wallPos, Quaternion.identity);
    }
}
/* if (currentCell.x > 1 && !visited[currentCell.x - 2, currentCell.y])
        {
            neighbors.Add(new Vector2Int(currentCell.x - 2, currentCell.y));

        }
        if (currentCell.y > 1 && !visited[currentCell.x, currentCell.y - 2])
        {
            neighbors.Add(new Vector2Int(currentCell.x, currentCell.y - 2));

        }
        if (currentCell.x < width - 2 && !visited[currentCell.x + 2, currentCell.y])
        {
            neighbors.Add(new Vector2Int(currentCell.x + 2, currentCell.y));
        }
        if (currentCell.y < height - 2 && !visited[currentCell.x, currentCell.y + 2])
        {
            neighbors.Add(new Vector2Int(currentCell.x, currentCell.y + 2));
        }
 */