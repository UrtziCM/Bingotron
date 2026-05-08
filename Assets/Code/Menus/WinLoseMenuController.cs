using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseMenuController : MonoBehaviour
{
    public void ReplayButton()
    {
        SceneManager.LoadScene("ProvisionalScene");
    }

    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    void WinMenu()
    {

    }

    void LoseMenu()
    {

    }
}
