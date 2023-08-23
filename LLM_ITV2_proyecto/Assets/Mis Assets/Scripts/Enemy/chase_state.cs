using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class chase_state : StateMachineBehaviour
{
    Transform player;
    NavMeshAgent agent;
    float chaseDistance = 8;
    List<string> paraNames = new List<string>{"small_attack","damaged","is_moving","is_Alive","is_chasing"};
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.transform.LookAt(player.position);
        agent.SetDestination(player.position);
        if(agent.remainingDistance<=agent.stoppingDistance & animator.GetBool(paraNames[0]) == false)
        {
            Debug.Log("gotcha bitch");
            animator.SetBool(paraNames[0],true);
        };
        if(agent.remainingDistance>chaseDistance)
        {
            animator.SetBool(paraNames[4],false);
            animator.SetBool(paraNames[2],false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(animator.transform.position);
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
