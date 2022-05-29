using UnityEngine;
using Player;

namespace Collisions
{
    public class CollisionDamage : MonoBehaviour
    {
        #region Collisions

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player"))
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerHealth>().GetHit();
            }
        }

        #endregion
    }
}
