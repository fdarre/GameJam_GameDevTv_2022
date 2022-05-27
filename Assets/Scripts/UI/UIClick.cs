using UnityEngine;

namespace UI
{
    public class UIClick : MonoBehaviour
    {
        #region Serilized in Inspector

        [SerializeField] private AudioClip clickSoundFx;

        #endregion
        
        #region Public Methods

        public void PlayClickSoundFx()
        {
            _audioSource.PlayOneShot(clickSoundFx);
        }

        #endregion
        
        #region Init

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion
        
        #region Private Variables

        private AudioSource _audioSource;

        #endregion
    }
}
