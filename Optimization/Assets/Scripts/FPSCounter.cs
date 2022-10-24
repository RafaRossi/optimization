using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    
    private void Update()
    {
        text.text = (1/Time.deltaTime).ToString();
    }
}
