using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Note : MonoBehaviour
{
    public Color catchedColor;
    public Color rejectedColor;
    public float speed;
    public int noteSize;
    public Text noteText;
    [SerializeField] Gradient gradient;

    Image _image;

    void Start()
    {
        _image = GetComponent<Image>();
        // 2, 4, 8, 16
        noteSize = (int)Mathf.Pow(2, UnityEngine.Random.Range(1, 5));
        _image.color = gradient.Evaluate((float)noteSize / (float)16);
        noteText.text = noteSize + " Mo";
    }

    public void OnCatch()
    {
        _image.color = catchedColor;
    }

    public void OnReject()
    {
        _image.color = rejectedColor;
    }

    void Update()
    {
        transform.position += Vector3.down * speed * Time.deltaTime;
    }
}
