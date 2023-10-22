using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GateManager : MonoBehaviour
{
    public static GateManager Instance;

    public GameObject[] gates;

    private void Awake()
    {
        Instance = this;
        gates = new GameObject[1];
    }

    public void AddGate(GameObject gate)
    {
        GameObject[] newGates = new GameObject[gates.Length + 1];
        gates.CopyTo(newGates, 0);
        newGates[gates.Length] = gate;
        gates = newGates;
    }

    public void ActivateGates(bool state)
    {
        if (gates.Length < 2) return;

        for(int n = 1; n < gates.Length; n++)
        {
            gates[n].SetActive(state);
        }
    }
}
