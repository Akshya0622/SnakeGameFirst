using Unity.Burst.CompilerServices;
using UnityEngine;


public class enemyController : MonoBehaviour
{
    public RecursiveMazeGenerator r;
    public float speed = 2.0f;
    Vector2 currentDir;
    private Rigidbody2D rb;
    int randomDirection;
    
    void Start()
    {
        

        currentDir = getStartPos();
        rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            Debug.LogError("Rigidbody2D component not found on the GameObject.");
            return;
        }
        randomDirection = Random.Range(0, 4);
        

       


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.velocity = currentDir * speed;
       
    }

    void moveRandomly()
    {
        
            
           
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
            if (maze[(int)(x + width / 2), (int)(y + height / 2)] == 1)
            {
                startPos = new Vector2(x, y);
                return startPos;
            }
            
               
                
            
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        
            Debug.Log("Collision with wall detected." + randomDirection);

        int newDir;
            do
            {
                newDir = Random.Range(0, 4);

            } while (newDir == randomDirection);
            randomDirection = newDir;
               
        Debug.Log("New Direction" + randomDirection);
        moveRandomly();
    }
   


}


