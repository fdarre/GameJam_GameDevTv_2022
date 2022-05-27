using UnityEngine;
using Generic;

namespace UI
{
    public class UIManager : GenericSingleton<UIManager>
    {
        #region Serialized in inspector

        [SerializeField] private Canvas winScreenCanvas;
        [SerializeField] private Canvas gameOverScreenCanvas;
        [SerializeField] private AudioClip gameOverScreenSoundFx;
        [SerializeField] private AudioClip winScreenSoundFx;
        [SerializeField] private AudioSource musicAudioSource;

        #endregion
        
        #region Public Methods

        public void LoadGameOverScreen()
        {
            musicAudioSource.Stop();
            musicAudioSource.PlayOneShot(gameOverScreenSoundFx);
            gameOverScreenCanvas.gameObject.SetActive(true);
        } 
    
        public void LoadWinScreen()
        {
            musicAudioSource.Stop();
            musicAudioSource.PlayOneShot(gameOverScreenSoundFx);
            winScreenCanvas.gameObject.SetActive(true);
        }

        #endregion

        #region Init - Ovveride generic singleton

        protected override bool DestroyOnLoad => false;

        #endregion
    }
}