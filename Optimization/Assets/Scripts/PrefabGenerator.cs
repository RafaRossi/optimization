using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefabGenerator : MonoBehaviour
{
    [Header("Object Options")]
    [SerializeField] private GameObject prefab;

    [Header("Grid Options")]
    [SerializeField] private int gridXCount = 100;
    [SerializeField] private int gridZCount = 100;
    
    [SerializeField] private float xDistance = 2f;
    [SerializeField] private float zDistance = 2f;

    [Header("Scale Properties")]
    [SerializeField] private float scaleMultiplier = 1f;
    
    private void Start()
    {
        Generate();
    }

    private void Generate()
    {
        for (var z = 0; z < gridZCount; z++)
        {
            for (var x = 0; x < gridXCount; x++)
            {
                var position = new Vector3(x * xDistance * scaleMultiplier, 0, z * zDistance * scaleMultiplier);
                var go =Instantiate(prefab, position, Quaternion.identity);
                go.transform.localScale *= scaleMultiplier;
            }
        }
    }
}
