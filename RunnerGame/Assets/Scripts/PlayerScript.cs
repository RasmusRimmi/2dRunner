using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    public float jumpForce;
    public float score;
    
    [SerializeField] 
    bool isGrounded = false;
    
    public bool isAlive = true;

    Rigidbody2D rb;

    public TMP_Text scoreText;
    public TMP_Text totalScore;

    public GameObject scoreCanvas;
    public GameObject gameOverCanvas;

    public ObjectGenerator oGenerator;

    SaveManager saveManager;

    private void Awake()
    {
        scoreCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    private void Start()
    {
        saveManager = FindObjectOfType<SaveManager>();
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(isGrounded == true)
            {
                rb.AddForce(Vector2.up * jumpForce);
                anim.SetBool("IsJumping", true);
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
                anim.SetBool("IsJumping", false);
            }
        }

        if (collision.gameObject.CompareTag("Spike"))
        {
            saveManager.SaveHighScore();
            isAlive = false;
            Time.timeScale = 0;
            scoreCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            totalScore.text = "Score: " + score.ToString("F0");
        }
    }
}
