using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Birb : MonoBehaviour
{
    Rigidbody2D RB;

    Animator playerAnimator;

    public GameObject coinP;


    public int speed;
    public float jumpSpeed;
    void Start()
    {
        Time.timeScale = 1;
        RB = GetComponent<Rigidbody2D>();
        playerAnimator = GetComponent<Animator>();
    }
    void Update()
    {
        RB.velocity = new Vector2(speed, RB.velocity.y);
        if(Input.GetMouseButtonDown(0)) {
            RB.velocity = new Vector2(RB.velocity.x, jumpSpeed);
            playerAnimator.Play("Wing");
        }
    }

    private void OnTriggerEnter2D(Collider2D collided) {
        if(collided.gameObject.CompareTag("Wall")) {
            speed = -speed;
            transform.Rotate(Vector3.up * 180);
            // GameObject pipeline = GameObject.Find("WholePipe");
            Pipelines.change = true; 
            Score.score += 1;

            SpikeController.control = true;


        } else if(collided.gameObject.CompareTag("DeadZone") || collided.gameObject.CompareTag("Spike")) {
            SceneManager.LoadScene("Altern");

        } else if(collided.gameObject.CompareTag("Coin")) {
            Score.score += 10;
            // GameObject coin = GameObject.Find("Coin");
            GameObject coin = GameObject.FindGameObjectWithTag ("Coin");
            Destroy(coin);
            float range = Random.Range(4F, -4F);
            float x = (RB.position.x > 0) ? -4.5F : 4.5F;
            Instantiate(coinP, new Vector2(x, range), Quaternion.Euler(Vector3.up * 0));
        } 
        
        
    }



}
