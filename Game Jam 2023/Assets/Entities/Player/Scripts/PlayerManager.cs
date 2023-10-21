using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    [SerializeField] private GameObject player;

    private void Awake()
    {
        Instance = this;
    }

    public GameObject GetPlayer()
    {
        return player;
    }
}
