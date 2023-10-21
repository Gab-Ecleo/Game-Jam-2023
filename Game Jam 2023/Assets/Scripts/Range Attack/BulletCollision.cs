using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCollision : MonoBehaviour
{
    private enum ObjectTag
    {
        Player,
        Enemy
    }

    [SerializeField] private ObjectTag collisionFilter;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.CompareTag(collisionFilter.ToString())) return;

        CollisionEvent();
    }

    public virtual void CollisionEvent()
    {
        Debug.Log($"COLLIDED with {collisionFilter}");
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
    }
}