using UnityEngine;

namespace Platforms
{
    //@Todo: Create utility class for waypoint handling
    public class MovingPlatforms : MonoBehaviour
    {
        #region Serialized in Inspector

        [SerializeField] private float speed = 5f;
        [SerializeField] private Transform[] waypoints;
        [SerializeField] private Transform playerParentTransform;

        #endregion

        #region Update

        private void Update()
        {
            float step = speed * Time.deltaTime;

            if (transform.position != waypoints[_nextWaypointIndex].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, waypoints[_nextWaypointIndex].position, step);
            }
            else
            {
                SetNextWaypointIndex();
            }
        }

        #endregion

        #region Private Methods

        private void SetNextWaypointIndex()
        {
            _nextWaypointIndex += 1;
        
            if (_nextWaypointIndex > waypoints.Length - 1)
            {
                _nextWaypointIndex = 0;
            }
        }
    
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

        #region Private variables

        private int _nextWaypointIndex = 0;

        #endregion
    }
}