using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class snakeController : MonoBehaviour
{
    float speed = 3.0f;
    Rigidbody2D rigidbody2d;
    float horizontal;
    float vertical;
    public int health = 5;
    public healthBar healthBar;
    public GameObject laserPrefab;
    public Vector2 lastNonZeroMovementDirection = Vector2.right;

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
            Shoot();

        }

    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2d.position;
        position.x = position.x + speed * horizontal * Time.deltaTime;
        position.y = position.y + speed * vertical * Time.deltaTime;
        
        if (horizontal != 0 || vertical != 0)
        {
            lastNonZeroMovementDirection = new Vector2(horizontal, vertical).normalized; // last time we were moving so the laser knows which direction to go
        }
        rigidbody2d.MovePosition(position);
        healthBar.setHealth(health);




    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "key")
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.tag == "enemy")
        {
            health--;

            Debug.Log(health);
        }
    }

    void Shoot()
    {

        GameObject laserObject = Instantiate(laserPrefab, transform.position, Quaternion.identity);

        if (laserObject != null)
        {
            // Set the direction for the laser based on player's movement
            laserScript laserScript = laserObject.GetComponent<laserScript>();

            if (laserScript != null)
            {
                laserScript.SetDirection(lastNonZeroMovementDirection);
            }
            else
            {
                Debug.LogError("Laser script not found on instantiated laser!");
            }
        }
        else
        {
            Debug.LogError("Failed to instantiate laser prefab!");
        }
    }
}
