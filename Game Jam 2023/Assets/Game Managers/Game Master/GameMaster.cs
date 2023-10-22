using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMaster : MonoBehaviour
{
    [SerializeField] private GameObject[] managerPrefabs;

    private void Awake()
    {
        foreach(GameObject manager in managerPrefabs)
        {
            Instantiate(manager, transform);
        }
    }

    #region Methods
    
    
    #endregion
    
    
}
