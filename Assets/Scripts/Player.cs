
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    public Rigidbody2D rigidbody2d;
    public float speed;
    public GameObject gameWonPanel;
    public GameObject gameLostPanel;
    private bool isGameOver = false;
    public string doorTag = "Door";
    public string enemyTag = "Enemy";
    private float horizontalInput, verticalInput;

    private void Start()
    {
        speed = 0.1f;
        rigidbody2d = gameObject.GetComponent<Rigidbody2D>();
    }


    // Update is called once per frame
    void Update()
    {
       
        if (isGameOver == true)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("space bar pressed");
            Input.ResetInputAxes();

        }
        

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        
        

    }
    void FixedUpdate()
    {

        if(horizontalInput > 0.1f || horizontalInput <0.1f)
        {
            rigidbody2d.AddForce(new Vector2(horizontalInput * speed, 0f), ForceMode2D.Impulse);
        }
        if (verticalInput > 0.1f || verticalInput < 0.1f)
        {
            rigidbody2d.AddForce(new Vector2(0f, verticalInput * speed), ForceMode2D.Impulse);
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == doorTag)
        {
            Debug.Log("Level Completed !!!");
            gameWonPanel.SetActive(true);
            isGameOver = true;
        }
        if (collision.tag == enemyTag)
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
