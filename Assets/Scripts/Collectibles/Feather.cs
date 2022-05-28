using UnityEngine;
using Scene;

namespace Collectibles
{
    public class Feather : MonoBehaviour
    {
        #region Serialized in Inspector

        [SerializeField] private AudioClip pickUpSoundFx;
        [SerializeField] private CompleteLevel completeLevelConditions;

        #endregion
        
        #region Init

        private void Awake()
        {
            _audioSource = GetComponentInParent<AudioSource>();
        }

        #endregion
        
        #region Collisions

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _audioSource.PlayOneShot(pickUpSoundFx);
                Destroy(gameObject);
                completeLevelConditions.AddFeather();
            }
        }

        #endregion

        #region Private Variables

        private AudioSource _audioSource;

        #endregion
    }
}

