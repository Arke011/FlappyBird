using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class Bird : MonoBehaviour
{
    public TMP_Text birdScoreText;
    public float jumpSpeed;
    public float rotatePower;
    int birdScore = 0;
    Rigidbody2D rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            rb.velocity = Vector2.up * jumpSpeed;
        }  

        transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        birdScore++;
        birdScoreText.text = birdScore.ToString();
    }

    void Die()
    {
        var sceneName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(sceneName);
    }

}
