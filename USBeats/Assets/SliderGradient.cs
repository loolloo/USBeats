using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderGradient : MonoBehaviour
{
    [SerializeField] Image targetImage;
    [SerializeField] Gradient gradient;

    public void SetColor(float value)
    {
        targetImage.color = gradient.Evaluate(value);
    }
}
