using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public RecursiveMazeGenerator r;
    public Vector3 currentDir;
    int randomDirection;
   
    public float speed = 2.0f;
    void Start()
    {
        currentDir = getStartPos();
        randomDirection = Random.Range(0, 4);

        r = FindObjectOfType<RecursiveMazeGenerator>();


    }

    
    void FixedUpdate()
    {
        moveRandomly();

    }

     Vector2 getStartPos()
    {
        Vector2 startPos;
       
        while (true)
        {
            float x = Random.Range(-r.screenWidth / 2, r.screenWidth / 2);
            float y = Random.Range(-r.screenHeight / 2, r.screenHeight / 2);
            if (r.maze[(int)(x + r.screenWidth / 2), (int)(y + r.screenHeight / 2)] == 1)
            {
                startPos = new Vector2(x, y);
                return startPos;
            }
             
            
        }
        
    }
    void moveRandomly()
    {
        if(isValidMove(randomDirection))
        {
            switch (randomDirection)
            {
                case 0:
                    currentDir = new Vector3(0, 1,0).normalized;
                    break;
                case 1:
                    currentDir = new Vector3(1, 0,0).normalized;
                    break;
                case 2:
                    currentDir = new Vector3(0, -1,0).normalized;
                    break;
                case 3:
                    currentDir = new Vector3(-1, 0,0).normalized;
                    break;
            }
            transform.position += currentDir * speed;
        }
        else
        {
            randomDirection = Random.Range(0, 4);
        }
    }
        

    bool isValidMove(int randomDirection)
    {

        Vector3 potentialPos = transform.position + currentDir;
        float travelX = (potentialPos.x - r.centerize.x) / r.cellSize;
        float travelY = (potentialPos.y - r.centerize.y) / r.cellSize;
        if(r.maze[(int) travelX, (int) travelY] == 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

}
