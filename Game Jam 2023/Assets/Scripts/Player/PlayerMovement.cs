using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed;

    private Rigidbody2D rb;
    private Vector2 direction;

    private bool allowMovement;

    /// <summary>
    /// Enables/Disables player movement.
    /// </summary>
    public void AllowPlayerMovement(bool allow)
    {
        allowMovement = allow;
    }

    #region Private methods
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularDrag = 0;
        rb.gravityScale = 0;
        allowMovement = true;
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        if (!allowMovement) return;

        direction.x = Input.GetAxisRaw("Horizontal");
        direction.y = Input.GetAxisRaw("Vertical");
        rb.velocity = direction.normalized * moveSpeed;
    }
    #endregion
}
