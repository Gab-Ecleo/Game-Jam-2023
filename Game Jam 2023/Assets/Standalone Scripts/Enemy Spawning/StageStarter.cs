using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageStarter : MonoBehaviour
{
    [SerializeField] private Transform minBound;
    [SerializeField] private Transform maxBound;

    [SerializeField] private int[] enemyCounts;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("ISTRIGGERED");
        if (!collision.CompareTag("Player")) return;

        GateManager.Instance.ActivateGates(true);
        EnemySpawning.Instance.SetBounds(minBound.position, maxBound.position);
        EnemySpawning.Instance.StartSpawnWaves(enemyCounts);
        gameObject.SetActive(false);
    }
}
