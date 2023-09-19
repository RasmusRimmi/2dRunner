using UnityEngine;
using TMPro;

public class PlayerScript : MonoBehaviour
{
    public Animator anim;
    public float jumpForce;
    public float score;
    public int death;
    
    [SerializeField] 
    bool isGrounded = false;
    
    public bool isAlive = true;
    public bool canContinue;

    Rigidbody2D rb;

    public TMP_Text scoreText;
    public TMP_Text totalScore;
    public TMP_Text highScore;

    public GameObject scoreCanvas;
    public GameObject gameOverCanvas;
    public GameObject continueCanvas;
    public GameObject tapText;

    public ObjectGenerator oGenerator;
    public AudioManager music;

    public SaveManager saveManager;
    public Interstitial ads;
    public RewardedAdsButton rewardAd;

    private void Awake()
    {
        scoreCanvas.SetActive(true);
        gameOverCanvas.SetActive(false);
        continueCanvas.SetActive(false);
        rb = GetComponent<Rigidbody2D>();
        score = 0;
    }

    private void Start()
    {
        Time.timeScale = 0;
        canContinue = true;
        rewardAd.LoadAd();
        anim.SetBool("startGame", false);
        tapText.SetActive(true);
    }

    private void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if(Time.timeScale == 0 && isAlive)
            {
                Time.timeScale = 1;
                anim.SetBool("startGame", true);
                tapText.SetActive(false);
                music.music.Play();
            }

            else if(isGrounded == true && isAlive)
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
            Time.timeScale = 0;
            isAlive = false;
            death = death + 1;
            saveManager.SaveHighScore();
            saveManager.SaveDeathCount();   
            scoreCanvas.SetActive(false);
            gameOverCanvas.SetActive(true);
            continueCanvas.SetActive(true);
            totalScore.text = "Score " + score.ToString("F0");
            music.music.Pause();
            
            if (score > saveManager.highscore)
            {
                highScore.text = "Highscore " + score.ToString("F0");
            }
            else
            {
                highScore.text = "Highscore " + saveManager.highscore.ToString("F0");
            }

            if (saveManager.deathCount % 5 == 0)
            {
                ads.ShowAd();
            }

            if(canContinue == false)
            {
                continueCanvas.SetActive(false);
            }
        }
    }
}
