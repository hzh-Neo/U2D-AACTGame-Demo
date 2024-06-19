using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class AttackArrowOut : StateMachineBehaviour
{
    public GameObject ArrowPrefab;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    //override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    
    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        GameObject playerObj = GameObject.Find("player");
        Vector3 newPosition = playerObj.transform.position;
        Quaternion newQuaternion = ArrowPrefab.transform.localRotation;
        if (playerObj.transform.localScale.x > 0)
        {
            newPosition += new Vector3(0.2f, -0.2f);
        }
        else
        {
            newPosition += new Vector3(-0.2f, -0.2f);
            newQuaternion.z = -newQuaternion.z;
        }

        // 在场景中实例化预制件
        GameObject arrow = Instantiate(ArrowPrefab, newPosition, newQuaternion);
        arrow.transform.localScale = new Vector2((playerObj.transform.localScale.x < 0 ? -1 : 1)*3, 3);
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that processes and affects root motion
    //}

    // OnStateIK is called right after Animator.OnAnimatorIK()
    //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{
    //    // Implement code that sets up animation IK (inverse kinematics)
    //}
}
