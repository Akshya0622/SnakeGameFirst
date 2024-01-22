using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class endScreen : MonoBehaviour
{
    public Image image;
    public float flashTime = 1f; 
    public float cycle = 2f;
    
    public float timer = 0f;

    void Start()
    {
        image.enabled = false;
    }
    void Update()
    {
        timer += Time.deltaTime;

        if (timer <= flashTime)
        {
            
            image.enabled = true;
            
        }
        else if (timer <= cycle && timer > flashTime)
        {
          
                image.enabled = false;
                
            
        }
        else
        {
            timer = 0f;
            
        }
        
    }
}
