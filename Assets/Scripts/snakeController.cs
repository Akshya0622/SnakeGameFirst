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
           
    }

        void FixedUpdate()
        {
            Vector2 position = rigidbody2d.position;
            position.x = position.x + speed * horizontal * Time.deltaTime;
            position.y = position.y + speed * vertical * Time.deltaTime;

            rigidbody2d.MovePosition(position);
            healthBar.setHealth(health);
            if(Input.GetKeyDown(KeyCode.W))
            {
                shootLaser(Vector3.up);
            }
            else if (Input.GetKeyDown(KeyCode.S))
            {
                shootLaser(Vector3.down);
            }
            else if (Input.GetKeyDown(KeyCode.D))
            {
                shootLaser(Vector3.right);
            }
            else if (Input.GetKeyDown(KeyCode.A))
            {
                shootLaser(Vector3.left);
            }



    }
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.tag == "key")
            {
                Destroy(collision.gameObject);
            }
            if(collision.gameObject.tag == "enemy")
            {
            health--;
          
            Debug.Log(health);
            }
        }
        
        public void shootLaser(Vector3 laserDirection)
        {
        GameObject laser = Instantiate(laserPrefab, transform.position, Quaternion.identity);
        laser.GetComponent<laserScript>().setDir(laserDirection);
        }

    }
