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
    public static ObjectPool BulletPool;

    [SerializeField] private GameObject poolPrefab;

    [Space]
    [Header("Pool Configs")]
    [SerializeField] private PoolConfig bulletPoolConfig;

    private void Awake()
    {
        BulletPool = NewObjectPool(bulletPoolConfig);
    }

    private ObjectPool NewObjectPool(PoolConfig config)
    {
        ObjectPool pool = Instantiate(poolPrefab, transform).GetComponent<ObjectPool>();
        pool.InitPool(config.objectPrefab, config.poolSize);
        return pool;
    }
}
