using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpecial : MonoBehaviour
{
    [SerializeField] private float cooldown;

    private bool isReady;

    private void Awake()
    {
        isReady = true;
    }

    private void Update()
    {
        if (!isReady) return;

        if (!Input.GetMouseButtonDown(1)) return;

        Shoot();
    }

    public void Shoot()
    {
        GameObject bulletInstance = PoolManager.SpecialBulletPool.GetObject();
        BulletMovement bullet = bulletInstance.GetComponent<BulletMovement>();
        bullet.SetPosition(transform.position);

        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 position = transform.position;
        Vector2 direction = mousePosition - position;

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
