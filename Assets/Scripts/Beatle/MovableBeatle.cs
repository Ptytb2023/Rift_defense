using UnityEngine;
using UnityEngine.AI;

public class MovableBeatle
{
    private BaseBeatleView _view;
    private NavMeshAgent _navMeshAget;
    public NavMeshObstacle _navMeshObstacel;

    private Vector3 _currentPoint;

    public MovableBeatle(NavMeshAgent navMeshAget, NavMeshObstacle navMeshObstacel, BaseBeatleView view)
    {
        _navMeshAget = navMeshAget;
        _navMeshObstacel = navMeshObstacel;
        _view = view;
    }

    public void SetTargetToMove(Vector3 point, float distance = 0f)
    {
        _currentPoint = point;
        _navMeshAget.enabled = true;
        _navMeshAget.stoppingDistance = distance;
        _navMeshAget.destination = _currentPoint;

        _view.SetActiovMove(true);
    }


    public bool TryReachDestination(float distance)
    {
        distance *= distance;
        var direction =   _currentPoint  - _navMeshAget.transform.position;
        var distanceToPoint = direction.sqrMagnitude;

        if (distanceToPoint <= distance)
            return true;

        return false;
    }

    public void StopMove()
    {
        _navMeshAget.enabled = false;
        _view.SetActiovMove(false);
    }

    public void SetActiveObstacel(bool active)
    {
        _navMeshObstacel.enabled = active;
    }
}
