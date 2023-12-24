using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snakeController : MonoBehaviour
{
    float speed = 3.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(speed * Time.deltaTime, 0, 0);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, -speed * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, speed * Time.deltaTime, 0);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "wall") 
        {
            Debug.Log("hit wall");

            if (Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(-speed * Time.deltaTime, 0, 0);
            }
            if (Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(0, speed * Time.deltaTime, 0);
            }
            if (Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(0, -speed * Time.deltaTime, 0);
            }
        }
    }
}
