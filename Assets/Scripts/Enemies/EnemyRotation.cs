using System;
using UnityEngine;
using Utilities;

namespace Enemies
{
    public class EnemyRotation : MonoBehaviour
    {

        #region Init

        private void Awake()
        {
            _transform = GetComponent<Transform>();
            _waypointMovements = GetComponent<WaypointMovements>();
        }

        #endregion

        #region Update

        private void Update()
        {
            SetTransformForward();
        }

        #endregion
        
        #region Private Methods

        private void SetTransformForward()
        {
            float nextWaypointXPosition = _waypointMovements.NextWaypoint.position.x;
            
            if (_transform.position.x > nextWaypointXPosition)
            {
                //Rotate transform to face left
                _transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            else
            {
                //Rotate transform to face right
                _transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            
        }

        #endregion

        #region Private Variables

        private Transform _transform;
        private WaypointMovements _waypointMovements;

        #endregion
    }
}
