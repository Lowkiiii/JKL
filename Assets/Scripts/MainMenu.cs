using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("Select Level");
    }
    public void SelectLevel1()
    {
        SceneManager.LoadScene("Level1");
    }
    public void SelectLevel2()
    {
        SceneManager.LoadScene("Level2");
    }
    public void Options()
    {
        SceneManager.LoadScene("Options");
    }
    public void Settings()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
