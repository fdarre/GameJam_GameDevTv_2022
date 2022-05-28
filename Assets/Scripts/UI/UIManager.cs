using UnityEngine;
using Generic;

namespace UI
{
    public class UIManager : GenericSingleton<UIManager>
    {
        #region Serialized in inspector

        [SerializeField] private AudioClip gameOverScreenSoundFx;
        [SerializeField] private AudioClip winScreenSoundFx;

        #endregion
        

        #region Init - Ovveride generic singleton

        //protected override bool DestroyOnLoad => false;

        protected override void Awake()
        {
            base.Awake();
            _musicAudioSource = GameObject.FindObjectOfType<AudioSource>();
        }

        #endregion

        #region Private Variables

        private AudioSource _musicAudioSource;

        #endregion
    }
}