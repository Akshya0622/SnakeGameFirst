using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserScript : MonoBehaviour
{

    public float speed = 6f;
    private Vector3 direction;

    public void setDir (Vector3 dir)
    {
        direction = dir;
    }
    public void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            Destroy(collision.gameObject); 
            Destroy(gameObject); 
        }
    }
}
