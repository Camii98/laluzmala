using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class idle_state : StateMachineBehaviour
{
    float timer;
    float timelimit;
    float playerDistance;
    [SerializeField] private float chaseDistance = 8;
    Transform player;
    List<string> paraNames = new List<string>{"small_attack","damaged","is_moving","is_Alive","is_chasing"};
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0;
        timelimit = 5;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerDistance = Vector3.Distance(player.position,animator.transform.position);
        if(playerDistance<chaseDistance)
        {
            animator.SetBool(paraNames[4],true);
        };
        timer += Time.deltaTime;
        if(timer>timelimit)
        {
            animator.SetBool(paraNames[2],true);
        };
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
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
