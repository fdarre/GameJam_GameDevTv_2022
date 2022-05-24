using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using Vector2 = System.Numerics.Vector2;

public class EnemiesAI : MonoBehaviour
{
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] waypoints;
    private int _nextWaypointIndex = 0;

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

    private void SetTransformForward()
    {
        if (transform.position.x > waypoints[_nextWaypointIndex].position.x)
        {
            transform.localRotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
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
}
