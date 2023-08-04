using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolState : StateController
{
    private int pathPointIndex;
    private float minDistanceToTarget = .5f;
    private float patrolWait;
    [SerializeField] private float waitTime = 5f;

   public override void EnterState()
   {
   }

   public override void PerformState()
   {
        Patrol();
   }

   public override void ExitState()
   {
   }

   public void Patrol()
   {
        if(enemy.MeshAgent.remainingDistance < minDistanceToTarget)
        {
            patrolWait += Time.deltaTime;
            if(patrolWait > waitTime)
            {
                if(pathPointIndex < enemy.enemyPatrolPath.enemyPossiblePath.Count - 1)
                {
                    pathPointIndex += 1;
                }
                else
                {
                    pathPointIndex = 0;
                }
                
                enemy.MeshAgent.SetDestination(enemy.enemyPatrolPath.enemyPossiblePath[pathPointIndex].position);      
                patrolWait = 0;        
            }
        }
   }
}