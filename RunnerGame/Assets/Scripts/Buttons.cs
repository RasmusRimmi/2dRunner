using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public PlayerScript player;
    public ObjectGenerator ObjGen;

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
        //DestroyAll("Spike");
        player.isAlive = true;
        player.scoreCanvas.SetActive(true);
        player.gameOverCanvas.SetActive(false);
        //ObjGen.GenerateNextSpikeWithGap();
        Time.timeScale = 1;
        //ObjGen.generateSpike();
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
