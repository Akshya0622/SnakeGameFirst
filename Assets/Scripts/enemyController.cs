using Unity.Burst.CompilerServices;
using UnityEngine;


public class enemyController : MonoBehaviour
{
    public RecursiveMazeGenerator r;
    public float speed = 2.0f;
        
    void Start()
    {
        Vector3 initialPos = getStartPos();
        transform.position = initialPos;
       
     
    }

    // Update is called once per frame
    void Update()
    {
        moveRandomly();
    }

    void moveRandomly()
    {
        int randomDirection = Random.Range(0, 4);
        Vector3 newPosition = transform.position;
        switch (randomDirection)
        {
            case 0:
                newPosition += Vector3.up;
                break;
            case 1: newPosition += Vector3.right * speed;
                break;
            case 2: newPosition += Vector3.down * speed;
                break;
            case 3: newPosition += Vector3.left * speed ;
                break;
        }
        RaycastHit2D checkCol = Physics2D.Raycast(transform.position, newPosition - transform.position, 1.0f); // checking if there is a collision in the direction we wanna go
        if (checkCol.collider == null)
        {
            transform.position = newPosition;
        }

    }

    Vector3 getStartPos()
    {
        Vector3 startPos;
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
                startPos = new Vector3(x, y, 0);
                return startPos;
                
            }
        }
        
    }
        
        
    
}


