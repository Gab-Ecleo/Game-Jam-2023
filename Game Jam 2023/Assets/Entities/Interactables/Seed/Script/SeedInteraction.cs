using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedInteraction : MonoBehaviour
{
    [SerializeField] private GameObject seedText;
    [SerializeField] private KeyCode interactKey;
    [SerializeField] private float detectionRange;

    private GameObject player;
    private bool isInteractable;

    private void Start()
    {
        player = PlayerManager.Instance.GetPlayer();
        isInteractable = false;
    }

    private void Update()
    {
        seedText.SetActive(false);

        if (!isInteractable) return;

        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance > detectionRange) return;

        seedText.SetActive(true);

        if (!Input.GetKeyDown(interactKey)) return;
            MapManager.Instance.PurifyLand();
    }

    public void EnableInteraction(bool state)
    {
        isInteractable = state;
    }
}
