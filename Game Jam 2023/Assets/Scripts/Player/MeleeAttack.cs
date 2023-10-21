using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    #region Variables

    [SerializeField] private float _hitBoxSize;
    [SerializeField] private LayerMask _layerMask;
    
    private bool _isActive;
    private Collider2D[] _collidedObjects;

    #endregion

    #region Unity Methods

    private void Awake()
    {
        _isActive = true;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
            CheckCollision();
    }

    #endregion

    #region Methods

    private void CheckCollision()
    {
        if (!_isActive) return;
        
        Debug.Log("Collision Check");

        _collidedObjects = Physics2D.OverlapCircleAll(gameObject.transform.position, _hitBoxSize, _layerMask);

        int i = 0;

        while (i < _collidedObjects.Length)
        {
            Debug.Log(_collidedObjects[i].name);
            i++;
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        
        if (_isActive)
            Gizmos.DrawWireSphere(gameObject.transform.position, _hitBoxSize);
    }

    #endregion
}
