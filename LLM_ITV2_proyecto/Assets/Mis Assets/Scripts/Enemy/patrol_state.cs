using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class patrol_state : StateMachineBehaviour
{
    //float timer;
    //float timelimit;
    float playerDistance;
    float chaseDistance = 8;
    Transform player;
    List<string> paraNames = new List<string>{"small_attack","damaged","is_moving","is_Alive","is_chasing"};
    List<Transform> wayPoints = new List<Transform>();
    NavMeshAgent agent;
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        agent = animator.GetComponent<NavMeshAgent>();
        //timer = 0;
        //timelimit = 10;
        GameObject ways = GameObject.FindGameObjectWithTag("Waypoint");
        foreach(Transform points in ways.transform)
        {
            wayPoints.Add(points);
        }
        DestinationC();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        playerDistance = Vector3.Distance(player.position,animator.transform.position);
        if(playerDistance<chaseDistance)
        {
            animator.SetBool(paraNames[4],true);
        }
        if(agent.remainingDistance <= agent.stoppingDistance)
        {
            animator.SetBool(paraNames[2],false);
        }
        
        /* timer check function.
            timer += Time.deltaTime;
            if(timer>timelimit)
            {
                animator.SetBool(paraNames[3],false);
            }
        */
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        agent.SetDestination(agent.transform.position);
    }

    void DestinationC()
    {
        agent.SetDestination(wayPoints[Random.Range(0,wayPoints.Count)].position);
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
