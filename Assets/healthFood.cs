using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class healthFood : MonoBehaviour
{
    public Vector3 rotateVector;
    public UnityEvent<float> eaterEvent;
    public float healthNum = 15f;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        eaterEvent?.Invoke(healthNum);
        Destroy(gameObject);
    }

    private void Update()
    {
        transform.eulerAngles += rotateVector * Time.deltaTime;
    }


}
