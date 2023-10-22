using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    private void Start()
    {
        Vector2 spawnPosition = transform.position;
        PlayerManager.Instance.GetPlayer().transform.position = spawnPosition;
    }
}
