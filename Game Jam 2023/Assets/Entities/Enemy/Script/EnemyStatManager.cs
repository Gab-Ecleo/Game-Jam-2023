using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatManager : MonoBehaviour
{
    #region Variables
    
    public static EnemyStatManager Instance;
    public EnemyStats[] _enemyStats;

    #endregion

    #region Class
    
    [System.Serializable]
    public class EnemyStats
    {
        [Header("Basic Stats")]
        public string _EnemyType;
        public float _healthPoints;

        //[Header("NavMesh Stats")]       
        public float _speed;
        public float _stoppingDistance;

        public float SetHealth()
        {
            return _healthPoints;
        }
    }

    #endregion

    #region UnityMethods

    private void Awake()
    {
        Instance = this;
    }

    #endregion
}
