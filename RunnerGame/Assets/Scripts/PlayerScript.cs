using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public float jumpForce;
    float score;
    
    [SerializeField] 
    bool isGrounded = false;
    bool isAlive = true;

    Rigidbody2D rb;

    public TMP_Text scoreText;
    public TMP_Text totalScore;

    public GameObject scoreCanvas;
    public GameObject gameOverCanvas;

    private void Awake()
    {
        scoreCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if(isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpForce);
                isGrounded = false;
            }
        }

        if (isAlive)
        {
            score += Time.deltaTime * 6;
            scoreText.text = "Score: " + score.ToString("F0");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            if(isGrounded == false)
            {
                isGrounded = true;
            }
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            isAlive = false;
            Time.timeScale = 0;
            scoreCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            totalScore.text = "Score: " + score.ToString("F0");
            
        }
    }
}
