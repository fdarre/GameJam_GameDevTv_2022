using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    public class PlayerShooting : MonoBehaviour
    {
        #region Serialize in Inspector
        
        [SerializeField] private GameObject particlePrefab;
        [SerializeField] private Transform parent;
        [SerializeField] private Transform particleStartPosition;
        
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
            }
        }

        #endregion

        #region Private Methods

        private void InstantiateStarBullet()
        {
            Instantiate<GameObject>(particlePrefab, particleStartPosition.position, Quaternion.identity, parent);
        }

        #endregion
    }
}
