using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;


internal class Methods
{

    public static IEnumerator SmoothWallJump(Rigidbody2D body, float direction, float jumpHeight)
    {
        float duration = 0.2f; // Duration over which the velocity change will occur
        float time = 0;
        Vector2 initialVelocity = body.velocity;
        Vector2 targetVelocity = new Vector2(initialVelocity.x + direction, initialVelocity.y + jumpHeight);

        while (time < duration)
        {
            body.velocity = Vector2.Lerp(initialVelocity, targetVelocity, time / duration);
            time += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        body.velocity = targetVelocity; // Ensure final velocity is set
    }

    /// <summary>
    /// 旋转人物
    /// </summary>
    /// <param name="transform"></param>
    public static void rotateBody(UnityEngine.Transform transform)
    {
        transform.localScale *= new Vector2(-1, 1);
    }

    /// <summary>
    /// 播放动画
    /// </summary>
    /// <param name="animator"></param>
    /// <param name="animationName"></param>
    /// <returns></returns>
    public static IEnumerator PlayAnimationAndWait(Animator animator, string animationName)
    {
        // 播放动画
        animator.Play(animationName);

        // 获取动画状态信息
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        // 等待动画完成
        yield return new WaitForSeconds(stateInfo.length);
    }
}

