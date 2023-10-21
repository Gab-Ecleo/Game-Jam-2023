using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class EnemyAI : MonoBehaviour
{
    #region Variables

    private Transform _wayPoint;
    private Transform _targetWayPoint;
    
    private NavMeshAgent _agent;
    private bool _isFollowing;
    

    #endregion

    #region Unity Methods

    private void Awake()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.updateRotation = false;
        _agent.updateUpAxis = false;
    }

    private IEnumerator Start()
    {
        _wayPoint = PlayerManager.Instance.GetPlayer().transform;
        
        while (gameObject.activeSelf)
        {
            yield return StartCoroutine(FollowWaypoint(_wayPoint));
        }
    }

    #endregion

    #region Methods

    IEnumerator FollowWaypoint(Transform _waypoint)
    {
        _targetWayPoint = _waypoint;
        
        if (!_isFollowing) yield return null;

        _agent.SetDestination(_targetWayPoint.position);
    }

    #endregion  
}
