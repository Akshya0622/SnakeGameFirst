using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{

    public float speed = 5.0f;
    private Vector2 direction;

   
    public void SetDirection(Vector2 newDirection)
    {
        direction = newDirection.normalized;
    }

    
    void Start()
    {
        
        Destroy(gameObject, 2.0f);
    }

  
    void Update()
    {
        Move();
    }

    void Move()
    {
        
        transform.Translate(direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "enemy")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
        if(other.gameObject.tag == "wall")
        {
            Destroy(gameObject);
        }
    }

}
