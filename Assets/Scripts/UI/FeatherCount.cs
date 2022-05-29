using UnityEngine;
using TMPro;

namespace UI
{
    public class FeatherCount : MonoBehaviour
    {
        #region Public Methods

        public void SetFeatherCount(int currentNbOfFeathers, int totalNbOfFeathers)
        {
            _uiText.SetText($"{currentNbOfFeathers} / {totalNbOfFeathers}");
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
