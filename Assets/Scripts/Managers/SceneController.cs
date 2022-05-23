using UnityEngine.SceneManagement;

public class SceneController : GenericSingleton<SceneController>
{
    protected override bool DestroyOnLoad => false;

    protected override void Init()
    {
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}