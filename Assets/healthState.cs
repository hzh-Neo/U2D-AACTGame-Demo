using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthState : MonoBehaviour
{
    public float max;
    public float value;
    public Slider slide;
    public TextMeshProUGUI textMeshPro;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setHealth(float _value, float _max)
    {
        max = _max;
        value = _value;
        slide.value = value / max;
        textMeshPro.text = $"{value} / {max}";
    }
}
