using Unity.VisualScripting;
using Unity.VisualScripting.Dependencies.NCalc;
using UnityEngine;

namespace Audio
{
    public class BackgroundMusic : MonoBehaviour
    {
        [SerializeField] private AudioClip mainTheme;

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        private void Start()
        {
            if(!_audioSource.isPlaying)
            {
                _audioSource.PlayOneShot(mainTheme);
            }
            
        }
    

        private AudioSource _audioSource;
    }
}
