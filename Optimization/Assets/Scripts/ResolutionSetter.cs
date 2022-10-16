using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ResolutionSetter : MonoBehaviour
{
    [SerializeField] private TMP_Text fpsCounter;
    private void Awake()
    {
        Screen.SetResolution(1920, 1080, FullScreenMode.Windowed);
    }

    [SerializeField] private float _hudRefreshRate = 1f;
 
    private float _timer;
 
    private void Update()
    {
        if (Time.unscaledTime > _timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsCounter.text = "FPS: " + fps;
            _timer = Time.unscaledTime + _hudRefreshRate;
        }
    }
}
