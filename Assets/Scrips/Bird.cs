using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Bird : MonoBehaviour
{
    private Rigidbody2D Rigidbody2D;
    public float JumpForce;
    private bool levelStart;
    public GameObject GameController;
    public GameObject message;
    private int score;
    //public Text scoreText;
    private SpriteRenderer renderer;
    public Sprite birdUpSprite;
    public Sprite birdMidSprite;
    public Sprite birdDownSprite;


    private void Awake()
    {
        Rigidbody2D = this.gameObject.GetComponent<Rigidbody2D>();
        renderer = this.gameObject.GetComponent<SpriteRenderer>();
        levelStart = false;
        Rigidbody2D.gravityScale = 0;
        score = 0;
        //scoreText.text = score.ToString();
 
    }

    // Update is called once per frame
    void Update()
    {
        // Kiểm tra phim space được bấm ko
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Soundcontroller.instance.playThisSound("wing", 0.5f);
            if (!levelStart)
            {
                levelStart = true;
                Rigidbody2D.gravityScale = 4;
                GameController.GetComponent<PipeGenerator>().enableGenerating = true;
                message.GetComponent<SpriteRenderer>().enabled = false;
                ScoreDisplay.instance.UpdateScore(score);
            }
            BridMoveUp();
        }
        if (Rigidbody2D.velocity.y > 0)
        {
            renderer.sprite = birdUpSprite;
            transform.rotation = Quaternion.Euler(0, 0, 40);
        }
        else if (Rigidbody2D.velocity.y < 0)
        {
            renderer.sprite = birdDownSprite;
            transform.rotation = Quaternion.Euler(0, 0, -40);
        }
        else if (Rigidbody2D.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            renderer.sprite = birdMidSprite;
        }

    }

    private void BridMoveUp()
    {
        Rigidbody2D.velocity = Vector2.up * JumpForce;
    }

    // method goi khi xay ra va cham
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Soundcontroller.instance.playThisSound("hit", 0.5f);
        //Hien thi Cac Lua Chon Play  
        reloadScene();
        score = 0;
    }

    // Method goi khi chim di qua ong
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Soundcontroller.instance.playThisSound("point", 0.5f);
        score += 1;
        ScoreDisplay.instance.UpdateScore(score);
        //scoreText.text = score.ToString();
    }

    void reloadScene()
    {
        SceneManager.LoadScene("_gameplay");
    }



}
