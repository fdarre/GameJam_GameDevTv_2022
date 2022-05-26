using UnityEngine;

namespace Enemies
{
    public class EnemiesAI : MonoBehaviour
    {
        #region Serialized in inspector

        [SerializeField] private float speed = 5f;
        [SerializeField] private Transform[] waypoints;

        #endregion

        #region Update

        private void Update()
        {
            SetTransformForward();
        
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

        private void SetTransformForward()
        {
            if (transform.position.x > waypoints[_nextWaypointIndex].position.x)
            {
                //Rotate transform to face left
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                //Rotate transform to face right
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
        }

        private void SetNextWaypointIndex()
        {
            _nextWaypointIndex += 1;
        
            if (_nextWaypointIndex > waypoints.Length - 1)
            {
                _nextWaypointIndex = 0;
            }
        }

        #endregion

        #region Private Variables

        private int _nextWaypointIndex = 0;

        #endregion
    }
}
