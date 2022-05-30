using UnityEngine;
using UnityEngine.SceneManagement;
using Scene;
using UI;

namespace Collectibles
{
    public class CompleteLevel : MonoBehaviour
    {
        #region Serialize in Inspector

        [SerializeField] private int totalNbOfFeathers;
        [SerializeField] private FeatherCount featherCountComponent;
        
        #endregion
        
        #region Public Methods

        public void AddFeather()
        {
            _pickedUpFeathers++;
            featherCountComponent.SetFeatherCount(_pickedUpFeathers, totalNbOfFeathers);

            if (_pickedUpFeathers != totalNbOfFeathers) return;
        
            //if it is the last level - Win the game
            if (SceneManager.GetActiveScene().buildIndex == 3)
            {
                SceneController.Instance.GoToWinScreen();
            }
            //else go to next level
            else
            {
                SceneController.Instance.CompleteLevel(0.8f);
            }
        }

        #endregion

        #region Init

        private void Start()
        {
            featherCountComponent.SetFeatherCount(_pickedUpFeathers, totalNbOfFeathers);
        }

        #endregion

        #region Private Variables

        private int _pickedUpFeathers = 0;

        #endregion
    }
}
