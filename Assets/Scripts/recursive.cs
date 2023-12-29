using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;


    public class RecursiveMazeGenerator : MonoBehaviour
    {
        public int width = 10;
        public int height = 10;
        public int screenWidth = 26;
        public int screenHeight = 10;
        public GameObject wallPrefab;
        public GameObject snakePrefab;
        public GameObject keyPrefab;
        public int[,] maze;

        // positions
        public int[] dirX = { 0, 1, 0, -1 };
        public int[] dirY = { 1, 0, -1, 0 };

        void Start()
        {
            maze = new int[screenWidth, screenHeight];
            generateMaze(0, 0);
            drawMaze2();
        }

        void generateMaze(int x, int y)
        {
            maze[x, y] = 1; // Mark the current cell as visited (1 means visited square 0 not)


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
                    maze[newCellx - dirX[direction], newCelly - dirY[direction]] = 1; // Mark the square as visited, carves path

                    generateMaze(newCellx, newCelly);
                }
            }
        }


        void drawMaze2()
        {
            float cellSize = 1.0f;
            Vector3 centerize = new Vector3(-(screenWidth - 1) * cellSize / 2, -(screenHeight - 1) * cellSize / 2, 0); // center on the game window

            for (int x = -1; x < screenWidth + 1; x++)
            {
                for (int y = -1; y < screenHeight + 1; y++)
                {
                    Vector3 pos = new Vector3(x * cellSize, y * cellSize, 0) + centerize;

                    if (x >= 0 && y >= 0 && x < screenWidth && y < screenHeight)
                    {
                        if (maze[x, y] == 0)
                        {

                            Instantiate(wallPrefab, pos, Quaternion.identity); // walls
                        }
                    }

                    if (x == 0 & y == 0)
                    {
                        snakePrefab.transform.position = pos; // snake in bottom left
                    }
                    if (x < 0 || y < 0 || x >= screenWidth || y >= screenHeight)
                    {
                        Instantiate(wallPrefab, pos, Quaternion.identity); // border
                    }
                }
            }


            int keyCount = 0;

            while (keyCount < 3)

            {

                Vector3 keyLoc = new Vector3(Random.Range(-screenWidth / 2, screenWidth / 2), Random.Range(-screenHeight / 2, screenHeight / 2), 0); // random loc in the maze

                if (maze[(int)(keyLoc.x + screenWidth / 2), (int)(keyLoc.y + screenHeight / 2)] == 0) 
                {
                    continue;
                }
                else
                {
                    Instantiate(keyPrefab, keyLoc, Quaternion.identity);
                    keyCount++;
                }
            }




        }


        bool isValidNeigh(int x, int y)
        {
            return x >= 0 && x < screenWidth && y >= 0 && y < screenHeight;
        }



    }

