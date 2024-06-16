using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    public float AttackNum = 10;

    [SerializeField]
    public Vector2 hitVect = Vector2.zero;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable && damageable.IsAlive)
        {
            damageable.onHit(AttackNum, hitVect);
        }
    }

}
