using UnityEngine;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    private PlayerScript player;

    public TMP_Text highscoreText;

    public float score;

    public float highscore;

    public int deathCount;

    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        player = FindObjectOfType<PlayerScript>();      

        if (PlayerPrefs.HasKey("Highscore"))
        {
            highscore = PlayerPrefs.GetFloat("Highscore");
        }

        if(PlayerPrefs.HasKey("Death"))
        {
            deathCount = PlayerPrefs.GetInt("Death");
        }

        highscoreText.text = highscore.ToString("F0");
    }

    // Update is called once per frame
    void Update()
    {
        if(player != null)
        {
            score = player.score;
        }       
    }

    public void SaveHighScore()
    {
        if(player.score > PlayerPrefs.GetFloat("Highscore"))
        {
            PlayerPrefs.SetFloat("Highscore", score);
        }
    }

    public void SaveDeathCount()
    {
        if (player.isAlive == false)
        {
            deathCount = deathCount + 1;
            PlayerPrefs.SetInt("Death", deathCount);
        }
    }
}
