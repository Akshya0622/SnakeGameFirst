using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ImageFlasher : MonoBehaviour
{
    public Image image;
    public float flashTime = 1f; 
    public float cycle = 2f; 

    private float timer = 0f;
    private bool isVisible = false;

    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= flashTime)
        {
            
            image.enabled = true;
            isVisible = true;
        }
        else if (timer <= cycle)
        {
            
            if (isVisible)
            {
                image.enabled = true;
            }
            else
            {
                image.enabled = false;
            }
        }
        else
        {
            
            timer = 0f;
            isVisible = false;
        }
    }
}
