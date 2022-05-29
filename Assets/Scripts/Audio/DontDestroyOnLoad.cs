using UnityEngine;

namespace Audio
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        #region Init

        private void Awake()
        {
            DontDestroyOnLoad(this.gameObject);
        }

        #endregion
        
    }
}
