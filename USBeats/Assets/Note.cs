using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Note : MonoBehaviour
{
    public Color catchedColor;
    int noteSize;

    Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
    }

    public void OnCatch()
    {
        _image.color = catchedColor;
    }
}
