using UnityEngine;
using UnityEngine.AI;

public class MovableBeatle
{
    private NavMeshAgent _navMeshAget;
    public NavMeshObstacle _navMeshObstacel;

    private Vector3 _currentPoint;

    public MovableBeatle(NavMeshAgent navMeshAget, NavMeshObstacle navMeshObstacel)
    {
        _navMeshAget = navMeshAget;
        _navMeshObstacel = navMeshObstacel;
    }

    public void SetTargetToMove(Vector3 point, float distance = 0f)
    {
        _currentPoint = point;
        _navMeshAget.enabled = true;
        _navMeshAget.stoppingDistance = distance;
        _navMeshAget.destination = _currentPoint;
    }


    public bool TryReachDestination(float distance)
    {
        distance *= distance;
        var direction = _navMeshAget.transform.position - _currentPoint;
        var distanceToPoint = direction.sqrMagnitude;

        if (distanceToPoint <= distance)
            return true;

        return false;
    }

    public void StopMove()
    {
        _navMeshAget.enabled = false;
    }

    public void SetActiveObstacel(bool active)
    {
        _navMeshObstacel.enabled = active;
    }
}
