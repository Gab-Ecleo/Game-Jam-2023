using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [SerializeField] private float cooldown;

    private Transform player;
    private bool isReady;

    private void Awake()
    {
        isReady = true;
    }

    private void Start()
    {
        player = PlayerManager.Instance.GetComponent<Transform>();
    }

    private void Update()
    {
        if (!isReady) return;

        Shoot();
    }

    public void Shoot()
    {
        GameObject bulletInstance = PoolManager.BulletPool.GetObject();
        BulletMovement bullet = bulletInstance.GetComponent<BulletMovement>();
        bullet.SetPosition(transform.position);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 targetPosition = player.position;
        Vector2 position = transform.position;
        Vector2 direction = targetPosition - position;

        bullet.Shoot(direction);

        StartCoroutine(Cooldown());
    }

    private IEnumerator Cooldown()
    {
        isReady = false;

        yield return new WaitForSeconds(cooldown);

        isReady = true;
    }
}
