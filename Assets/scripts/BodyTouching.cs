using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using enums;

public class BodyTouching : MonoBehaviour
{
    public ContactFilter2D contactFilter;
    private Animator anim;
    private CapsuleCollider2D capsuleCollider2;
    public CheckTouching checkTouching;

    public bool _IsGround = false;
    public bool IsLeftWall = false;
    public bool IsRightWall = false;


    public bool IsGround
    {
        get
        {
            return anim.GetBool(AnimationString.IsGrounded);
        }
        set
        {
            anim.SetBool(AnimationString.IsGrounded, value);
            _IsGround = value;
        }
    }
    bool _IsSideTouch;
    public bool IsSideTouch
    {
        get
        {
            return anim.GetBool(AnimationString.IsSideTouch);
        }
        set
        {
            _IsSideTouch = value;
            anim.SetBool(AnimationString.IsSideTouch, value);
        }
    }

    public bool IsCeiling
    {
        get
        {
            return anim.GetBool(AnimationString.IsCeiling);
        }
        set
        {
            anim.SetBool(AnimationString.IsCeiling, value);
        }
    }

    public int playerAirState
    {
        get
        {
            return anim.GetInteger(AnimationString.AirState);
        }
        set
        {
            anim.SetInteger(AnimationString.AirState, value);
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }
    private void Awake()
    {
        capsuleCollider2 = GetComponent<CapsuleCollider2D>();
        anim = GetComponent<Animator>();
        checkTouching = new CheckTouching();
    }

    private void FixedUpdate()
    {
        onBodyState();
    }

    /// <summary>
    /// 获取部位接触
    /// </summary>
    private void onBodyState()
    {
        checkTouching.CheckIsTouching(capsuleCollider2, gameObject, contactFilter);
        IsGround = checkTouching.IsGround;
        IsCeiling = checkTouching.IsCeiling;
        IsLeftWall = checkTouching.IsLeftWall;
        IsRightWall = checkTouching.IsRightWall;
        IsSideTouch = checkTouching.IsSideTouch;
    }
}
