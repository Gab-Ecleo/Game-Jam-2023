using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoint : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private bool isDead;
    private float health;

    private void Awake()
    {
        ResetHealth();
        isDead = false;
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }

    public void SetHealth(float value)
    {
        health = value < maxHealth ? value : maxHealth;
    }

    public void DeductHealth(float value)
    {
        health -= value;

        if (health > 0) return;
        health = 0;

        isDead = true;
    }

    public bool IsDead()
    {
        return isDead;
    }
}
