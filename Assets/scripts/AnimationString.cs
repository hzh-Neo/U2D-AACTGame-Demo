using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

internal class AnimationString
{
    internal static readonly string GroundState = "GroundState";
    internal static readonly string AirState = "AirState";
    internal static readonly string IsGrounded = "IsGrounded";
    internal static readonly string IsJump = "IsJump";
    internal static readonly string yVelocity = "yVelocity";
    internal static readonly string IsSideTouch = "IsSideTouch";
    internal static readonly string IsCeiling = "IsCeiling";
    internal static readonly string attack_1 = "attack_1";
    internal static readonly string hit = "hit";
    internal static readonly string death = "death";
    internal static readonly string attack_2= "attack_2";
}

internal class KnightAnimations
{
    internal static readonly string Attack1 = "attack_1";
    internal static readonly string hit = "hit";
    internal static readonly string isMoving = "isMoving";
    internal static readonly float attackWaitTime =2.0f;
    internal static readonly float attackTime = 1f;
    internal static readonly string death = "death";
}

internal class FlyingEyeAnimations
{
    internal static readonly string Attack1 = "attack_1";
    internal static readonly string hit = "hit";
    internal static readonly string isMoving = "isMoving";
    internal static readonly float attackWaitTime = 2.0f;
    internal static readonly float attackTime = 1f;
    internal static readonly string death = "death";
}
