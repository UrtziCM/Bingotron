using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    static public PauseManager instance;

    public Camera camaraPrincipal;

    private void Awake()
    {
        instance = this;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseGame();
        }
    }

    public void PauseGame()
    {
        camaraPrincipal.gameObject.SetActive(false);
        SceneManager.LoadSceneAsync("Pause", LoadSceneMode.Additive);
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        camaraPrincipal.gameObject.SetActive(true);
        SceneManager.UnloadSceneAsync("Pause");
        Time.timeScale = 1f;
    }

}
