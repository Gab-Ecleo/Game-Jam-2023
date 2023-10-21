using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    private GameObject[] objectInstances;

    public void InitPool(GameObject prefab, int size)
    {
        objectInstances = new GameObject[size];

        for (int n = 0; n < objectInstances.Length; n++)
        {
            objectInstances[n] = Instantiate(prefab, transform);
            objectInstances[n].SetActive(false);
        }
    }

    public GameObject GetObject()
    {
        for(int n = 0; n < objectInstances.Length; n++)
        {
            if (objectInstances[n].activeSelf) continue;
            
            return objectInstances[n];
        }

        return null;
    }
}
