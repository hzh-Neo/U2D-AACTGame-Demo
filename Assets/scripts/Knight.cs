using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Knight : MonoBehaviour
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
    private Timer timer;
    Rigidbody2D body;
    private bool IsAttack
    {
        get
        {
            return anim.GetBool(KnightAnimations.Attack1);
        }
        set
        {
            anim.SetBool(KnightAnimations.Attack1, value);
        }
    }

    public bool IsMoving
    {
        get
        {
            return anim.GetBool(KnightAnimations.isMoving);
        }
        set
        {
            anim.SetBool(KnightAnimations.isMoving, value);
        }
    }

    private bool attackTimer;

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2 = GetComponent<CapsuleCollider2D>();
        checkTouching = new CheckTouching();
        anim = GetComponent<Animator>();
        timer = gameObject.AddComponent<Timer>();
    }
    private void Update()
    {
        if (!damageable.IsAlive)
        {
            anim.SetBool(KnightAnimations.death, true);
            return;
        }
        if (detectionCheck && detectionCheck.EnterColliders2D.Count > 0)
        {
            if (!attackTimer)
            {
                StartAttack();
            }
        }
        if (IsMoving&&damageable.IsAlive)
        {
            Moving();
        }
        else
        {
            StopMoving();
        }
    }

    /// <summary>
    /// ¿ªÊ¼¹¥»÷
    /// </summary>
    private void StartAttack()
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

    /// <summary>
    /// ÒÆ¶¯
    /// </summary>
    private void Moving()
    {
        int tNum = transform.localScale.x > 0 ? 1 : -1;
        body.velocity = new Vector2(checkTouching.WalkDirection.x + tNum * walkSpeed, body.velocity.y);
    }

    /// <summary>
    /// Í£Ö¹ÒÆ¶¯
    /// </summary>
    private void StopMoving()
    {
        body.velocity = new Vector2(Mathf.Lerp(body.velocity.x, 0f, StopWait), body.velocity.y);
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

        rotateBodyListener();
    }

    public void onHit(float damage, Vector2 hitVect)
    {
        anim.SetTrigger(AnimationString.hit);
        body.velocity = new Vector2(hitVect.x, hitVect.y);
    }
}
