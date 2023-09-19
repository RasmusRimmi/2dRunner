using UnityEngine;
using TMPro;

public class SaveManager : MonoBehaviour
{
    public static SaveManager Instance;

    public PlayerScript player;

    public TMP_Text highscoreText;

    public float score;

    public float highscore;

    public int deathCount;

    public int coins;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;  

        if (PlayerPrefs.HasKey("CITYRUNNER_FLOAT_HIGHSCORE"))
        {
            highscore = PlayerPrefs.GetFloat("CITYRUNNER_FLOAT_HIGHSCORE");
        }

        if(PlayerPrefs.HasKey("CITYRUNNER_INT_DEATH"))
        {
            deathCount = PlayerPrefs.GetInt("CITYRUNNER_INT_DEATH");
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
        if(player.score > PlayerPrefs.GetFloat("CITYRUNNER_FLOAT_HIGHSCORE"))
        {
            PlayerPrefs.SetFloat("CITYRUNNER_FLOAT_HIGHSCORE", score);
        }
    }

    public void SaveDeathCount()
    {
        if (player.isAlive == false)
        {
            deathCount = deathCount + 1;
            PlayerPrefs.SetInt("CITYRUNNER_INT_DEATH", deathCount);
        }
    }
}
