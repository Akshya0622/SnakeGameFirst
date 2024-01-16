using System.Collections;
using System.Collections.Generic;
using UnityEngine;


    public class snakeController : MonoBehaviour
    {
        float speed = 3.0f;
        Rigidbody2D rigidbody2d;
        float horizontal;
        float vertical;
        int health = 5;
   

    // Start is called before the first frame update
    void Start()
        {
            rigidbody2d = GetComponent<Rigidbody2D>();
       
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

    }
