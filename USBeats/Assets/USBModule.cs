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
    [SerializeField] string valueSuffix;
    [SerializeField] Text text;
    [SerializeField] Slider jauge;

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
    }
}
