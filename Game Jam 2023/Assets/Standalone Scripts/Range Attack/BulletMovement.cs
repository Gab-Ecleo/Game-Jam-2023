using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularDrag = 0;
        rb.gravityScale = 0;

        Despawn();
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;
    }

    public void Shoot(Vector2 direction, float speed)
    {
        gameObject.SetActive(true);
        rb.velocity = direction.normalized * speed;
    }

    public void Despawn()
    {
        rb.velocity = Vector2.zero;

        gameObject.SetActive(false);
    }
}
