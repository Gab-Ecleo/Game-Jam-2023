using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatManager : MonoBehaviour
{
    #region Variables
    
    public static EnemyStatManager instance;

   //[Header("Melee Enemy")] 
    public float _speed;
    public float _stoppingDistance;
    public float _healthPoints;
    
    #endregion

    #region UnityMethods

    private void Awake()
    {
        if (instance != this)
            Destroy(gameObject);
        instance = this;
    }

    #endregion
    
    public void MeleeEnemy() {}
    
    
}
