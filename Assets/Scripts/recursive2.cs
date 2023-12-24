using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class RecursiveMazeGenerator : MonoBehaviour
{
    public int width = 10; 
    public int height = 10;
    public int screenWidth = 22;
    public int screenHeight = 10;
    public GameObject wallPrefab; 
    private int[,] maze;

    // positions
    private int[] dirX = { 0, 1, 0, -1 };
    private int[] dirY = { 1, 0, -1, 0 };

    void Start()
    {
        maze = new int[screenWidth, screenHeight];
        generateMaze(0, 0);
        drawMaze2();
    }

    void generateMaze(int x, int y)
    {
        maze[x, y] = 1; // Mark the current cell as visited (1 means visited 0 not)

       
        int[] index = { 0, 1, 2, 3 };  // used as the index for the directions array
        for (int i = 0; i < 4; i++) // randomizes the order 
        {
            int randdex = Random.Range(i, 4);
            int temp = index[i];
           index[i] = index[randdex];
           index[randdex] = temp;
        }

        //checking a neighbor of current cell (at random cause index's have been mixed up) and going down the chosen neighbor's path (recursive call) until all neighbors have been visited. Then we backtrack and check the other directions of the previous cells (for each loop) 
        foreach (int direction in index) 
        {
            int newCellx = x + dirX[direction] * 2;
            int newCelly = y + dirY[direction] * 2;

            if (isValidNeigh(newCellx, newCelly) && maze[newCellx, newCelly] == 0)
            {
                maze[newCellx - dirX[direction], newCelly - dirY[direction]] = 1; // Mark the wall as visited

                generateMaze(newCellx, newCelly);
            }
        }
    }

  
    void drawMaze2()
    {
        float cellSize = 1.0f; 
        Vector3 centerize = new Vector3(-(screenWidth - 1) * cellSize / 2, -(screenHeight - 1) * cellSize / 2, 0); // center on the game window

        for (int x = 0; x < screenWidth; x++)
        {
            for (int y = 0; y < screenHeight; y++)
            {
                if (maze[x, y] != 1)
                {
                    Vector3 pos = new Vector3(x * cellSize, y * cellSize, 0) + centerize;
                    Instantiate(wallPrefab, pos, Quaternion.identity);
                }
            }
        }
    }


    bool isValidNeigh(int x, int y)
    {
        return x >= 0 && x < screenWidth && y >= 0 && y < screenHeight;
    }

    

}
