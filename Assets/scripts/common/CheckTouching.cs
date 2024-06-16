using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;


public class CheckTouching
{
    float distanceFloor = 0.05f;
    float distanceCeiling = 0.05f;
    float touchWall = 0.2f;

    public bool IsGround = false;
    public bool IsLeftWall = false;
    public bool IsRightWall = false;
    public bool IsCeiling = false;
    public bool IsSideTouch = false;
    public bool IsTouch = false;


    RaycastHit2D[] raycastHit2Ds = new RaycastHit2D[5];
    RaycastHit2D[] leftHit2Ds = new RaycastHit2D[5];
    RaycastHit2D[] rightHit2Ds = new RaycastHit2D[5];
    RaycastHit2D[] ceilingHit2Ds = new RaycastHit2D[5];

    public Vector2 WalkDirection;

    /// <summary>
    /// 检测碰撞
    /// </summary>
    /// <param name="capsuleCollider2"></param>
    /// <param name="gameObject"></param>
    public void CheckIsTouching(CapsuleCollider2D capsuleCollider2, GameObject gameObject, ContactFilter2D contactFilter)
    {
        IsGround = capsuleCollider2.Cast(Vector2.down, contactFilter, raycastHit2Ds, distanceFloor) > 0;
        IsCeiling = capsuleCollider2.Cast(Vector2.up, contactFilter, ceilingHit2Ds, distanceCeiling) > 0;
        IsLeftWall = capsuleCollider2.Cast(Vector2.left, contactFilter, leftHit2Ds, touchWall) > 0;
        IsRightWall = capsuleCollider2.Cast(Vector2.right, contactFilter, rightHit2Ds, touchWall) > 0;
        if (gameObject.transform.localScale.x > 0)
        {
            IsSideTouch = IsRightWall;
            WalkDirection = Vector2.right;
        }
        else
        {
            IsSideTouch = IsLeftWall;
            WalkDirection = Vector2.left;
        }
    }

    /// <summary>
    /// 检测碰撞
    /// </summary>
    /// <param name="boxCollider2D"></param>
    /// <param name="gameObject"></param>
    public void CheckIsTouching(BoxCollider2D boxCollider2D, GameObject gameObject, ContactFilter2D contactFilter)
    {
        IsGround = boxCollider2D.Cast(Vector2.down, contactFilter, raycastHit2Ds, distanceFloor) > 0;
        IsCeiling = boxCollider2D.Cast(Vector2.up, contactFilter, ceilingHit2Ds, distanceCeiling) > 0;
        IsLeftWall = boxCollider2D.Cast(Vector2.left, contactFilter, leftHit2Ds, touchWall) > 0;
        IsRightWall = boxCollider2D.Cast(Vector2.right, contactFilter, rightHit2Ds, touchWall) > 0;
        if (gameObject.transform.localScale.x > 0)
        {
            IsSideTouch = IsRightWall;
            WalkDirection = Vector2.right;
        }
        else
        {
            IsSideTouch = IsLeftWall;
            WalkDirection = Vector2.left;
        }
        IsTouch = IsGround || IsCeiling || IsLeftWall || IsRightWall;
    }
}

