using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    [SerializeField]
    private float _maxHealth = 100;

    public UnityEvent<float, Vector2,bool> unityEvent;

    public UnityEvent<float,float> healthChange;

    public UnityEvent deathEvent;
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

    private float deathTime;

    [SerializeField]
    public float defaultDeathTime = 2f;

    private float _health;
    public float health
    {
        get
        {
            return _health;
        }
        set {
            _health = value;
            healthChange?.Invoke(_health, maxHealth);
        }
    }
        

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
        deathTime = defaultDeathTime;
        healthChange?.Invoke(health, maxHealth);
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
                toggleEnable();
            }
            ExitInvincible();
        }
        if (!IsPlayer && !IsAlive)
        {
            TranslateDeath();
        }
    }

    private void ExitInvincible()
    {
        InvincibleTime -= Time.deltaTime;
        if (InvincibleTime <= 0)
        {
            rend.enabled = true;
            IsInvincible = false;
            InvincibleTime = defaultInvincibleTime;
        }
    }

    private void TranslateDeath()
    {
        deathEvent?.Invoke();
        toggleEnable();
        deathTime -= Time.deltaTime;
        if (deathTime <= 0)
        {
            rend.enabled = false;
            Destroy(gameObject);
        }
    }

    private void toggleEnable()
    {
        rend.enabled = !rend.enabled;
    }

    private void FixedUpdate()
    {

    }
    /// <summary>
    ///  ‹…À
    /// </summary>
    /// <param name="damage"></param>
    public void onHit(float damage, Vector2 hitVect,bool IsFarAttack=false)
    {
        if (health > 0)
        {
            if (!IsInvincible)
            {
                health -= damage;
                if (IsPlayer)
                {
                    IsInvincible = true;
                }
                unityEvent?.Invoke(damage, hitVect, IsFarAttack);
                CharactersEvents.characterDamage.Invoke(gameObject, damage);
            }
        }
    }

}
