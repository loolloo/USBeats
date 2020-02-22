using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Note : MonoBehaviour
{
    public Color catchedColor;
    public float speed;
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

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
