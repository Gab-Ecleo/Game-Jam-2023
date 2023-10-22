using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapAttacher : MonoBehaviour
{
    private enum ObjectType
    {
        CorruptedGrid,
        PurifiedGrid,
        FlashImage
    }

    [SerializeField] private ObjectType type;

    private void Start()
    {
        switch (type)
        {
            case ObjectType.CorruptedGrid:
                MapManager.Instance.SetCorruptedLand(gameObject);
                break;

            case ObjectType.PurifiedGrid:
                MapManager.Instance.SetPurifiedLand(gameObject);
                break;

            case ObjectType.FlashImage:
                MapManager.Instance.SetWhiteFlash(gameObject);
                break;
        }
    }
}
