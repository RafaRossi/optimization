using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] private Vector3 rotationVector = Vector3.zero;
    [SerializeField] private float rotationSpeed = 20f;
    
    private void Update()
    {
        transform.eulerAngles += rotationVector * (rotationSpeed * Time.deltaTime);
    }
}
