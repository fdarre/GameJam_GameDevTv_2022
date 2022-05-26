using UnityEngine;
using Generic;

namespace UI
{
    public class UIManager : GenericSingleton<UIManager>
    {
        #region Serialized in inspector

        [SerializeField] private Canvas winScreenCanvas;
        [SerializeField] private Canvas gameOverScreenCanvas;

        #endregion
        
        #region Public Methods

        public void LoadGameOverScreen()
        {
            gameOverScreenCanvas.gameObject.SetActive(true);
        } 
    
        public void LoadWinScreen()
        {
            winScreenCanvas.gameObject.SetActive(true);
        }

        #endregion

        #region Init - Ovveride generic singleton

        protected override bool DestroyOnLoad => false;

        #endregion
    }
}