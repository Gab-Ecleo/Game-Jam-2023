using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private GameObject playerPrefab;

    private GameObject player;

    private void Awake()
    {
        Instance = this;

        player = Instantiate(playerPrefab, transform);
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
