using UnityEngine.SceneManagement;
using Generic;

namespace Scene
{
    public class SceneController : GenericSingleton<SceneController>
    {
        #region Public Methods

        public void CompleteLevel(float delayInSeconds)
        {
            Invoke(nameof(LoadNextScene), delayInSeconds);
        }

        public void RestartGame()
        {
            //Load first level
            SceneManager.LoadScene(0);
        }

        #endregion
        
        #region Init - Ovveride generic singleton

        protected override bool DestroyOnLoad => false;
        
        #endregion

        #region Private Methods

        private void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        #endregion
    }
}