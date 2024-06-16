using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100;

    public UnityEvent<float, Vector2> unityEvent;

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


    public float health;

    public bool IsAlive
    {
        get { return health > 0; }
        set { }
    }

    private bool IsInvincible;

    private bool IsPlayer;

    public float InvincibleTime;

    private Renderer rend;

    [SerializeField]
    public float defaultInvincibleTime = 2.5f;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void Awake()
    {
        health = maxHealth;
        InvincibleTime = defaultInvincibleTime;
        IsPlayer = gameObject.name == "player";
        rend = GetComponent<Renderer>();
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
            if (IsPlayer)
            {
                rend.enabled = !rend.enabled;
            }
            InvincibleTime -= Time.deltaTime;
            if (InvincibleTime <= 0)
            {
                rend.enabled = true;
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
    public void onHit(float damage, Vector2 hitVect)
    {
        if (health > 0)
        {
            if (!IsInvincible)
            {
                health -= damage;
                IsInvincible = true;
                unityEvent?.Invoke(damage, hitVect);
            }
        }
    }

}
