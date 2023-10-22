using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    private enum ObjectType
    {
        CorruptedGrid,
        PurifiedGrid,
        FlashImage
    }

    public static MapManager Instance;

    private GameObject corruptedGrid;
    private GameObject healthyGrid;
    private GameObject whiteFlash;

    private void Awake()
    {
        Instance = this;
    }

    public void PurifyLand()
    {
        StartCoroutine(FlashTime());
        corruptedGrid.SetActive(false);
        healthyGrid.SetActive(true);
    }

    public void SetCorruptedLand(GameObject obj)
    {
        corruptedGrid = obj;
    }

    public void SetPurifiedLand(GameObject obj)
    {
        healthyGrid = obj;
    }

    public void SetWhiteFlash(GameObject obj)
    {
        whiteFlash = obj;
    }

    private IEnumerator FlashTime()
    {
        whiteFlash.SetActive(true);

        yield return new WaitForSeconds(1);

        whiteFlash.SetActive(false);
    }
}
