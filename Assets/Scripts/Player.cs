using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;
    private bool isGameOver = false;
    // Start is called before the first frame update
   
    // Update is called once per frame
    void Update()
    {
        if(isGameOver == true)
        {
            return;
        }
        if(Input.GetAxis("Horizontal")>0)
        {
            rigidbody2d.velocity = new Vector2(speed, 0f);
        }
        if(Input.GetAxis("Horizontal")<0)
        {
            rigidbody2d.velocity = new Vector2(-speed, 0f);
        }
        if(Input.GetAxis("Vertical")>0)
        {
            rigidbody2d.velocity = new Vector2(0f, speed);
        }
        if(Input.GetAxis("Vertical")<0)
        {
            rigidbody2d.velocity = new Vector2(0f, -speed);
        }
        else if(Input.GetAxis("Vertical")==0 && Input.GetAxis("Horizontal")==0)
        {
            rigidbody2d.velocity = new Vector2(0f, 0f);
        }
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Door")
        {
            Debug.Log("Level Completed !!!");
            gameWonPanel.SetActive(true);
            isGameOver = true;
        }
        if (collision.tag == "Enemy")
        {
            Debug.Log("Level Lost !!!");
            gameLostPanel.SetActive(true);
            isGameOver = true;
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Debug.Log("Button Clicked");
    }
}
