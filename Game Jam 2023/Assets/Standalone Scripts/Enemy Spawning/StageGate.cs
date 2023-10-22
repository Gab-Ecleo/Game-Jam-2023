using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageGate : MonoBehaviour
{
    private void Start()
    {
        GateManager.Instance.AddGate(gameObject);
        gameObject.SetActive(false);
    }
}
