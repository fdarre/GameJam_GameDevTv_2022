using UnityEngine;

namespace Platforms
{
    public class MovingPlatforms : MonoBehaviour
    {
        #region Serialized in Inspector
        
        [SerializeField] private Transform playerParentTransform;

        #endregion

        #region Private Methods

        /// <summary>
        /// Parent the player to the moving platform to prevent him from falling
        /// </summary>
        /// <param name="collision"></param> Information about the collision
        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                collision.gameObject.transform.parent = this.transform;
            }
        } 
    
        /// <summary>
        /// Unparent the player from the platform when leaving it
        /// </summary>
        /// <param name="collision"></param> Information about the collision
        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.collider.CompareTag("Player"))
            {
                collision.gameObject.transform.parent = playerParentTransform;
            }
        }

        #endregion
    }
}