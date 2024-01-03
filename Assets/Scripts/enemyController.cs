using Unity.Burst.CompilerServices;
using UnityEngine;


public class enemyController : MonoBehaviour
{
    public RecursiveMazeGenerator r;
    public float speed = 2.0f;

    float timeInDirection = 5;
    float timer;
    int randomDirection;
    
    void Start()
    {
        timer = timeInDirection;
        Vector3 initialPos = new Vector3(0,0,0);
        transform.position = initialPos;
      
    }

    // Update is called once per frame
    void Update()
    {
        moveRandomly();



        
    }

    void moveRandomly()
    {
        
            randomDirection = Random.Range(0, 4);
           
            switch (randomDirection)
            {
                case 0:
                transform.position += Vector3.up * speed * Time.deltaTime;
                    break;
                case 1:
                transform.position += Vector3.right * speed * Time.deltaTime;
                break;
                case 2:
                transform.position += Vector3.down * speed * Time.deltaTime;
                    break;
                case 3:
                transform.position += Vector3.left * speed * Time.deltaTime;
                    break;
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall")
        {
            randomDirection = Random.Range(0, 4);
        }
    }



}


