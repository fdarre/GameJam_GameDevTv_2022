using UnityEngine;
using Player;

namespace Environment
{
    public class PlayerFall : MonoBehaviour
    {
        #region Serialized in Inspector

        [SerializeField] private Transform playerStartPosition;

        #endregion
        
        #region Collision

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
                playerHealth.GetHit();
                col.gameObject.transform.position = playerStartPosition.position;
            }
        }

        #endregion
    }
}
