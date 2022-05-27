using UnityEngine;

namespace Utilities
{
    class WaypointMovements : MonoBehaviour
    {
        #region Serialized in Inspector
    
        [SerializeField] private float speed = 5f; 
        [SerializeField] private Transform[] waypoints;
    
        #endregion

        #region Public Properties

        public Transform NextWaypoint => waypoints[_nextWaypointIndex];

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

        #endregion

        #region Private variables

        private int _nextWaypointIndex = 0;

        #endregion
    }
}
    