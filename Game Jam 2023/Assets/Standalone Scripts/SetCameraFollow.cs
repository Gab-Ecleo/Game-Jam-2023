using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SetCameraFollow : MonoBehaviour
{
    private CinemachineVirtualCamera _cam;

    private void Awake()
    {
        _cam = GetComponent<CinemachineVirtualCamera>();
    }

    private void Start()
    {
        _cam.Follow = PlayerManager.Instance.GetPlayer().transform;
    }
}
