using UnityEngine;
using TMPro;

namespace UI
{
    public class PlayerLives : MonoBehaviour
    {
        #region Public Methods

        public void SetPlayerLives(int currentLives)
        {
            _uiText.SetText(currentLives.ToString());
        }

        #endregion
        
        #region Init

        private void Awake()
        {
            _uiText = GetComponentInChildren<TextMeshProUGUI>();
        }

        #endregion

        #region Private Variables

        private TextMeshProUGUI _uiText;

        #endregion
    }
}
