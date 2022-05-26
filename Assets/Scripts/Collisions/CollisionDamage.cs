using UnityEngine;
using Player;

namespace Collisions
{
    public class CollisionDamage : MonoBehaviour
    {
        #region Init

        private void Start()
        {
            _playerHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>();
        }

        #endregion

        #region Collisions

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                _playerHealth.GetHit();
            }
        }

        #endregion
        
        #region Private Variables

        private PlayerHealth _playerHealth;

        #endregion
    }
}
