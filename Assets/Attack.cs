using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Attack : MonoBehaviour
{
    [SerializeField]
    public float AttackNum = 10;

    public bool IsFarAttack = false;

    public GameObject DestoryObj;

    public GameObject AttackBody;

    private bool CanAttack = true;

    [SerializeField]
    public Vector2 hitVect = Vector2.zero;
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable && damageable.IsAlive && CanAttack)
        {
            damageable.onHit(AttackNum, hitVect, IsFarAttack);
            if (gameObject)
            {
                Destroy(DestoryObj);
            }
        }
    }

    public void onDisabled()
    {
        CanAttack = false;
    }

}
