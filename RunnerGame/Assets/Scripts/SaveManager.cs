using UnityEngine;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private PlayerScript player;

    public float score;

    public float highscore;

    public int deathCount;

    public int coins;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;

            DontDestroyOnLoad(gameObject);
        }
        else
            Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        player = FindObjectOfType<PlayerScript>();      

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetFloat("Highscore");
        }
    }

    // Update is called once per frame
    void Update()
    {
        score = player.score;

        //if (player.isAlive == false)
        //{
        //    SaveHighScore();
        //    Debug.Log("Highscore saved");
        //}
    }

    public void SaveHighScore()
    {
        if(player.score > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
    }
}
