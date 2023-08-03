using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIStateMachine : MonoBehaviour
{
   public StateController currentState;
   public EnemyPatrolState enemyPatrolState;

   public void Init()
   {
      enemyPatrolState = new EnemyPatrolState();
      ChangeState(enemyPatrolState);
   }

   private void Update() {
      if(currentState != null)
      {
         currentState.PerformState();
      }
   }

   public void ChangeState(StateController _currentState)
   {
      if(currentState != null)
      {
         currentState.ExitState();
      }

      currentState = _currentState;

      if(currentState != null)
      {
         currentState.aiStateMachine = this;
         currentState.enemy = GetComponent<Enemy>();
         currentState.EnterState();
      }
   }
}
