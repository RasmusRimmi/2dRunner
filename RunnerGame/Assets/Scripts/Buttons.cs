using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public PlayerScript player;
    public ObjectGenerator ObjGen;

    public Interstitial ads;

    public void StartGameButton()
    {
        SceneManager.LoadScene("Game");
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");
    }

    public void PlayAgainButton()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ContinueGame()
    {
        if (player.canContinue == true)
        {
            DestroyAll("Spike");
            player.isAlive = true;
            player.scoreCanvas.SetActive(true);
            player.gameOverCanvas.SetActive(false);
            //ObjGen.GenerateNextSpikeWithGap();
            //Time.timeScale = 1;
            //ObjGen.generateSpike();
            player.canContinue = false;
            player.tapText.SetActive(true);
            //ads.ShowAd();
        }
    }

    void DestroyAll(string tag)
    {
        GameObject[] spikes = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject spike in spikes)
        {
            GameObject.Destroy(spike);
        }
            
    }
}
