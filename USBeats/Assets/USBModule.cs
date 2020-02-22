using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class USBModule : MonoBehaviour
{
    [Header("Data")]
    int currentData;
    public int maxData;

    [Header("UI Elements")]
    [SerializeField] Slider jauge;

    public void AddData(int data)
    {
        currentData += data;
    }

    void Update()
    {
        jauge.value = (float)currentData / (float)maxData;
    }
}
