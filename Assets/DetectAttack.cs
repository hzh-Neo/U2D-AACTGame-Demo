using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectAttack : MonoBehaviour
{
    public UnityEvent ue;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ue.Invoke();
    }
}
