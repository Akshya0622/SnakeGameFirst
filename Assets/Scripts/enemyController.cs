using Unity.Burst.CompilerServices;
using UnityEngine;


public class enemyController : MonoBehaviour
{
    public RecursiveMazeGenerator r;
    public float speed = 5.0f;
    Vector2 currentDir;

    int randomDirection;
    
    void Start()
    {

        currentDir = new Vector2(0,0);
       
      
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(currentDir * speed * Time.deltaTime);
        checkCollisions();
    }

    void moveRandomly()
    {
        
            randomDirection = Random.Range(0, 4);
           
            switch (randomDirection)
            {
            case 0:
                currentDir = new Vector2(0,1).normalized;
                break;
            case 1:
                currentDir = new Vector2(1,0).normalized;
                break;
            case 2:
                currentDir = new Vector2(0,-1).normalized;
                break;
            case 3:
                currentDir = new Vector2(-1, 0).normalized;
                break;
            }
            
            
   

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
            if (maze[(int)(x + width / 2), (int)(y + height / 2)] == 0)
            {
                continue;
            }
            else
            {
                startPos = new Vector2(x, y);
                return startPos;
                
            }
        }
        
    }

    void checkCollisions()
    {
        Debug.Log("Checking collisions");
        RaycastHit2D futCol = Physics2D.Raycast(transform.position, currentDir, .05f);
        Debug.DrawRay(transform.position, currentDir, Color.red, 0.05f);

        if (futCol.collider != null) 
        {
            Debug.Log("Collision detected with: " + futCol.collider.name);
            moveRandomly();
        }

    }



}


