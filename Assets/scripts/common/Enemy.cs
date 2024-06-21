using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float StopWait = 0.2f;
    //攻击判断区域
    public DetectionCheck detectionCheck;

    public CliffDetection cliffDetection;

    public ContactFilter2D contactFilter;

    public float walkSpeed = 3f;

    //接触
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

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        capsuleCollider2 = GetComponent<CapsuleCollider2D>();
        checkTouching = new CheckTouching();
        anim = GetComponent<Animator>();
        timer = gameObject.AddComponent<STimer>();
    }

}
