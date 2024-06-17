using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class CliffDetection : MonoBehaviour
{
    public UnityEvent unityEvent;
    public List<Collider2D> collider2Ds;
    private bool IsStart;

    private void Awake()
    {
     
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collider2Ds.Remove(collision);
        if (collider2Ds.Count == 0 && IsStart)
        {
            unityEvent?.Invoke();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collider2Ds.Add(collision);
        IsStart = true;
    }
}
