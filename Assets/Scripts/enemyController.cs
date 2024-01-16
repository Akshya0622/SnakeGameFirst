using System.Threading;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public RecursiveMazeGenerator r;
    public float speed = 2.0f;
    public float timer;
    public float countdownTime = 0.5f;
    int randomDirection;

    void Start()
    {
        r = FindObjectOfType<RecursiveMazeGenerator>();
        transform.position = getStartPos();
        randomDirection = Random.Range(0, 4);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("enemy"), LayerMask.NameToLayer("key"));
    }

    void FixedUpdate()
    {
        moveRandomly();
        
    }

    void moveRandomly()
    {
        
        Vector2 currentDir = Vector2.zero;

        switch (randomDirection)
        {
            case 0:
                currentDir = Vector2.up;
                break;
            case 1:
                currentDir = Vector2.right;
                break;
            case 2:
                currentDir = Vector2.down;
                break;
            case 3:
                currentDir = Vector2.left;
                break;
        }

        Vector3 change = new Vector3(currentDir.x, currentDir.y, 0);
        transform.position += change * speed * Time.deltaTime;
    }

    Vector2 getStartPos()
    {
        Vector2 startPos;
        int width = r.screenWidth;
        int height = r.screenHeight;

        while (true)
        {
            float x = Random.Range(-width / 2, width / 2);
            float y = Random.Range(-height / 2, height / 2);
            if (r.maze[(int)(x + width / 2), (int)(y + height / 2)] == 1)
            {
                startPos = new Vector2(x, y);
                return startPos;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "wall")
        {
            
            randomDirection = Random.Range(0, 4);

        }
        timer = countdownTime;
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
       
            if (timer > 0f)
            {
                timer -= Time.deltaTime;
            }
            else
            {
                randomDirection = Random.Range(0, 4);
            }
        
       
    }
}
