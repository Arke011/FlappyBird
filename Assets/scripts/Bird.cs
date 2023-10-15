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

    public GameObject yellowBird;
    public GameObject redBird;
    public GameObject blueBird;
    public GameObject night;
    public GameObject day;
    public GameObject endScreen;

    public TMP_Text birdScoreText;
    int birdScore = 0;

    int skin;
    int background;

    Rigidbody2D rb;

    
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Pipe.speed = speed;
        endScreen.SetActive(false);

        yellowBird.SetActive(false);
        blueBird.SetActive(false);
        redBird.SetActive(false);

        day.SetActive(false);
        night.SetActive(false);

        skin = UnityEngine.Random.Range(1, 4);

        

        
        if (skin == 1)
            yellowBird.SetActive(true);
        else if (skin == 2)
            blueBird.SetActive(true);
        else if (skin == 3)
            redBird.SetActive(true);

        background = UnityEngine.Random.Range(1, 3);

        if (background == 1)
            day.SetActive(true);

        if (background == 2)
            night.SetActive(true); ;
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
        GetComponent<AudioSource>().Play();
    }

    void Die()
    {
        Pipe.speed = 0;
        jumpSpeed = 0;
        rb.velocity = Vector2.zero;
        GetComponentInChildren<Animator>().enabled = false;
        Invoke("ShowMenu", 1f);
    }



    void ShowMenu()
    {
        
        endScreen.SetActive(true);
        birdScoreText.gameObject.SetActive(false);
    }

}
