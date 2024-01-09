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

        currentDir = new Vector2(0,0);
        rb = GetComponent<Rigidbody2D>();
        randomDirection = Random.Range(0, 4);


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(currentDir * speed * Time.deltaTime);
       
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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == LayerMask.NameToLayer("wallLay"))
        {
            Debug.Log("Collision with wall detected.");

            int newDir;
            do
            {
                newDir = Random.Range(0, 4);

            } while (newDir == randomDirection);
            randomDirection = newDir;
                moveRandomly();
            
        }
    }



}


