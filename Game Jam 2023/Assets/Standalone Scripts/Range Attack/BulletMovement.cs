using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    [SerializeField] private float range;
    [SerializeField] private float speed;

    private Rigidbody2D rb;

    private Vector2 startPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularDrag = 0;
        rb.gravityScale = 0;

        Despawn();
    }
    public void Update()
    {
        float distance = Vector2.Distance(startPosition, transform.position);

        if (distance < range) return;

        Despawn();
    }

    public void SetPosition(Vector2 position)
    {
        transform.position = position;

        startPosition = position;
    }

    public void Shoot(Vector2 direction)
    {
        Shoot(direction, speed);
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
