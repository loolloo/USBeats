using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class USBModule : MonoBehaviour
{
    [Header("Data")]
    [SerializeField] int currentData;
    [SerializeField] int missedData;
    int totalData {
        get { return currentData + missedData; }
    }
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
        if (totalData > maxData)
            return;
        currentData += data;
        text.text = totalData + valueSuffix;
    }

    public void AddBadData(int data)
    {
        if (totalData > maxData)
            return;
        missedData += data;
        text.text = totalData + valueSuffix;
    }

    void Update()
    {
        jauge.value = (float)currentData / (float)maxData;
        missed.value = (float)totalData / (float)maxData;
    }
}
