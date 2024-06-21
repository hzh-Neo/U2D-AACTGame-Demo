using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlyingEye : MonoBehaviour
{
    public float StopWait = 0.2f;
    //¹¥»÷ÅÐ¶ÏÇøÓò
    public DetectionCheck detectionCheck;

    public ContactFilter2D contactFilter;

    public float walkSpeed = 3f;

    //½Ó´¥
    public CheckTouching checkTouching;
    private CapsuleCollider2D capsuleCollider2;

    public Damageable damageable;
    private Animator anim;
    private STimer timer;
    Rigidbody2D body;

    public bool lockPosition = false;
    private float hitTime = 0.75f;
    private bool hitTimer;
    private bool IsAttack
    {
        get
        {
            return anim.GetBool(FlyingEyeAnimations.Attack1);
        }
        set
        {
            anim.SetBool(FlyingEyeAnimations.Attack1, value);
        }
    }

    public bool IsMoving
    {
        get
        {
            return anim.GetBool(FlyingEyeAnimations.isMoving);
        }
        set
        {
            anim.SetBool(FlyingEyeAnimations.isMoving, value);
        }
    }

    private bool attackTimer;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2 = GetComponent<CapsuleCollider2D>();
        checkTouching = new CheckTouching();
        anim = GetComponent<Animator>();
        timer = gameObject.AddComponent<STimer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!damageable.IsAlive)
        {
            anim.SetBool(KnightAnimations.death, true);
            IsMoving = false;
            return;
        }
    }

    private void rotateBodyListener()
    {
        if (checkTouching.IsSideTouch)
        {
            Methods.rotateBody(transform);
        }
    }

    private void FixedUpdate()
    {
        checkTouching.CheckIsTouching(capsuleCollider2, gameObject, contactFilter);
    }

    public void onHit(float damage, Vector2 hitVect, bool IsFarAttack = false)
    {
        lockPosition = true;
        anim.SetTrigger(FlyingEyeAnimations.hit);
        if (!hitTimer)
        {
            hitTimer = timer.StartTimer(hitTime, () =>
            {
                hitTimer = false;
                lockPosition = false;
            });
        }
    }

    public void setMove(bool moving = false)
    {
        IsMoving = moving;
    }

    public void onAttack()
    {
        IsAttack = true;
        IsMoving = false;
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        attackTimer = timer.StartTimer(KnightAnimations.attackWaitTime, () =>
        {
            EnableMoving();
        });

        attackTimer = timer.StartTimer(KnightAnimations.attackTime, () =>
        {
            StopAttack();
        });
        anim.SetTrigger(FlyingEyeAnimations.Attack1);
    }

    private void EnableMoving()
    {
        attackTimer = false;
        IsMoving = true;
    }

    /// <summary>
    /// Í£Ö¹¹¥»÷
    /// </summary>
    private void StopAttack()
    {
        IsAttack = false;
    }
}
