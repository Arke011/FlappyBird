using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    SpriteRenderer spriteRenderer; 

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>(); 
    }

    void Update()
    {
        var color = spriteRenderer.color; 
        color.a -= Time.deltaTime;
        spriteRenderer.color = color; 
    }
}
