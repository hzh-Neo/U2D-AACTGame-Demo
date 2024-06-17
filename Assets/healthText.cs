using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class healthText : MonoBehaviour
{
    TextMeshProUGUI textMeshPro;
    public Vector3 startPostition;
    public Vector3 damageUpSpeed = new Vector3(0, 30, 0);
    private float showTime;
    private float defaultShowTime = 1.33f;
    private Color startColor;
    public bool isEnable = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        startPostition = transform.position;
        textMeshPro = GetComponent<TextMeshProUGUI>();
        startColor = textMeshPro.color;
        showTime = defaultShowTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (isEnable)
        {
            showDamageText();
        }
     
    }

    private void showDamageText()
    {
        showTime -= Time.deltaTime;
        transform.position += damageUpSpeed * Time.deltaTime;
        textMeshPro.color = new Color(startColor.r, startColor.g, startColor.b, startColor.a * showTime / defaultShowTime);
        if (showTime < 0)
        {
            Destroy(gameObject);
        }

    }
}
