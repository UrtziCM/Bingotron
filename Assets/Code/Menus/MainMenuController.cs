using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{ 
    public void PlayButton()
    {
        SceneManager.LoadScene("ProvisionalScene");
    }

    public void SettingsButton()
    {
        SceneManager.LoadScene("Settings", LoadSceneMode.Additive);
    }

    public void ExitButton()
    {
        Application.Quit();
    }

    public void TutorialButton()
    {
        SceneManager.LoadScene("Tutorial");
    }

    public void CloseTutorial()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
