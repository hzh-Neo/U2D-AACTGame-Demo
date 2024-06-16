using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damageable : MonoBehaviour
{
    private float _maxHealth = 100;

    private Animator anim;

    public float maxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    [SerializeField]
    public float health=100;

    public bool IsAlive
    {
        get { return health > 0; }
        set { }
    }

    private bool IsInvincible;

    private float InvincibleTime;

    [SerializeField]
    public float defaultInvincibleTime=2f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        health = maxHealth;
        anim = GetComponent<Animator>();
        InvincibleTime = defaultInvincibleTime;
    }

    // Update is called once per frame
    void Update()
    {
        onInvincible();
    }

    private void onInvincible()
    {
        if (IsInvincible)
        {
            InvincibleTime -= Time.deltaTime;
            if (InvincibleTime <= 0)
            {
                IsInvincible = false;
                InvincibleTime = defaultInvincibleTime;
            }
        }
    }

    private void FixedUpdate()
    {

    }
    /// <summary>
    ///  ‹…À
    /// </summary>
    /// <param name="damage"></param>
    public void onHit(float damage)
    {
        if (health > 0&&!IsInvincible)
        {
            health -= damage;
            IsInvincible = true;
        }
    }

}
