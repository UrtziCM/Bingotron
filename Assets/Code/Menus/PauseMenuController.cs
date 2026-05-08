using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
   public void ContinueButton()
    {
        Scene pause = SceneManager.GetActiveScene();
        SceneManager.UnloadSceneAsync(pause);
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
