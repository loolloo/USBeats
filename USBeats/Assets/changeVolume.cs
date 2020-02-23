using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class changeVolume : MonoBehaviour
{
    public Slider volume;

    void Start()
    {
        volume.value = 0.5f;
    }

    // Update is called once per frame
    void Update()
    {
        AudioListener.volume = volume.value;
    }
}
