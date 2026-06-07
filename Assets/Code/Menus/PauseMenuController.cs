using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
   public void ContinueButton()
    {
        PauseManager.instance.ResumeGame();
    }
    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings");
    }
    public void ExitButton()
    {
        Application.Quit();
    }
}
