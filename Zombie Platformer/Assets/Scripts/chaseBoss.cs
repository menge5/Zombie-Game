using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chaseBoss : StateMachineBehaviour
{
    
    //box to store the players transform info
    Transform player;
    
    Rigidbody2D bossRB;
    bossBehavior bossBehavior;

     //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        bossRB = animator.GetComponent<Rigidbody2D>();

        bossBehavior = animator.GetComponent<bossBehavior>();
    }

     //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Vector2 target = new Vector2(player.position.x, player.position.y);

        Vector2 newpos = Vector2.MoveTowards(bossRB.position, target, bossBehavior.speed * Time.deltaTime);

        bossRB.MovePosition(newpos);

        bossBehavior.lookAtPlayer();

        float distance = Vector2.Distance(player.position, bossRB.position);

        if(distance < bossBehavior.attackRange && !bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("meleeAttack");
        }
        else if(distance < bossBehavior.attackRange && bossBehavior.phase2 && !bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase2Attack");
        }
        else if(distance < bossBehavior.attackRange && !bossBehavior.phase2 && bossBehavior.phase3 && !bossBehavior.isDead)
        {
            animator.SetTrigger("Phase3Attack");
        }
        else if(bossBehavior.isDead)
        {
            animator.SetTrigger("Death");
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        
    }
}
