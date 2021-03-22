using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    List<Transform> _waypoints;
    WaveConfig _waveConfig;
    int waypointIndex = 0;
    float moveSpeed => _waveConfig.GetMoveSpeed();

    private void Start()
    {
        transform.position = _waypoints[waypointIndex].position;
    }

    private void Update()
    {
        Move();
    }

    public void SetWaveConfig(WaveConfig waveConfig)
    {
        _waveConfig = waveConfig;
        _waypoints = _waveConfig.GetWaypoints();
    }

    private void Move()
    {
        if (waypointIndex <= _waypoints.Count - 1)
        {
            var targetPosition = _waypoints[waypointIndex].transform.position;
            var movementThisFrame = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, movementThisFrame);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
