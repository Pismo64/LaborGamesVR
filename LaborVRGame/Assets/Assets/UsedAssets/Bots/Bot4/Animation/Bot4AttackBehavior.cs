using System;
using UnityEngine;

public class Bot4AttackBehavior : StateMachineBehaviour
{

    [SerializeField]
    private int numberOfAttackAnimations;

    private bool isAttacking = false;
    private int attackAnimation;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isAttacking && stateInfo.normalizedTime % 1 < 0.02f)
        {
            isAttacking = true;
            attackAnimation = UnityEngine.Random.Range(0, numberOfAttackAnimations + 1);
        }
        else if (stateInfo.normalizedTime % 1 > 0.98)
        {
            isAttacking = false;
            attackAnimation = 0;
        }

        animator.SetFloat("AttackAnimation", attackAnimation, 0.2f, Time.deltaTime);

    }

}
