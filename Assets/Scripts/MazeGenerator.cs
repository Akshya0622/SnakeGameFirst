using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int rows = 10;
    public int columns = 10;
    public GameObject wall;
    public float cellSize = 1f;
    private bool[,] visited;
    private Stack<Vector2Int> stack;
   public void Start()
    {
        generateMaze();
    }

   public void generateMaze()
    {
        visited = new bool[rows, columns]; // maze grid that keeps track of visited cells
        stack = new Stack<Vector2Int>();

        Vector2Int startPos = new Vector2Int(Random.Range(0, rows), Random.Range(0, columns));
        stack.Push(startPos);//adding the random start cell to the stack

        // keeps popping cells off the stack until we find one with unvisited neighbors, backtracking to the last place where there are paths that haven't been carved
        while (stack.Count > 0) 
        {
            Vector2Int currentPos = stack.Pop(); 
            
            if (!visited[currentPos.x, currentPos.y])
            {
                visited[currentPos.x, currentPos.y] = true; 
                List<Vector2Int> neighbors = getUnvisitedNeighbors(currentPos); // method that gives us a list of unvisited neighbors

                if(neighbors.Count > 0 ) 
                {
                    stack.Push(currentPos); // push the current cell back onto the stack for backtracking
                    Vector2Int randSelectedNeighbor = neighbors[Random.Range(0, neighbors.Count)];

                    //carvePath(currentPos, randSelectedNeighbor); //method that removes the wall between the current cell and the chosen neighbor
                    PlaceSquareBlock(currentPos);
                    stack.Push(randSelectedNeighbor);

                  
                }
            }

        }
    }

    public List<Vector2Int> getUnvisitedNeighbors(Vector2Int currentCell)
    {
        List<Vector2Int> neighbors = new List<Vector2Int> ();

        for(int i = -1; i<=1; i+=2)
        {
            int neighborX = currentCell.x + i;
            if(neighborX >=0 && neighborX < rows && !visited[neighborX, currentCell.y])
            {
                neighbors.Add(new Vector2Int(neighborX, currentCell.y));
            }
        }


        for (int j = -1; j <= 1; j += 2)
        {
            int neighborY = currentCell.y + j;
            if (neighborY >= 0 && neighborY < columns && !visited[currentCell.x, neighborY])
            {
                neighbors.Add(new Vector2Int(currentCell.x, neighborY));
            }
        }

        return neighbors;
    }
   public void carvePath(Vector2Int currentCell, Vector2Int neighbor)
    {
        Vector3 wallPos = new Vector3((currentCell.x + neighbor.x) * 0.5f * cellSize, (currentCell.y + neighbor.y) * 0.5f * cellSize, 0f);
        Instantiate(wall, wallPos, Quaternion.identity);
    
    }
    public void PlaceSquareBlock(Vector2Int currentCell)
    {
        Vector3 blockPos = new Vector3((currentCell.x) * cellSize, (currentCell.y) * cellSize, 0f);
        Instantiate(wall, blockPos, Quaternion.identity);
    }
    
}


/* 
 for(int i = currentCell.x - 1; i <= currentCell.x + 1; i ++)
        {
            for(int j = currentCell.y - 1; j <= currentCell.y + 1; j ++)
            {
                if(i == currentCell.x && j == currentCell.y)
                {
                    continue;
                }

                if(i >= 0 && i < rows && j >=0 && j < columns)
                {
                    if (!visited[i, j])
                    {
                        neighbors.Add(new Vector2Int(i, j));
                    }
                }

            }
        }*/
