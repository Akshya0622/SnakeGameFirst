using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using static UnityEditor.FilePathAttribute;


public class snakeController : MonoBehaviour
{
    float speed = 3.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public int health = 5;
    public healthBar healthBar;
    public GameObject laserPrefab;
    public Vector2 lastMove = Vector2.right;
    public int collectedKeys = 0;
    public GameObject eggPrefab;
    public RecursiveMazeGenerator r;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        healthBar = FindObjectOfType<healthBar>();
        healthBar.setMaxHealth(health);

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        if (Input.GetKeyDown(KeyCode.Space))
        {
            shoot(); // shoots lasers when space bar is pressed

        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x+=speed * horizontal * Time.deltaTime;
        position.y+= speed * vertical * Time.deltaTime;
        
        if (horizontal != 0 || vertical != 0)
        {
            lastMove = new Vector2(horizontal, vertical).normalized; // last time we were moving so the laser knows which direction to go
        }
        rigidbody2d.MovePosition(position); // move player
        healthBar.setHealth(health); // set health




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "key")
        {
            Destroy(collision.gameObject);
            collectedKeys++;
            if (collectedKeys == 3)
            {
               for(int i = -2; i <=3; i ++)
                {
                    Vector3 location = new Vector3((r.screenWidth + i) * r.cellSize, (r.screenHeight - 2) * r.cellSize, 0) + r.centerize;

                   

                    Destroy(destroyWall(location));
                    if (i == 3)
                    {
                        Instantiate(eggPrefab, location, Quaternion.identity);
                    }
                }
                   
                
            }
        }
        if (collision.gameObject.tag == "enemy")
        {
            health--;

            Debug.Log("Health: " + health);

            if(health <= 0)
            {
                SceneManager.LoadScene("LoseScreen");
            }
        }
        if(collision.gameObject.tag == "egg")
        {
            SceneManager.LoadScene("WinScreen");
        }
    }

    void shoot()
    {

        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        if (laser != null)
        {
            
            laserScript ls = laser.GetComponent<laserScript>();

            if (ls != null)
            {
                ls.SetDirection(lastMove);
            }
            else
            {
                Debug.LogError("if u get a null error the script is acting weird");
            }
        }
        else
        {
            Debug.LogError("if u get a null error prefab is acting weird");
        }
    }
    GameObject destroyWall(Vector3 location)
    {
        RaycastHit2D findWall = Physics2D.Raycast(location, Vector2.zero);
      
        if (findWall.collider != null)
        {
            return findWall.collider.gameObject;
           
        }
        else
        {
            Debug.LogWarning("No wall found");
            return null;
        }
        

    }
}
