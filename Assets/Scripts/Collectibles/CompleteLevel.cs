using UnityEngine;
using UnityEngine.SceneManagement;
using Scene;

namespace Collectibles
{
    public class CompleteLevel : MonoBehaviour
    {
        #region Serialized in Inspector

        [SerializeField] private int totalNbOfFeathers;

        #endregion
    
        #region Public Methods

        public void AddFeather()
        {
            pickedUpFeathers++;

            if (pickedUpFeathers != totalNbOfFeathers) return;
        
            //if it is the last level - Win the game
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneController.Instance.GoToWinScreen();
            }
            //else go to next level
            else
            {
                SceneController.Instance.CompleteLevel(1f);
            }
        }

        #endregion

        #region Private Variables

        private int pickedUpFeathers = 0;

        #endregion
    }
}
