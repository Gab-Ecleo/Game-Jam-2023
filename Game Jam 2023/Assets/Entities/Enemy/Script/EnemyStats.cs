using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyStats : MonoBehaviour
{
    #region Variables

    public enum EnemyType
    {
        Melee,
        Range
    }

    public EnemyType _enemyType;

    [SerializeField] private float _healthPoint;
    
    private int _index;
    private NavMeshAgent _agent;

    #endregion

    #region UnityMethods

    private void Awake()
    { 
        _agent = GetComponent<NavMeshAgent>();
    }

    private void Start()
    {
        var _stat = EnemyStatManager.Instance;
        
        //Set Enemy Type
        if (!gameObject.activeSelf) return;

        switch (_enemyType)
        {
            case EnemyType.Melee:
                _index = 0;
                break;
            
            case EnemyType.Range:
                _index = 1;
                break;
            
            default:
                return;
        }
        
        //set Enemy Stats
        _healthPoint = _stat._enemyStats[_index]._healthPoints;
        
        //Set NavMesh Values
        _agent.speed = _stat._enemyStats[_index]._speed;
        _agent.stoppingDistance = _stat._enemyStats[_index]._stoppingDistance; 

    }

    #endregion
}
