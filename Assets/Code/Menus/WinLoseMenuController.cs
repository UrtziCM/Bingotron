using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLoseMenuController : MonoBehaviour
{
    public void MainMenuButton()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
