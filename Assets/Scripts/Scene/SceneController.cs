using UnityEngine; //necessary for Application.Quit()
using UnityEngine.InputSystem;
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
            Invoke(nameof(LoadFirstLevel), 1f);
        }

        public void GoToMenu()
        {
            Invoke(nameof(LoadMainMenu), 1f);
        }
        
        /// <summary>
        /// Called through an event from the input system
        /// </summary>
        /// <param name="context"></param> Information about the event
        public void GoToMenuThroughInputAction(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                Invoke(nameof(LoadMainMenu), 1f);
            }
            
        }

        public void GoToGameOverScreen()
        {
            Invoke(nameof(LoadGameOverScreen), 1f);
        }
        
        public void GoToWinScreen()
        {
            Invoke(nameof(LoadWinScreen), 1f);
        }

        public void ExitGame()
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
#else
                        Application.Quit(); 
            #endif
        }
        
        #endregion
        
        #region Init - Ovveride generic singleton

        //protected override bool DestroyOnLoad => true;
        
        #endregion

        #region Private Methods
        
        //Separate methods are declared to be able to call
        //by string name with invoke
        //@todo: find alternative 
        private void LoadNextScene()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        
        private void LoadFirstLevel()
        {
            SceneManager.LoadScene(1);
        }
        
        private void LoadMainMenu()
        {
            SceneManager.LoadScene(0);
        }
        
        private void LoadWinScreen()
        {
            SceneManager.LoadScene(5);
        } 
        
        private void LoadGameOverScreen()
        {
            SceneManager.LoadScene(4);
        }

        #endregion
    }
}