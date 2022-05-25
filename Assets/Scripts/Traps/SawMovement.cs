using UnityEngine;

public class SawMovement : MonoBehaviour
{
    //@Todo: Create utility class
    [SerializeField] private float speed = 5f;
    [SerializeField] private Transform[] waypoints;

    private int _nextWaypointIndex = 0;

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

    private void SetNextWaypointIndex()
    {
        _nextWaypointIndex += 1;
        
        if (_nextWaypointIndex > waypoints.Length - 1)
        {
            _nextWaypointIndex = 0;
        }
    }
}