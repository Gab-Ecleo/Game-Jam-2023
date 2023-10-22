using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBulletCollision : BulletCollision
{
    protected override void CollisionEvent(Collider2D collision)
    {
        base.CollisionEvent(collision);
        HealthPoint enemyHP = collision.gameObject.GetComponent<HealthPoint>();
        if (enemyHP.IsDead()) collision.gameObject.SetActive(false);
    }
}
