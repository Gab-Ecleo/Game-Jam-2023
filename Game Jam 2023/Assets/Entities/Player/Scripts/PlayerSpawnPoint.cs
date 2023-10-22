using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Vector2 spawnPosition = transform.position;
        PlayerManager.Instance.GetPlayer().transform.position = spawnPosition;
    }
}
