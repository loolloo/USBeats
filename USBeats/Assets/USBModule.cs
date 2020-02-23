using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class USBModule : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] int currentData;
    [SerializeField] int missedData;
    public int maxData;

    [Header("UI Elements")]
    [SerializeField] string valueSuffix;
    [SerializeField] Text text;
    [SerializeField] Slider jauge;
    [SerializeField] Slider missed;

    void Start()
    {
        text.text = currentData + valueSuffix;
    }

    public void AddData(int data)
    {
        currentData += data;
        text.text = currentData + valueSuffix;
    }

    void Update()
    {
        jauge.value = (float)currentData / (float)maxData;
        missed.value = ((float)currentData + (float)missedData) / (float)maxData;
    }
}
