using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : BulletCollision
{
    protected override void CollisionEvent(Collider2D collision)
    {
        base.CollisionEvent(collision);
        Despawn();
    }
}
