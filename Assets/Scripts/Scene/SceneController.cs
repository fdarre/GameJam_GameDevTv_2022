using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : GenericSingleton<SceneController>
{
    protected override bool DestroyOnLoad => false;

    protected override void Init()
    {
    }

    public void CompleteLevel(float delayInSeconds)
    {
        Invoke(nameof(LoadNextScene), delayInSeconds);
    }

    public void RestartGame()
    {
        Debug.Log("click");
        SceneManager.LoadScene(0);
    }

    private void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}