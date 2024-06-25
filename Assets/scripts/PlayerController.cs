using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

using enums;


[RequireComponent(typeof(CapsuleCollider2D), typeof(BodyTouching))]
public class PlayerController : MonoBehaviour
{
    public Damageable damageable;
    public float playerSpeed = 6f;
    public float walkSpeed = 6f;
    public float runningSpeed = 8f;
    public float jumpHeight = 8.6f;
    private bool _isFacingRight = true;
    private bool IsReverseSide;
    public bool lockPosition = false;
    private float hitTime = 0.75f;
    private bool hitTimer;
    BodyTouching bodyTouching;
    private bool isFacingRight
    {
        get
        {
            return _isFacingRight;
        }
        set
        {
            if (_isFacingRight != value)
            {

                if (damageable.IsAlive)
                {
                    IsReverseSide = false;
                    Methods.rotateBody(transform);
                }
            }
            _isFacingRight = value;
        }
    }

    private float yVelocity
    {
        get
        {
            return anim.GetFloat(AnimationString.yVelocity);
        }
        set
        {
            anim.SetFloat(AnimationString.yVelocity, value);
        }
    }
    private Rigidbody2D body;
    private Vector2 inputControll;
    private bool isWalking;
    private bool isShitfDonw;
    private STimer timer;
    public int playerGroundState
    {
        get
        {
            return anim.GetInteger(AnimationString.GroundState);
        }
        set
        {
            anim.SetInteger(AnimationString.GroundState, value);
        }
    }

    Animator anim;
    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bodyTouching = GetComponent<BodyTouching>();
        timer = gameObject.AddComponent<STimer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    /// <summary>
    /// ·´Ç½Ìø
    /// </summary>
    private void ReverseJump()
    {
        isFacingRight = bodyTouching.IsLeftWall ? true : false;
        int tNum = isFacingRight ? 1 : -1;
        anim.SetTrigger(AnimationString.IsJump);
        bodyTouching.playerAirState = (int)playerAirStateEnum.jumping;
        body.velocity = new Vector2(tNum * 100, body.velocity.y + jumpHeight);
        bodyTouching.IsSideTouch = false;
        IsReverseSide = false;

    }

    /// <summary>
    /// ÒÆ¶¯
    /// </summary>
    private void GroundMove()
    {
        if (!lockPosition)
        {
            body.velocity = new Vector2(inputControll.x * playerSpeed, body.velocity.y);
        }

    }

    /// <summary>
    /// ËÀÍö
    /// </summary>
    private void Die()
    {
        anim.SetBool(AnimationString.death, true);
    }

    private void FixedUpdate()
    {
        if (!damageable.IsAlive)
        {
            Die();
            return;
        }
        //·´Ç½Ìø
        if (bodyTouching.IsSideTouch && IsReverseSide)
        {
            ReverseJump();
            return;
        }
        if (!bodyTouching.IsSideTouch && !lockPosition)
        {
            GroundMove();
        }

        yVelocity = body.velocity.y;

        if (isWalking)
        {
            if (isShitfDonw)
            {
                setPlayerRuning();
            }
            else
            {
                setPlayerWalk();
            }
        }
        else
        {
            setPlayerStand();
        }
    }

    private void setPlayerWalk()
    {
        if (bodyTouching.IsGround && !lockPosition)
        {
            playerSpeed = walkSpeed;
            playerGroundState = (int)playerGroundStateEnum.walk;
        }
    }

    private void setPlayerStand()
    {
        if (bodyTouching.IsGround)
        {
            playerSpeed = walkSpeed;
            playerGroundState = (int)playerGroundStateEnum.stand;
        }
    }

    private void setPlayerRuning()
    {
        if (bodyTouching.IsGround && !bodyTouching.IsSideTouch)
        {
            playerSpeed = runningSpeed;
            playerGroundState = (int)playerGroundStateEnum.run;
        }

    }

    public void onMove(InputAction.CallbackContext context)
    {
        if (!damageable.IsAlive)
        {
            return;
        }
        inputControll = context.ReadValue<Vector2>();
        isWalking = inputControll != Vector2.zero;
        if (inputControll.x > 0 && !isFacingRight)
        {
            isFacingRight = true;
        }
        else if (inputControll.x < 0 && isFacingRight)
        {
            isFacingRight = false;
        }
    }

    public void onRun(InputAction.CallbackContext context)
    {
        if (!damageable.IsAlive)
        {
            return;
        }
        if (context.started)
        {
            isShitfDonw = true;
        }
        else if (context.canceled)
        {
            isShitfDonw = false;
        }
    }

    public void onJump(InputAction.CallbackContext context)
    {
        if (!damageable.IsAlive || IsReverseSide)
        {
            return;
        }
        if (context.started)
        {
            if (bodyTouching.IsGround || bodyTouching.IsSideTouch)
            {
                if (bodyTouching.IsSideTouch)
                {
                    IsReverseSide = true;
                }
                else
                {
                    body.velocity = new Vector2(body.velocity.x, jumpHeight);
                    anim.SetTrigger(AnimationString.IsJump);
                    bodyTouching.playerAirState = (int)playerAirStateEnum.jumping;
                }


            }
        }
        else if (context.canceled)
        {

        }
    }
    public void onAttack(InputAction.CallbackContext context)
    {
        if (!damageable.IsAlive)
        {
            return;
        }
        if (context.started)
        {
            if (!bodyTouching.IsSideTouch)
            {
                if (bodyTouching.IsGround)
                {
                    anim.SetTrigger(AnimationString.attack_1);
                }
                else
                {
                    anim.SetTrigger(AnimationString.attack_1);
                }
            }
        }
        else
        {

        }
    }

    public void onAttack2(InputAction.CallbackContext context)
    {
        if (!damageable.IsAlive)
        {
            return;
        }
        if (context.started)
        {
            if (!bodyTouching.IsSideTouch)
            {
                if (bodyTouching.IsGround)
                {
                    anim.SetTrigger(AnimationString.attack_2);
                }
                else
                {
                    anim.SetTrigger(AnimationString.attack_2);
                }
            }
        }
        else
        {

        }
    }

    public void onHit(float damage, Vector2 hitVect, bool IsFarAttack = false)
    {
        lockPosition = true;
        int tNum = transform.localScale.x > 0 ? -1 : 1;
        body.velocity = new Vector2(hitVect.x * tNum, body.velocity.y + hitVect.y);
        anim.SetTrigger(AnimationString.hit);
        if (!hitTimer)
        {
            hitTimer = timer.StartTimer(hitTime, () =>
            {
                hitTimer = false;
                lockPosition = false;
            });
        }

    }

    public void onHeal(float health)
    {
        if (damageable.IsAlive)
        {

            CharactersEvents.characterHealth.Invoke(gameObject, Mathf.Min(damageable.maxHealth - damageable.health, health));
            damageable.health = Mathf.Min(damageable.health + health, damageable.maxHealth);

        }
    }

}
