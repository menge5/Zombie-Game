using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyChase : StateMachineBehaviour
{

    //box to store the players transform info
     Transform player;

    Rigidbody2D bossRB;
    EnemyBehavior bossBehavior;

    

    

    //OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        bossRB = animator.GetComponent<Rigidbody2D>();

        bossBehavior = animator.GetComponent<EnemyBehavior>();

     
    }

    //OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {


        Vector2 target = new Vector2(player.position.x, bossRB.position.y);

        Vector2 newpos = Vector2.MoveTowards(bossRB.position, target, bossBehavior.speed * Time.deltaTime * 5f);

        bossRB.MovePosition(newpos);

        bossBehavior.lookAtPlayer();

        float distance = Vector2.Distance(player.position, bossRB.position);
        




        
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {

    }
}
