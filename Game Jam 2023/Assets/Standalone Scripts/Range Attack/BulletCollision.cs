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
    [SerializeField] private float damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        WallCollision(collision);

        if (!collision.CompareTag(collisionFilter.ToString())) return;

        HealthPoint hp = collision.gameObject.GetComponent<HealthPoint>();
        hp.DeductHealth(damage);

        CollisionEvent(collision);
    }

    protected virtual void CollisionEvent(Collider2D collision)
    {
        Debug.Log($"COLLIDED with {collisionFilter}");
    }

    public void Despawn()
    {
        gameObject.SetActive(false);
    }

    private void WallCollision(Collider2D collision)
    {
        if (!collision.CompareTag("Wall")) return;

        this.Despawn();
    }
}
