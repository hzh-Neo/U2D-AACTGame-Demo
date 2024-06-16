using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectionCheck : MonoBehaviour
{
    public List<Collider2D> EnterColliders2D;
    BoxCollider2D boxCollider2D;

    void Start()
    {
        
    }

    private void Awake()
    {
        boxCollider2D=GetComponent<BoxCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        EnterColliders2D.Add(collision);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        EnterColliders2D.Remove(collision);
    }
}
