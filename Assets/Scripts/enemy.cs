using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public RecursiveMazeGenerator r;
    public Vector2 currentDir;
  
    void Start()
    {
        currentDir = getStartPos();  
    }

    
    void Update()
    {
        
    }

     Vector2 getStartPos()
    {
        Vector2 startPos;
        int width = r.screenWidth;
        int height = r.screenHeight;
        int[,] maze = r.maze;
        while (true)
        {
            float x = Random.Range(-width/ 2, width / 2);
            float y = Random.Range(-height / 2, height / 2);
            if (maze[(int)(x + width / 2), (int)(y + height / 2)] == 1)
            {
                startPos = new Vector2(x, y);
                return startPos;
            }
             
            
        }
        
    }
}
