using UnityEngine;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Canvas gameOverScreenCanvas;
    [SerializeField] private Canvas winScreenCanvas;

    protected override bool DestroyOnLoad => false;

    protected override void Init()
    {
    }

    public void LoadGameOverScreen()
    {
        gameOverScreenCanvas.gameObject.SetActive(true);
    } 
    
    public void LoadWinScreen()
    {
        winScreenCanvas.gameObject.SetActive(true);
    }
}