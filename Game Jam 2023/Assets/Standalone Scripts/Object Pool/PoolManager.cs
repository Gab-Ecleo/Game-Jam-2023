using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PoolConfig
{
    public GameObject objectPrefab;
    public int poolSize;
}

public class PoolManager : MonoBehaviour
{
    public static ObjectPool SpecialBulletPool;
    public static ObjectPool BulletPool;
    public static ObjectPool EnemyPool1;
    public static ObjectPool EnemyPool2;

    [SerializeField] private GameObject poolPrefab;

    [Space]
    [Header("Pool Configs")]
    [SerializeField] private PoolConfig specialPoolConfig;
    [SerializeField] private PoolConfig bulletPoolConfig;
    [SerializeField] private PoolConfig enemyPoolConfig1;
    [SerializeField] private PoolConfig enemyPoolConfig2;

    private void Awake()
    {
        SpecialBulletPool = NewObjectPool(specialPoolConfig);
        BulletPool = NewObjectPool(bulletPoolConfig);
        EnemyPool1 = NewObjectPool(enemyPoolConfig1);
        EnemyPool2 = NewObjectPool(enemyPoolConfig2);
    }

    private ObjectPool NewObjectPool(PoolConfig config)
    {
        ObjectPool pool = Instantiate(poolPrefab, transform).GetComponent<ObjectPool>();
        pool.InitPool(config.objectPrefab, config.poolSize);
        return pool;
    }
}
