using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;


public class Bird : MonoBehaviour
{
    
    public float jumpSpeed;
    public float rotatePower;
    public float speed;

    //public GameObject endScreen;

    
    public GameObject night;
    public GameObject day;
    public GameObject endScreen;
    public GameObject flashEffect;
    public GameObject tutorial;

    public AudioSource wingSound;
    public AudioSource deathSound;
    public AudioSource scoreSound;
    bool firstPress;
    

    
    

    public TMP_Text birdScoreText;
    int birdScore = 0;

   
    int skin;
    int background;

    Rigidbody2D rb;

    
    
    void Start()
    {
        firstPress = true;
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = 0;
        endScreen.SetActive(false);

        

        day.SetActive(false);
        night.SetActive(false);

        skin = UnityEngine.Random.Range(1, 3);

        




        

        background = UnityEngine.Random.Range(1, 3);

        if (background == 1)
            day.SetActive(true);

        if (background == 2)
            night.SetActive(true); 
    }


    void Update()
    {
        if (firstPress == true)
        {
            tutorial.SetActive(true);
        }
        if (firstPress == false)
        {
            tutorial.SetActive(false);
        }
        

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                firstPress= false;
                Pipe.speed = 5;
                rb.gravityScale = 3;
                birdScoreText.gameObject.SetActive(true);
                rb.velocity = Vector2.up * jumpSpeed;
                
                wingSound.Play();
            }  

            transform.eulerAngles = new Vector3(0, 0, rb.velocity.y * rotatePower);

            if (transform.position.y < -2.25f)
            {
                Pipe.speed = 0;
                transform.position = new Vector3(transform.position.x, -2.25f, transform.position.z);
                rb.velocity = Vector2.zero; 
            }
        
    }


    void OnCollisionEnter2D(Collision2D other)
    {
        Die();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        birdScore++;
        birdScoreText.text = birdScore.ToString();
        scoreSound.Play();
        
        
    }

    void Die()
    {
        birdScoreText.gameObject.SetActive(false);
        Pipe.speed = 0;
        jumpSpeed = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;
        Collider2D[] colliders = GetComponentsInChildren<Collider2D>();
        foreach (Collider2D collider in colliders)
        {
            collider.isTrigger = true;
        }

        Invoke("ShowMenu", 1f);

        PlayerPrefs.SetInt("mybirdscore", birdScore);

        flashEffect.SetActive(true);
        deathSound.Play();
    }



    void ShowMenu()
    {
        
        endScreen.SetActive(true);
        birdScoreText.gameObject.SetActive(false);
    }

   

}
