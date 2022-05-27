using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        #region Serialize in Inspector
        
        [SerializeField] private GameObject particlePrefab;
        [SerializeField] private Transform bulletContainer;
        [SerializeField] private Transform particleStartPosition;
        [SerializeField] private AudioClip playerShootFx;
        
        #endregion

        #region Init

        private void Awake()
        {
            _audioSource = GetComponent<AudioSource>();
        }

        #endregion

        #region Public Methods
        
        /// <summary>
        /// Called by Input System Event when fire input from player
        /// </summary>
        /// <param name="context"></param> Information about the event
        public void FireParticle(InputAction.CallbackContext context)
        {
            if (context.performed)
            {
                InstantiateStarBullet();
                PlayShootingSoundFx();
            }
        }
        
        #endregion

        #region Private Methods

        private void InstantiateStarBullet()
        {
            Instantiate<GameObject>(particlePrefab, particleStartPosition.position, Quaternion.identity, bulletContainer);
        }
        
        private void PlayShootingSoundFx()
        {
            _audioSource.PlayOneShot(playerShootFx);
        }

        #endregion

        #region Private Variables

        private AudioSource _audioSource;

        #endregion
    }
}
