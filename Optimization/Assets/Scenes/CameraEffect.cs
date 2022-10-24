using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CameraEffect : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private FilterMode filterMode;
    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        src.filterMode = filterMode;
        
        if (material == null)
        {
            Graphics.Blit(src, dest);
            return;
        }
        
        Graphics.Blit(src, dest, material);
    }
}
