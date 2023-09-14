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
        DestroyAll("Spike");
        player.isAlive = true;
        Time.timeScale = 1;
        player.scoreCanvas.SetActive(true);
        player.gameOverCanvas.SetActive(false);
        ObjGen.generateSpike();
    }

    void DestroyAll(string tag)
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Spike");
        foreach (GameObject enemy in enemies)
            GameObject.Destroy(enemy);
    }
}
